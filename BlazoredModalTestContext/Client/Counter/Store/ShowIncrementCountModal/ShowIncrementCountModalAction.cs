namespace BlazoredModalTestContext.Client.Counter.Store.ShowIncrementCountModal
{
    public class ShowIncrementCountModalAction
    {
        public ShowIncrementCountModalAction(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}