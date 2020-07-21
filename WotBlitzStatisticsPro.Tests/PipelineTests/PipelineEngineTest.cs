using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using WotBlitzStatisticsPro.Logic.Pipeline;
using FluentAssertions;

namespace WotBlitzStatisticsPro.Tests.PipelineTests
{
    [TestFixture]
    public class PipelineEngineTest
    {
        private readonly Mock<IOperationFactory> _operationFactoryMock = new Mock<IOperationFactory>();
        private readonly Mock<FirstTestOperation> _firstOperationMock = new Mock<FirstTestOperation>();
        private readonly Mock<SecondTestOperation> _secondOperationMock = new Mock<SecondTestOperation>();

        [SetUp]
        public void Init()
        {
            _operationFactoryMock.Setup(f => f.Create<TestContext>(typeof(FirstTestOperation)))
                .Returns(_firstOperationMock.Object);
            _operationFactoryMock.Setup(f => f.Create<TestContext>(typeof(SecondTestOperation)))
                .Returns(_secondOperationMock.Object);
        }

        [Test]
        public async Task PipelineShouldBeBuiltAndInvokedCorrectly()
        {
            var context = new TestContext();
            var pipeline = new Pipeline<TestContext>(_operationFactoryMock.Object);

            pipeline.AddOperation<FirstTestOperation>()
                .AddOperation<SecondTestOperation>();

            var callsSequence = new List<Type>();

            _firstOperationMock.Setup(f => f.Invoke(context, It.IsAny<Func<TestContext, Task>>()))
                .Callback((TestContext c, Func<TestContext, Task> n) => callsSequence.Add(typeof(FirstTestOperation)))
                .Returns((TestContext c, Func<TestContext, Task> n) => n.Invoke(c));
            _secondOperationMock.Setup(f => f.Invoke(context, It.IsAny<Func<TestContext, Task>>()))
                .Callback((TestContext c, Func<TestContext, Task> n) => callsSequence.Add(typeof(SecondTestOperation)));

            await pipeline.Build()
                .Invoke(context, null)
                .ConfigureAwait(false);

            // Check if first operation called first and only once. And second called second and once
            _firstOperationMock.Verify(f => f.Invoke(context, It.IsAny<Func<TestContext, Task>>()), Times.Once);
            _secondOperationMock.Verify(f => f.Invoke(context, It.IsAny<Func<TestContext, Task>>()), Times.Once);
            callsSequence.Count.Should().Be(2);
            callsSequence[0].Should().Be(typeof(FirstTestOperation));
            callsSequence[1].Should().Be(typeof(SecondTestOperation));
        }

        [Test]
        public async Task PipelineShouldStopIfFirstTaskDoesNotCallNext()
        {
            var context = new TestContext();
            var pipeline = new Pipeline<TestContext>(_operationFactoryMock.Object);

            pipeline.AddOperation<FirstTestOperation>()
                .AddOperation<SecondTestOperation>();

            var callsSequence = new List<Type>();

            _firstOperationMock.Setup(f => f.Invoke(context, It.IsAny<Func<TestContext, Task>>()))
                .Callback((TestContext c, Func<TestContext, Task> n) => callsSequence.Add(typeof(FirstTestOperation)))
                .Returns(Task.CompletedTask);
            _secondOperationMock.Setup(f => f.Invoke(context, It.IsAny<Func<TestContext, Task>>()))
                .Callback((TestContext c, Func<TestContext, Task> n) => callsSequence.Add(typeof(SecondTestOperation)));

            await pipeline.Build()
                .Invoke(context, null)
                .ConfigureAwait(false);

            // Check if first operation called first and only once. And second did not call
            _firstOperationMock.Verify(f => f.Invoke(context, It.IsAny<Func<TestContext, Task>>()), Times.Once);
            _secondOperationMock.Verify(f => f.Invoke(context, It.IsAny<Func<TestContext, Task>>()), Times.Never);
            callsSequence.Count.Should().Be(1);
            callsSequence[0].Should().Be(typeof(FirstTestOperation));
        }

    }
}