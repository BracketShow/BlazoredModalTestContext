using Fluxor;

namespace BlazoredModalTestContext.Client.Counter.Store
{
    public class CounterFeature : Feature<CounterState>
    {
        public override string GetName() => "Coutner";

        protected override CounterState GetInitialState() => new(0);
    }
}