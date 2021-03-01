using System.Threading.Tasks;
using Blazored.Modal.Services;
using BlazoredModalTestContext.Client.Counter.Components.Modals;
using Fluxor;

namespace BlazoredModalTestContext.Client.Counter.Store.ShowIncrementCountModal
{
    public class ShowIncrementCountModalActionEffect
    {
        private readonly IModalService modalService;

        public ShowIncrementCountModalActionEffect(IModalService modalService)
        {
            this.modalService = modalService;
        }

        [EffectMethod]
        public Task HandleShowIncrementCountModalAction(ShowIncrementCountModalAction action, IDispatcher dispatcher)
        {
            modalService.Show<IncrementCountModal>("Enter increment");
            return Task.CompletedTask;
        }
    }
}