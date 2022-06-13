namespace Patron_test.Components
{
    public class ThreadControl
    {
        public Dictionary<string, ThreadControlCallback> Tasks = new Dictionary<string, ThreadControlCallback>();

        public ThreadControlCallback GetThreadControlCallback(string filename)
        {
            ThreadControlCallback value;
            lock (Tasks)
            {
                if (Tasks.ContainsKey(filename))
                {
                    value = Tasks[filename];
                }
                else
                {
                    ThreadControlCallback tcc = new(filename);
                    Tasks.Add(filename, tcc);
                    value = tcc;
                }
            }
            return value;
        }
    }
}
