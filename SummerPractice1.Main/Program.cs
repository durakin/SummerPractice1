using System;
using System.Collections.Generic;
using SummerPractice1.Core;

namespace SummerPractice1.Main
{
    internal static class Program
    {
        private static int CustomIntInput(Func<int, bool> inputCheck)
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out var result))
                {
                    if (inputCheck(result))
                    {
                        return result;
                    }
                }

                Console.WriteLine("Wrong format!");
            }
        }

        private static DateTime CustomDateInput()
        {
            while (true)
            {
                try
                {
                    var result = DateTime.Parse(Console.ReadLine());
                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong format!");
                }
            }
        }

        private static Product ProductByName(List<Product> products, string name)
        {
            return products.Find(u => u.Name == name);
        }

        private static void AddProduct(List<Product> products, string name, int price, int weight)
        {
            if (ProductByName(products, name) != null)
            {
                Console.WriteLine("Such product already exists!");
                return;
            }

            products.Add(new Product(name, price, weight));
            Console.WriteLine("Added!");
        }

        private static void DeleteProduct(List<Product> products, List<Order> orders, string name)
        {
            if (products.RemoveAll(u => u.Name == name) == 0)
            {
                Console.WriteLine("No such product");
                return;
            }

            foreach (var i in orders)
            {
                i.Content.RemoveAll(u => u.Name == name);
            }

            Console.WriteLine("Deleted!");
        }

        private static string AllProductsToString(List<Product> products)
        {
            var result = "";
            foreach (var i in products)
            {
                result += i.ToString();
            }

            return result;
        }

        private static Order OrderByOwner(List<Order> orders, string owner)
        {
            return orders.Find(u => u.Owner == owner);
        }

        private static void AddOrder(List<Order> orders, string owner, DateTime orderDate, DateTime shipmentDate)
        {
            if (OrderByOwner(orders, owner) != null)
            {
                Console.WriteLine("Order with such owner already exists!");
                return;
            }

            orders.Add(new Order(owner, orderDate, shipmentDate));
            Console.WriteLine("Added!");
        }

        private static void DeleteOrder(List<Order> orders, string owner)
        {
            orders.RemoveAll(u => u.Owner == owner);
            Console.WriteLine("Deleted!");
        }

        private static string AllOrdersToString(List<Order> orders)
        {
            var result = "";
            foreach (var i in orders)
            {
                result += i.ToString();
            }

            return result;
        }

        private static void AddRelation(List<Product> products, List<Order> orders, string productName, string orderOwner)
        {
            if (ProductByName(products, productName) == null)
            {
                Console.WriteLine("No such product!");
                return;
            }

            if (OrderByOwner(orders, orderOwner) == null)
            {
                Console.WriteLine("No such order!");
                return;
            }

            OrderByOwner(orders, orderOwner).Content.Add(ProductByName(products, productName));
            Console.WriteLine("Added!");
        }

        private static void DeleteRelation(List<Product> products, List<Order> orders, string productName,
            string orderOwner)
        {
            if (OrderByOwner(orders, orderOwner).Content.Remove(ProductByName(products, productName)))
            {
                Console.WriteLine("Deleted!");
            }
            else
            {
                Console.WriteLine("No such relation!");
            }
        }

        private static string OrderContentToString(Order order)
        {
            var result = "";
            if (order.Content.Count == 0)
            {
                result = "No products in order!";
            }

            foreach (var i in order.Content)
            {
                result += i + "\n";
            }

            return result;
        }

        private static string ProductReferencesToString(Product product, List<Order> orders)
        {
            var result = "";
            foreach (var i in orders)
            {
                if (i.Content.Contains(product))
                {
                    result += i + "\n";
                }
            }

            if (result == "")
            {
                result = "No references to product";
            }

            return result;
        }
        
        private static bool MainMenuInputChecker(int intToCheck) =>
            intToCheck >= (int) OperationCodes.LoadFromFile
            && intToCheck <= (int) OperationCodes.Quit;

        private static bool AddMenuInputChecker(int intToCheck) =>
            intToCheck >= (int) AddSuboperationCodes.AddOrder
            && intToCheck <= (int) AddSuboperationCodes.AddBack;

        private static bool PrintMenuInputChecker(int intToCheck) =>
            intToCheck >= (int) PrintSuboperationCodes.PrintOrders
            && intToCheck <= (int) PrintSuboperationCodes.PrintBack;

        private static bool DeleteMenuInputChecker(int intToCheck) =>
            intToCheck >= (int) DeleteSuboperationCodes.DeleteOrder
            && intToCheck <= (int) DeleteSuboperationCodes.DeleteBack;

        private static bool SortOrdersMenuInputChecker(int intToCheck) =>
            intToCheck >= (int) SortOrdersSuboperationCodes.SortOrdersOrd
            && intToCheck <= (int) SortOrdersSuboperationCodes.SortOrdersBack;

        private static bool SortProductsMenuInputChecker(int intToCheck) =>
            intToCheck >= (int) SortProductsSuboperationCodes.SortProductsPrice
            && intToCheck <= (int) SortProductsSuboperationCodes.SortProductsBack;

        private static bool PositiveIntInputChecker(int intToCheck) => intToCheck >= 0;

        private static void Main(string[] args)
        {
            var operationCode = OperationCodes.None;
            var Products = new List<Product>();
            var Orders = new List<Order>();

            while (operationCode != OperationCodes.Quit)
            {
                Console.WriteLine();
                Console.WriteLine("1. Load data from savefile.");
                Console.WriteLine("2. Save current data to savefile.");
                Console.WriteLine("3. Add new element.");
                Console.WriteLine("4. Print information.");
                Console.WriteLine("5. Delete elements.");
                Console.WriteLine("6. Sort orders.");
                Console.WriteLine("7. Sort products.");
                Console.WriteLine("8. Quit without saving.");
                Console.WriteLine();

                operationCode = (OperationCodes) CustomIntInput(MainMenuInputChecker);

                switch (operationCode)
                {
                    case OperationCodes.Add:
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. Add order.");
                        Console.WriteLine("2. Add product.");
                        Console.WriteLine("3. Add relation.");
                        Console.WriteLine("4. Back.");
                        Console.WriteLine();

                        var suboperationCode = (AddSuboperationCodes) CustomIntInput(AddMenuInputChecker);

                        switch (suboperationCode)
                        {
                            case AddSuboperationCodes.AddProduct:
                            {
                                Console.WriteLine("Enter product's name");
                                var name = Console.ReadLine();
                                Console.WriteLine("Enter product's price");
                                var price = CustomIntInput(PositiveIntInputChecker);
                                Console.WriteLine("Enter product's weight");
                                var weight = CustomIntInput(PositiveIntInputChecker);
                                AddProduct(Products, name, price, weight);
                                break;
                            }
                            case AddSuboperationCodes.AddOrder:
                            {
                                Console.WriteLine("Enter owner's name");
                                var owner = Console.ReadLine();
                                Console.WriteLine("Enter date of order");
                                var dateOfOrder = CustomDateInput();
                                Console.WriteLine("Enter date of shipment");
                                var dateOfShipment = CustomDateInput();
                                AddOrder(Orders, owner, dateOfOrder, dateOfShipment);
                                break;
                            }
                            case AddSuboperationCodes.AddRelation:
                            {
                                Console.WriteLine("Enter product's name");
                                var name = Console.ReadLine();
                                Console.WriteLine("Enter owner's name");
                                var owner = Console.ReadLine();
                                AddRelation(Products, Orders, name, owner);
                                break;
                            }
                            case AddSuboperationCodes.AddBack:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    }
                    case OperationCodes.Print:
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. Print all orders.");
                        Console.WriteLine("2. Print all products.");
                        Console.WriteLine("3. Print order's content.");
                        Console.WriteLine("4. Print product's related orders.");
                        Console.WriteLine("5. Back.");
                        Console.WriteLine();

                        var suboperationCode = (PrintSuboperationCodes) CustomIntInput(PrintMenuInputChecker);

                        switch (suboperationCode)
                        {
                            case PrintSuboperationCodes.PrintProducts:
                            {
                                Console.WriteLine(AllProductsToString(Products));
                                break;
                            }
                            case PrintSuboperationCodes.PrintOrders:
                            {
                                Console.WriteLine(AllOrdersToString(Orders));
                                break;
                            }
                            case PrintSuboperationCodes.PrintByOrder:
                            {
                                Console.WriteLine("Enter owner's name");
                                var owner = Console.ReadLine();
                                Console.WriteLine(OrderContentToString(OrderByOwner(Orders, owner)));
                                break;
                            }
                            case PrintSuboperationCodes.PrintByProduct:
                            {
                                Console.WriteLine("Enter product's name");
                                var name = Console.ReadLine();
                                Console.WriteLine(ProductReferencesToString(ProductByName(Products, name), Orders));
                                break;
                            }
                            case PrintSuboperationCodes.PrintBack:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    }
                    case OperationCodes.Delete:
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. Delete order");
                        Console.WriteLine("2. Delete product.");
                        Console.WriteLine("3. Back");
                        Console.WriteLine();

                        var suboperationCode = (DeleteSuboperationCodes) CustomIntInput(DeleteMenuInputChecker);

                        switch (suboperationCode)
                        {
                            case DeleteSuboperationCodes.DeleteOrder:
                            {
                                Console.WriteLine("Enter owner's name");
                                var owner = Console.ReadLine();
                                DeleteOrder(Orders, owner);
                                break;
                            }
                            case DeleteSuboperationCodes.DeleteProduct:
                                Console.WriteLine("Enter product's name");
                                var name = Console.ReadLine();
                                DeleteProduct(Products, Orders, name);
                                break;
                            case DeleteSuboperationCodes.DeleteBack:
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    }
                    case OperationCodes.LoadFromFile:
                        throw new NotImplementedException();
                    case OperationCodes.SaveToFile:
                        throw new NotImplementedException();
                    case OperationCodes.SortOrders:
                        throw new NotImplementedException();
                    case OperationCodes.SortProducts:
                        throw new NotImplementedException();
                    case OperationCodes.Quit:
                        break;
                    case OperationCodes.None:
                        throw new ArgumentOutOfRangeException();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}