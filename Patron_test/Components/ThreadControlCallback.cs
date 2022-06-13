namespace Patron_test.Components
{
    public class ThreadControlCallback
    {

        public bool HasReaded { get; set; } = false;
        public object Locker { get; set; } = new();

        public string Value { get; set; }

        public ThreadControlCallback(string incValue)
        {
            Value = incValue;
        }
    }
}
