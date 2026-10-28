namespace Task9_txt_file;

public class Menu
{
    string path = @"C:\Users\User\OneDrive\Desktop\Task9 txt file\Task9 txt file\Data\Product.txt";

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Register Product\n2. Show All Products\n3. Find Product by ID\n4. Sort Products by Price\n0. Exit");
            string choice = Console.ReadLine()?.Trim();

            if (choice == "0")
            {
                break;
            }

            switch (choice)
            {
                case "1":
                    var productLines = File.ReadAllLines(path).ToList();
                    int newID = 1;

                    if (productLines.Any(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        newID = productLines.Where(x => !string
                                             .IsNullOrWhiteSpace(x))
                                            .Max(x => int.Parse(x.Split('|')[0])) + 1;
                    }

                    Product product = new Product();
                    product.Id = newID;
                    
                    Console.WriteLine("Enter Name:");
                    product.Name = Console.ReadLine();
                    Console.WriteLine("Enter Price:");
                    product.Price = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Description:");
                    product.Description = Console.ReadLine();
                    File.AppendAllLines(path, [product.ToString()]);
                    Console.WriteLine("\nProduct added successfully!");
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    break;

                case "2":
                    var allProducts = File.ReadAllLines(path).ToList();

                    if (!allProducts.Any(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        Console.WriteLine("\nNo products found.");
                    }
                    else
                    {
                        Console.WriteLine("\n--- All Products ---");
                        foreach (var item in allProducts)
                        {
                            if (string.IsNullOrWhiteSpace(item)) continue;
                            Console.WriteLine(item);
                        }
                    }
                    
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    break;

                case "3":
                 Console.WriteLine("Enter ID to search:"); 
                 string searchId = Console.ReadLine()?.Trim();
                 var productIdList = File.ReadAllLines(path).ToList();
                 bool isFound = false;

                    foreach (var item in productIdList)
                    {
                        if (string.IsNullOrWhiteSpace(item)) continue;

                        if (item.Split('|')[0].Trim() == searchId)
                        {
                            isFound = true;
                            Console.WriteLine("\n--- Result ---");
                            Console.WriteLine(item);
                            break;
                        }
                    }

                    if (!isFound)
                    {
                        Console.WriteLine("\nId not found.");
                    }
                    
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    break;

                case "4":
                    var sortProducts = File.ReadAllLines(path).ToList();

                    if (!sortProducts.Any(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        Console.WriteLine("\nNo products found.");
                    }
                    else
                    {
                        Console.WriteLine("\n--- Sorted Products ---");
                        var sortedList = sortProducts.Where(x => !string.IsNullOrWhiteSpace(x))
                                                     .OrderBy(x => decimal.Parse(x.Split('|')[2]))
                                                     .ToList();
                        
                        foreach (var item in sortedList)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("\nInvalid option, try again.");
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}