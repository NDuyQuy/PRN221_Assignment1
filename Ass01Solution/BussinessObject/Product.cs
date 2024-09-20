using System;
using System.Collections.Generic;

namespace BussinessObject;

public partial class Product
{
    public int ProductId { get; set; }

    public int? CategoryId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Weight { get; set; } = null!;

    public string UnitPrice { get; set; } = null!;

    public int UnitsInStock { get; set; }

    public virtual Category? Category { get; set; }

    public override string ToString() => $"ProductId: {ProductId}\n" +
               $"CategoryId: {(CategoryId.HasValue ? CategoryId.Value.ToString() : "null")}\n" +
               $"ProductName: {ProductName}\n" +
               $"Weight: {Weight}\n" +
               $"UnitPrice: {UnitPrice}\n" +
               $"UnitsInStock: {UnitsInStock}\n" +
               $"Category: {(Category != null ? Category.CategoryName : "null")}";

}
