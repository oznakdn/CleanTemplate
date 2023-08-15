﻿namespace Clean.Domain.Entities;

public class Product : Entity<Guid>
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

}
