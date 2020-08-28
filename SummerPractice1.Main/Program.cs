using System;
using System.Collections.Generic;

using SummerPractice1.Core;

namespace SummerPractice1.Main
{
    internal class Program
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
            products.RemoveAll(u => u.Name == name);
            foreach (var i in orders)
            {
                i.Content.RemoveAll(u => u.Name == name);
            }
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
                                throw new NotImplementedException();
                            case AddSuboperationCodes.AddRelation:
                                throw new NotImplementedException();
                            case AddSuboperationCodes.AddBack:
                                throw new NotImplementedException();
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
                                throw new NotImplementedException();
                            case PrintSuboperationCodes.PrintByOrder:
                                throw new NotImplementedException();
                            case PrintSuboperationCodes.PrintByProduct:
                                throw new NotImplementedException();
                            case PrintSuboperationCodes.PrintBack:
                                throw new NotImplementedException();
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
                                throw new NotImplementedException();
                            case DeleteSuboperationCodes.DeleteProduct:
                                var name = Console.ReadLine();
                                DeleteProduct(Products, Orders, name);
                                break;
                            case DeleteSuboperationCodes.DeleteBack:
                                throw new NotImplementedException();
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