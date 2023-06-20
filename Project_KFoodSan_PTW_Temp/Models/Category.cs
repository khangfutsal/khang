using System;
using System.Collections.Generic;

namespace Project_KFoodSan_PTW_Temp.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public string? Img { get; set; }

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
}
