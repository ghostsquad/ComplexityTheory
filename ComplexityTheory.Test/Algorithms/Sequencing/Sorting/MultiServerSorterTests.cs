namespace ComplexityTheory.Test.Algorithms.Sequencing.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using ComplexityTheory.Core.Algorithms.Sequencing.Sorting;
    using ComplexityTheory.Test.MoqHelpers;

    using FluentAssertions;

    using Moq;

    using Xunit;
    using Xunit.Abstractions;

    public class NullableLongComparer : IComparer<long?> {

        static readonly NullableLongComparer _instance = new NullableLongComparer();
        public static NullableLongComparer Default
        {
            get
            {
                return _instance;
            }
        }

        public int Compare(long? x, long? y) {
            if (!x.HasValue || !y.HasValue) {
                throw new InvalidOperationException("Cannot compare null longs.");
            }

            return x.Value.CompareTo(y.Value);
        }
    }

    public class SerializableObjectArray : IXunitSerializable
    {
        public SerializableObjectArray() {}

        public SerializableObjectArray(object[] value) {
            this.Value = value;
        }

        public object[] Value { get; private set; }

        public void Deserialize(IXunitSerializationInfo info) {
            this.Value = info.GetValue<object[]>("Value");
        }

        public void Serialize(IXunitSerializationInfo info) {
            info.AddValue("Value", this.Value);
        }
    }

    /// <summary>
    /// The multi server sorter tests.
    /// </summary>
    public class MultiServerSorterTests
    {
        public static TheoryData<object[]> ServerReturnsTheoryData {
            get {
                return new TheoryData<object[]>() {
                    new object[] {
                        new object[] { 1, 2, null, new Exception("Oops read past null!") },
                        new object[] { null, new Exception("Oops read past null!") },
                        new object[] { 1, 2 }
                    }
                };
            }
        }

        [Theory]
        [MemberData("ServerReturnsTheoryData")]
        public void Theories(object[] server1returns, object[] server2returns, object[] expectedSequence, string reason) {
            var fullServerMock = new Mock<IServer<long?>>();
            fullServerMock.Setup(s => s.GetNext())
                .ReturnsInOrder(server1returns);

            var emptyServerMock = new Mock<IServer<long?>>();
            emptyServerMock.Setup(s => s.GetNext())
                .ReturnsInOrder(server2returns);

            var mockWriter = new Mock<IWriter<long?>>();

            var actualWritten = new List<long?>();
            mockWriter.Setup(w => w.Write(It.IsAny<long?>())).Callback<long?>(actualWritten.Add);

            var servers = new[] { fullServerMock.Object, emptyServerMock.Object };

            var sut = new MultiServerSorter<long?>(mockWriter.Object, NullableLongComparer.Default);
            sut.Sort(servers);

            actualWritten.ShouldBeEquivalentTo(expectedSequence);
        }

        [Fact]
        public void GivenServerStartingWithNull_ExpectEmptyServerIgnored() {
            var fullServerMock = new Mock<IServer<long?>>();
            fullServerMock.SetupSequence(s => s.GetNext())
                .Returns(1)
                .Returns(10)
                .Returns(null)
                .Throws<InvalidOperationException>();

            var expectedSequence = new long[] { 1, 10 };

            var emptyServerMock = new Mock<IServer<long?>>();
            emptyServerMock.SetupSequence(s => s.GetNext())
                .Returns(null)
                .Throws<InvalidOperationException>();

            var mockWriter = new Mock<IWriter<long?>>();

            var actualWritten = new List<long?>();
            mockWriter.Setup(w => w.Write(It.IsAny<long?>())).Callback<long?>(actualWritten.Add);

            var servers = new[] { fullServerMock.Object, emptyServerMock.Object };

            var sut = new MultiServerSorter<long?>(mockWriter.Object, NullableLongComparer.Default);
            sut.Sort(servers);

            actualWritten.ShouldBeEquivalentTo(expectedSequence);
        }

        [Fact]
        public void GivenMultipleServersReturningDifferentSequenceLengths_ExpectGetNextNotCalledAfterNullReturned() {
            var firstServer = new Mock<IServer<long?>>();
            firstServer.SetupSequence(s => s.GetNext())
                .Returns(1)
                .Returns(10)
                .Returns(null)
                .Throws<InvalidOperationException>();

            var secondServer = new Mock<IServer<long?>>();
            secondServer.SetupSequence(s => s.GetNext())
                .Returns(2)
                .Returns(null)
                .Throws<InvalidOperationException>();

            var expectedSequence = new long[] { 1, 2, 10 };

            var mockWriter = new Mock<IWriter<long?>>();

            var actualWritten = new List<long?>();
            mockWriter.Setup(w => w.Write(It.IsAny<long?>())).Callback<long?>(actualWritten.Add);

            var servers = new[] { firstServer.Object, secondServer.Object };

            var sut = new MultiServerSorter<long?>(mockWriter.Object, NullableLongComparer.Default);
            sut.Sort(servers);

            actualWritten.ShouldBeEquivalentTo(expectedSequence);
        }

        [Fact]
        public void GivenDuplicates_ExpectSequenceToIncludeDuplicatesInCorrectOrder()
        {
            var firstServer = new Mock<IServer<long?>>();
            firstServer.SetupSequence(s => s.GetNext())
                .Returns(1)
                .Returns(2)
                .Returns(null)
                .Throws<InvalidOperationException>();

            var secondServer = new Mock<IServer<long?>>();
            secondServer.SetupSequence(s => s.GetNext())
                .Returns(1)
                .Returns(null)
                .Throws<InvalidOperationException>();

            var expectedSequence = new long[] { 1, 1, 2 };

            var mockWriter = new Mock<IWriter<long?>>();

            var actualWritten = new List<long?>();
            mockWriter.Setup(w => w.Write(It.IsAny<long?>())).Callback<long?>(actualWritten.Add);

            var servers = new[] { firstServer.Object, secondServer.Object };

            var sut = new MultiServerSorter<long?>(mockWriter.Object, NullableLongComparer.Default);
            sut.Sort(servers);

            actualWritten.ShouldBeEquivalentTo(expectedSequence);
        }

        [Fact]
        public void GivenNegativeNumbers_ExpectSequenceToIncludeDuplicatesInCorrectOrder()
        {
            var firstServer = new Mock<IServer<long?>>();
            firstServer.SetupSequence(s => s.GetNext())
                .Returns(-20)
                .Returns(10)
                .Returns(null)
                .Throws<InvalidOperationException>();

            var secondServer = new Mock<IServer<long?>>();
            secondServer.SetupSequence(s => s.GetNext())
                .Returns(1)
                .Returns(null)
                .Throws<InvalidOperationException>();

            var expectedSequence = new long[] { -20, 1, 10 };

            var mockWriter = new Mock<IWriter<long?>>();

            var actualWritten = new List<long?>();
            mockWriter.Setup(w => w.Write(It.IsAny<long?>())).Callback<long?>(actualWritten.Add);

            var servers = new[] { firstServer.Object, secondServer.Object };

            var sut = new MultiServerSorter<long?>(mockWriter.Object, NullableLongComparer.Default);
            sut.Sort(servers);

            actualWritten.ShouldBeEquivalentTo(expectedSequence);
        }

        [Fact]
        public void GivenLargeGapBetweenNumberSequencesOnDifferentServers_ExpectSequenceInCorrectOrder()
        {
            var firstServer = new Mock<IServer<long?>>();
            firstServer.SetupSequence(s => s.GetNext())
                .Returns(-20)
                .Returns(10)
                .Returns(null)
                .Throws<InvalidOperationException>();

            var secondServer = new Mock<IServer<long?>>();
            secondServer.SetupSequence(s => s.GetNext())
                .Returns(1)
                .Returns(3)
                .Returns(5)
                .Returns(null)
                .Throws<InvalidOperationException>();

            var expectedSequence = new long[] { -20, 1, 3, 5, 10 };

            var mockWriter = new Mock<IWriter<long?>>();

            var actualWritten = new List<long?>();
            mockWriter.Setup(w => w.Write(It.IsAny<long?>())).Callback<long?>(actualWritten.Add);

            var servers = new[] { firstServer.Object, secondServer.Object };

            var sut = new MultiServerSorter<long?>(mockWriter.Object, NullableLongComparer.Default);
            sut.Sort(servers);

            actualWritten.ShouldBeEquivalentTo(expectedSequence);
        }
    }
}
