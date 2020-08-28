namespace SummerPractice1.Core
{
    public enum OperationCodes
    {
        None = -1,
        LoadFromFile = 1,
        SaveToFile = 2,
        Add = 3,
        AddOrder = 1,
        AddProduct = 2,
        AddRelation = 3,
        AddBack = 4,
        Print = 4,
        PrintOrders = 1,
        PrintProducts = 2,
        PrintByOrder = 3,
        PrintByProduct = 4,
        PrintBack = 5,
        Delete = 5,
        DeleteOrder = 1,
        DeleteProduct = 2,
        DeleteBack = 3,
        SortOrders = 6,
        SortOrdersOrd = 1,
        SortOrdersShip = 2,
        SortOrdersBack = 3,
        SortProducts = 7,
        SortProductsPrice = 1,
        SortProductsWeight = 2,
        SortProductsBack = 3,
        Quit = 8
    }
}
