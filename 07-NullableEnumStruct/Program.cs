using System;

// ---------------- ENUMS ----------------
enum DrinkType { Coffee, Tea, Juice, Water }
enum DrinkSize { Small, Medium, Large }
enum OrderStatus { New, Preparing, Ready, Delivered }

// ---------------- CLASS ----------------
class DrinkOrder
{
    public int OrderNumber;
    public string CustomerName;
    public DrinkType Drink;
    public DrinkSize Size;
    public OrderStatus Status;
    public decimal Price;

    // Constructor
    public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
    {
        this.OrderNumber = orderNumber;
        this.CustomerName = customerName;
        this.Drink = drink;
        this.Size = size;
        this.Status = OrderStatus.New;
        this.Price = CalculatePrice();
    }

    // Qiymət hesablayan metod
    public decimal CalculatePrice()
    {
        switch (Drink)
        {
            case DrinkType.Coffee:
                switch (Size)
                {
                    case DrinkSize.Small: return 3;
                    case DrinkSize.Medium: return 4;
                    case DrinkSize.Large: return 5;
                }
                break;

            case DrinkType.Tea:
                switch (Size)
                {
                    case DrinkSize.Small: return 2;
                    case DrinkSize.Medium: return 3;
                    case DrinkSize.Large: return 4;
                }
                break;

            case DrinkType.Juice:
                switch (Size)
                {
                    case DrinkSize.Small: return 4;
                    case DrinkSize.Medium: return 5;
                    case DrinkSize.Large: return 6;
                }
                break;

            case DrinkType.Water:
                switch (Size)
                {
                    case DrinkSize.Small: return 1;
                    case DrinkSize.Medium: return 1.5m;
                    case DrinkSize.Large: return 2;
                }
                break;
        }
        return 0;
    }

    // Statusu yeniləyir
    public void UpdateStatus(OrderStatus newStatus)
    {
        Status = newStatus;
        Console.WriteLine($"Sifariş #{OrderNumber} statusu: {Status}");
    }

    // Sifarişi göstərir
    public void DisplayOrder()
    {
        Console.WriteLine($"Sifariş #{OrderNumber} - Müştəri: {CustomerName}, İçki: {Drink}, Ölçü: {Size}, Qiymət: {Price}, Status: {Status}");
    }
}

// ---------------- PROGRAM ----------------
class Program
{
    static void Main()
    {
        // ---------------- 1. Sifarişlər ----------------
        DrinkOrder order1 = new DrinkOrder(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
        DrinkOrder order2 = new DrinkOrder(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
        DrinkOrder order3 = new DrinkOrder(103, "Vüqar", DrinkType.Juice, DrinkSize.Small);

        // Order 1
        order1.DisplayOrder();
        order1.UpdateStatus(OrderStatus.Preparing);
        order1.UpdateStatus(OrderStatus.Ready);
        order1.UpdateStatus(OrderStatus.Delivered);

        Console.WriteLine();

        // Order 2
        order2.DisplayOrder();
        order2.UpdateStatus(OrderStatus.Ready);

        Console.WriteLine();

        // Order 3
        order3.DisplayOrder();

        Console.WriteLine("\n--- Enum dəyərləri ---");
        // ---------------- 2. Enum metodları ----------------
        Console.WriteLine("DrinkType:");
        foreach (var dt in Enum.GetValues(typeof(DrinkType)))
            Console.WriteLine(dt);

        Console.WriteLine("DrinkSize:");
        foreach (var ds in Enum.GetValues(typeof(DrinkSize)))
            Console.WriteLine(ds);

        Console.WriteLine("OrderStatus:");
        foreach (var os in Enum.GetValues(typeof(OrderStatus)))
            Console.WriteLine(os);

        // ToString
        Console.WriteLine("\nToString nümunələri:");
        Console.WriteLine(DrinkType.Coffee.ToString());
        Console.WriteLine(DrinkSize.Large.ToString());

        // Parse
        DrinkType parsedDrink = (DrinkType)Enum.Parse(typeof(DrinkType), "Tea");
        DrinkSize parsedSize = (DrinkSize)Enum.Parse(typeof(DrinkSize), "Medium");
        Console.WriteLine($"Parsed: {parsedDrink}, {parsedSize}");

        // ---------------- 3. Statistikalar ----------------
        Console.WriteLine("\n--- Statistikalar ---");
        Console.WriteLine($"Ümumi sifariş sayı: 3");
        Console.WriteLine($"Birinci sifarişin qiyməti: {order1.Price}");
        Console.WriteLine($"İkinci sifarişin qiyməti: {order2.Price}");
        Console.WriteLine($"Üçüncü sifarişin qiyməti: {order3.Price}");

        decimal total = order1.Price + order2.Price + order3.Price;
        Console.WriteLine($"Ümumi məbləğ: {total}");
    }
}
