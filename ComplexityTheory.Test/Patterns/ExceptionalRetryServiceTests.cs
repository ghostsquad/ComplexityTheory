namespace ComplexityTheory.Test.Patterns {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;

    using ComplexityTheory.Core.Patterns;

    using FluentAssertions;

    using Moq;

    using Ploeh.AutoFixture;

    using SafeNet.Test.Common;

    using Xunit;

    public class ExceptionalRetryServiceTests {

        private Testable<ExceptionalRetryService> testable;

        private Mock<IRetryable> retryableMock;

        private Mock<RetryPolicyBase> retryPolicyMock;

        public ExceptionalRetryServiceTests() {
            this.testable = new Testable<ExceptionalRetryService>();
            this.retryPolicyMock = this.testable.InjectMock<RetryPolicyBase>();
            this.retryableMock = new Mock<IRetryable>();

            var retryScenarioDictionary = new Dictionary<IRetryScenario, int>();
            this.retryableMock.SetupGet(x => x.TriesUsing).Returns(retryScenarioDictionary);
        }

        [Fact]
        public void ProcessIsSuccessfulNoRetries() {
            this.retryableMock.Setup(x => x.ExecuteWithContext(It.IsAny<IRetryScenario>())).Verifiable();

            this.testable.ClassUnderTest.Execute(this.retryableMock.Object);

            this.retryableMock.Verify(x => x.ExecuteWithContext(It.IsAny<IRetryScenario>()), Times.Once());
            this.retryableMock.Verify(x => x.ExecuteWithContext(null), Times.Once());
        }

        [Fact]
        public void ProcessExceptionNoPolicyExpectFailExceptionBubbledUp() {
            this.retryableMock.Setup(x => x.ExecuteWithContext(It.IsAny<IRetryScenario>())).Throws<TestException>();

            Action act = () => this.testable.ClassUnderTest.Execute(this.retryableMock.Object);
            act.ShouldThrow<TestException>();
        }

        [Fact]
        public void ProcessExceptingNoMatchingScenarioExpectExceptionBubbledUp() {
            var retryScenarioMock = new Mock<IRetryScenario>();
            retryScenarioMock.Setup(
                scenario => scenario.IsProcessEligibleForRetry(It.IsAny<Exception>()))
                .Returns(false)
                .Verifiable();

            retryScenarioMock.SetupGet(x => x.MaxTries).Returns(1);

            this.retryableMock.Setup(x => x.ExecuteWithContext(It.IsAny<IRetryScenario>()))
                .Callback<IRetryScenario>(
                    scenario => {
                        if (scenario == null) {
                            throw new TestException();
                        }
                    })
                .Verifiable();

            var scenarios = new IRetryScenario[1] { retryScenarioMock.Object };
            this.retryPolicyMock.SetupGet(x => x.Scenarios).Returns(scenarios);

            Action act = () => this.testable.ClassUnderTest.Execute(this.retryableMock.Object);
            act.ShouldThrow<TestException>();

            retryScenarioMock.Verify(scenario => scenario.IsProcessEligibleForRetry(It.IsAny<Exception>()), Times.Once);
            this.retryableMock.Verify(x => x.ExecuteWithContext(It.Is<IRetryScenario>(scenario => scenario == null)), Times.Once());
            this.retryableMock.Verify(
                x => x.ExecuteWithContext(It.Is<IRetryScenario>(scenario => scenario == retryScenarioMock.Object)),
                Times.Never);
        }

        [Fact]
        public void ProcessExceptionMatchingScenarioExpectRetryWithScenario() {
            var retryScenarioMock = new Mock<IRetryScenario>();
            retryScenarioMock.Setup(
                scenario => scenario.IsProcessEligibleForRetry(It.Is<Exception>(input => input is TestException)))
                .Returns(true)
                .Verifiable();

            retryScenarioMock.SetupGet(x => x.MaxTries).Returns(1);

            this.retryableMock.Setup(x => x.ExecuteWithContext(It.IsAny<IRetryScenario>()))
                .Callback<IRetryScenario>(
                    scenario => {
                        if (scenario == null) {
                            throw new TestException();
                        }
                    })
                .Verifiable();

            var scenarios = new IRetryScenario[1] { retryScenarioMock.Object };
            this.retryPolicyMock.SetupGet(x => x.Scenarios).Returns(scenarios);

            this.testable.ClassUnderTest.Execute(this.retryableMock.Object);

            this.retryableMock.Verify(x => x.ExecuteWithContext(It.Is<IRetryScenario>(scenario => scenario == null)), Times.Once());
            this.retryableMock.Verify(
                x => x.ExecuteWithContext(It.Is<IRetryScenario>(scenario => scenario == retryScenarioMock.Object)),
                Times.Once());
        }
    }
}
