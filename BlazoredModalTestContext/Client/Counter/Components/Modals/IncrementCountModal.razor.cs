using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.Modal;
using BlazoredModalTestContext.Client.Counter.Store.IncrementCount;
using Fluxor;

namespace BlazoredModalTestContext.Client.Counter.Components.Modals
{
    public partial class IncrementCountModal
    {
        [Inject]
        private IDispatcher Dispatcher { get; set; } = default!;

        [CascadingParameter]
        private BlazoredModalInstance ModalInstance { get; set; } = default!;

        private int increment = 0;

        public void SubmitOnValidFormAsync()
        {
            Dispatcher.Dispatch(new IncrementCountAction(increment));

            ModalInstance.CloseAsync();
        }
    }
}