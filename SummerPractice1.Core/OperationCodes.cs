namespace SummerPractice1.Core
{
    public enum OperationCodes
    {
        None = -1,
        LoadFromFile = 1,
        SaveToFile = 2,
        Add = 3,
        Print = 4,
        Delete = 5,
        SortOrders = 6,
        SortProducts = 7,
        Quit = 8
    }

    public enum AddSuboperationCodes
    {
        AddOrder = 1,
        AddProduct = 2,
        AddRelation,
        AddBack
    }

    public enum PrintSuboperationCodes
    {
        PrintOrders = 1,
        PrintProducts = 2,
        PrintByOrder,
        PrintByProduct,
        PrintBack
    }

    public enum DeleteSuboperationCodes
    {
        DeleteOrder = 1,
        DeleteProduct = 2,
        DeleteBack
    }

    public enum SortOrdersSuboperationCodes
    {
        SortOrdersOrd = 1,
        SortOrdersShip = 2,
        SortOrdersBack = 3
    }

    public enum SortProductsSuboperationCodes
    {
        SortProductsPrice = 1,
        SortProductsWeight = 2,
        SortProductsBack = 3
    }
}