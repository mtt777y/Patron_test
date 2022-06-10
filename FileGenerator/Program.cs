
int iterator = 0;
string name = "";

while (true)
{
    Console.WriteLine("Write iteration...");
    try
    {
        iterator = Int32.Parse(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }

    Console.WriteLine("Write file name without txt...");
    try
    {
        name = Console.ReadLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }

    using (StreamWriter writer = new StreamWriter($"{name}.txt", false))
    {
        for (int i = 0; i < iterator; i++)
        {
            writer.WriteLine("hi");
            if(i%1000 == 0)
            {
                Console.WriteLine($"Save {i} rows");
            }
        }   
    }

    Console.WriteLine($"Complete");
}
