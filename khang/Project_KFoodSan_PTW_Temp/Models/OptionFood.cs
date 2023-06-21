using System;
using System.Collections.Generic;

namespace Project_KFoodSan_PTW_Temp.Models;

public partial class OptionFood
{
    public int Id { get; set; }

    public string? OptionFoodName { get; set; }

    public double? Price { get; set; }

    public int? FoodId { get; set; }

    public virtual Food? Food { get; set; }
}
