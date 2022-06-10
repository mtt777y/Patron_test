int iterator = 0;
int timaspan = 100;
List<string> files = new() {"lotr", "hello" ,"hola", "test1"};

while (true)
{
    Console.WriteLine("Write iteration (int)...");
    try
    {
        iterator = Int32.Parse(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }

    Console.WriteLine("Write timespan (int, ms)...");
    try
    {
        timaspan = Int32.Parse(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }

    //Console.WriteLine("Write file name without txt...");
    //try
    //{
    //    name = Console.ReadLine();
    //}
    //catch (Exception ex)
    //{
    //    Console.WriteLine(ex.Message);
    //    continue;
    //}

    for (int i = 0; i < iterator; i++)
    {
        foreach (var file in files)
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri($"http://localhost:5232/file?filename={file}.txt");
            Task.Run(() => {
                httpClient.GetAsync($"http://localhost:5232/file?filename={file}.txt");
                });
        }
        Task.Delay(timaspan).Wait();
    }

    Console.WriteLine($"Complete");
}