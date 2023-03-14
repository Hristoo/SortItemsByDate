using System.Linq;
using System.Text.Json.Nodes;

public class Program
{
    public static void Main(string[] args)
    {
        List<Item> items = new List<Item>()
        {
             new Item{ date="10.01.2017", dayOfWeek ="Tuesday" },
             new Item{ date="05.11.2016", dayOfWeek ="Saturday" },
             new Item{ date="21.13.2002", dayOfWeek ="Monday" }
        };

        Sort(items).ForEach(x => Console.WriteLine(x.date));
    }

    public static List<Item> Sort(List<Item> items)
    {
        List<Item> checkedItems = new List<Item>();

        items.ForEach(x =>
        {
            try
            {
                DateTime.Parse(x.date);
                checkedItems.Add(x);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Wrong date format '{x.date}'!");
            }
        });

        return checkedItems.OrderBy(x => DateTime.Parse(x.date)).ToList();
    }
}

public class Item
{
    public string date { get; init; }
    public string dayOfWeek { get; init; }
}