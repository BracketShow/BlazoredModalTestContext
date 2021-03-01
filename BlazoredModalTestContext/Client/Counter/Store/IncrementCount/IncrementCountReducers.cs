using Fluxor;

namespace BlazoredModalTestContext.Client.Counter.Store.IncrementCount
{
    public static class IncrementCountReducers
    {
        [ReducerMethod]
        public static CounterState ReduceIncrementCountAction(CounterState state, IncrementCountAction action) =>
            new(state.ClickCount + action.Increment);
    }
}