namespace BlazoredModalTestContext.Client.Counter.Store
{
    public class CounterState
    {
        public CounterState(int clickCount)
        {
            ClickCount = clickCount;
        }

        public int ClickCount { get; }
    }
}