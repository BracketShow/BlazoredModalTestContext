using BlazoredModalTestContext.Client.Counter.Store;
using BlazoredModalTestContext.Client.Counter.Store.ShowIncrementCountModal;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazoredModalTestContext.Client.Counter.Pages
{
    public partial class Counter
    {
        [Inject]
        private IState<CounterState> CounterState { get; set; }

        [Inject]
        private IDispatcher Dispatcher { get; set; }
        
        private void OpenIncrementCountModal()
        {
            Dispatcher.Dispatch(new ShowIncrementCountModalAction("Increment counter"));
        }
    }
}
