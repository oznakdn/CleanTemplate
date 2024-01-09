namespace Clean.WebRazorPages;



public class EndPoints
{
    public Auth Auth { get; set; }
    public Account Account { get; set; }
    public Product Product { get; set; }
    public Customer Customer { get; set; }
    public Basket Basket { get; set; }
    public Order Order { get; set; }

}


public class Auth
{
    public string Register { get; set; }
    public string Login { get; set; }
    public string CreateRole { get; set; }
    public string GetRoles { get; set; }
    public string AssignRole { get; set; }

}

public class Account
{
    public string Register { get; set; }
    public string Login { get; set; }
}



public class Product
{
    public string GetProducts { get; set; }
    public string GetProductsCache { get; set; }
    public string GetProductDetail { get; set; }
    public string GetProductsWithDataShaping { get; set; }
    public string CreateProduct { get; set; }
    public string UpdateProduct { get; set; }

}

public class Customer
{
    public string GetCustomer { get; set; }
    public string GetCustomers { get; set; }
    public string GetCustomerBasket { get; set; }
}

public class Basket
{
    public string AddBasketItem { get; set; }
    public string RemoveBasketItem { get; set; }
    public string UpdateBasketItem { get; set; }
}

public class Order
{
    public string CreateOrder { get; set; }
    public string GetCustomerOrders { get; set; }
}
