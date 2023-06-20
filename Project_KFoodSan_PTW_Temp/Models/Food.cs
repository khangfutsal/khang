using System;
using System.Collections.Generic;

namespace Project_KFoodSan_PTW_Temp.Models;

public partial class Food
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public string? Image { get; set; }

    public double? Discount { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<OptionFood> OptionFoods { get; set; } = new List<OptionFood>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
