namespace ComplexityTheory.Core.Patterns {
    using System.Collections.Generic;

    public abstract class RetryPolicyBase {
        protected RetryPolicyBase() {
            this.Scenarios = new IRetryScenario[0];
        }

        protected RetryPolicyBase(IList<IRetryScenario> scenarios) {
            this.Scenarios = scenarios;
        }

        public virtual IList<IRetryScenario> Scenarios { get; private set; }
    }
}