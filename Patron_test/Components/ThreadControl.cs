namespace Patron_test.Components
{
    public class ThreadControl
    {
        public Dictionary<string, object> Tasks = new Dictionary<string, object>();

        public object GetThreadControlCallback(string filename)
        {
            object value;
            lock (Tasks)
            {
                if (Tasks.ContainsKey(filename))
                {
                    value = Tasks[filename];
                }
                else
                {
                    object o = new();
                    Tasks.Add(filename, o);
                    value = o;
                }
            }
            return value;
        }
    }
}
