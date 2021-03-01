namespace BlazoredModalTestContext.Client.Counter.Store.IncrementCount
{
    public class IncrementCountAction
    {
        public IncrementCountAction(int increment)
        {
            Increment = increment;
        }

        public int Increment { get; }
    }
}