using BlazoredModalTestContext.Client.Counter.Store.IncrementCount;
using Bunit;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace BlazoredModalTestContext.Client.Counter.Components.Modals
{
    public class IncrementCountModalTests : BlazoredModalTestContext
    {
        private readonly Mock<IDispatcher> dispatcherMock = new();

        public IncrementCountModalTests()
        {
            Services.AddSingleton(dispatcherMock.Object);
        }

        [Fact]
        public void Failing_SubmitOnValidFormAsync_ShouldDispatchTheActionWithTheIncrement()
        {
            var cut = RenderComponent<IncrementCountModal>();

            var incrementInput = cut.Find("input");
            incrementInput.Change(new ChangeEventArgs() { Value = "5" });

            var form = cut.Find("form");
            form.Submit();

            dispatcherMock.Verify(d => 
                d.Dispatch(It.Is<IncrementCountAction>(a => a.Increment == 5)));
        }

        [Fact]
        public void Working_SubmitOnValidFormAsync_ShouldDispatchTheActionWithTheIncrement()
        {
            var cut = RenderModalComponentInsideCascadingBlazoredModal<IncrementCountModal>();

            var incrementInput = cut.Find("input");
            incrementInput.Change(new ChangeEventArgs() {Value = "5" });

            var form = cut.Find("form");
            form.Submit();

            dispatcherMock.Verify(d => 
                d.Dispatch(It.Is<IncrementCountAction>(a => a.Increment == 5)));
        }
    }
}