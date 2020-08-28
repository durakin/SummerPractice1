using System;
using System.Collections.Generic;
using SummerPractice1.Core;

namespace SummerPractice1.Main
{
    class Program
    {
        static int CustomIntInput(Func<int, bool> inputCheck)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var result))
                {
                    if (inputCheck(result))
                    {
                        return result;
                    }
                }

                Console.WriteLine("Wrong format!");
            }
        }


        static Product ProductByName(List<Product> products, string name)
        {
            return products.Find(u => u.Name == name);
        }

        static void AddProduct(List<Product> products, string name, int price, int weight)
        {
            if (ProductByName(products, name) != null)
            {
                Console.WriteLine("Such product already exists!");
                return;
            }

            products.Add(new Product(name, price, weight));
            Console.WriteLine("Added!");
        }

        static void DeleteProduct(List<Product> products, List<Order> orders, string name)
        {
            products.RemoveAll(u => u.Name == name);
            foreach (var i in orders)
            {
                i.Content.RemoveAll(u => u.Name == name);
            }
        }

        static string AllProductsToString(List<Product> products)
        {
            var result = "";
            foreach (var VARIABLE in products)
            {
                result += VARIABLE.ToString();
            }

            return result;
        }

        static bool MainMenuInputChecker(int intToCheck)
        {
            return intToCheck >= (int) OperationCodes.LoadFromFile
                   && intToCheck <= (int) OperationCodes.Quit;
        }

        static bool AddMenuInputChecker(int intToCheck)
        {
            return intToCheck >= (int) OperationCodes.AddOrder
                   && intToCheck <= (int) OperationCodes.AddBack;
        }

        static bool PrintMenuInputChecker(int intToCheck)
        {
            return intToCheck >= (int) OperationCodes.PrintOrders
                   && intToCheck <= (int) OperationCodes.PrintBack;
        }

        static bool DeleteMenuInputChecker(int intToCheck)
        {
            return intToCheck >= (int) OperationCodes.DeleteOrder
                   && intToCheck <= (int) OperationCodes.DeleteBack;
        }

        static bool SortOrdersMenuInputChecker(int intToCheck)
        {
            return intToCheck >= (int) OperationCodes.SortOrdersOrd
                   && intToCheck <= (int) OperationCodes.SortOrdersBack;
        }

        static bool SortProductsMenuInputChecker(int intToCheck)
        {
            return intToCheck >= (int) OperationCodes.SortProductsPrice
                   && intToCheck <= (int) OperationCodes.SortProductsBack;
        }

        static bool PositiveIntInputChecker(int intToCheck)
        {
            return intToCheck >= 0;
        }

        static void Main(string[] args)
        {
            var operationCode = 0;
            var suboperationCode = 0;
            var Products = new List<Product>();
            var Orders = new List<Order>();

            while (operationCode != (int) OperationCodes.Quit)
            {
                Console.Write("\n1. Load data from savefile.\n" +
                              "2. Save current data to savefile.\n" +
                              "3. Add new element.\n" +
                              "4. Print information.\n" +
                              "5. Delete elements.\n" +
                              "6. Sort orders.\n" +
                              "7. Sort products.\n" +
                              "8. Quit without saving.\n\n");

                operationCode = CustomIntInput(MainMenuInputChecker);

                if (operationCode == (int) OperationCodes.Add)
                {
                    /*if (suboperationCode == (int) OperationCodes.AddOrder)
                    {
                        Console.WriteLine("Enter ");
                    }
                    */
                    Console.Write("\n1. Add order." +
                                  "\n2. Add product." +
                                  "\n3. Add relation." +
                                  "\n4. Back.\n");
                    suboperationCode = CustomIntInput(AddMenuInputChecker);
                    if (suboperationCode == (int) OperationCodes.AddProduct)
                    {
                        Console.WriteLine("Enter product's name");
                        var name = Console.ReadLine();
                        Console.WriteLine("Enter product's price");
                        var price = CustomIntInput(PositiveIntInputChecker);
                        Console.WriteLine("Enter product's weight");
                        var weight = CustomIntInput(PositiveIntInputChecker);
                        AddProduct(Products, name, price, weight);
                    }
                }

                if (operationCode == (int) OperationCodes.Print)
                {
                    suboperationCode = CustomIntInput(PrintMenuInputChecker);
                    Console.Write("\n1. Print all orders." +
                                  "\n2. Print all products." +
                                  "\n3. Print order's content." +
                                  "\n4. Print product's related" +
                                  "orders.\n5. Back.\n");
                    if (suboperationCode == (int) OperationCodes.PrintProducts)
                    {
                        Console.WriteLine(AllProductsToString(Products));
                    }
                }

                if (operationCode == (int) OperationCodes.Delete)
                {
                    Console.Write("\n1. Delete order.\n" +
                                  "2. Delete product.\n" +
                                  "3.Back\n");
                    suboperationCode = CustomIntInput(DeleteMenuInputChecker);
                    if (suboperationCode == (int) OperationCodes.DeleteProduct)
                    {
                        var name = Console.ReadLine();
                        DeleteProduct(Products, Orders, name);
                    }
                }
            }
        }
    }
}