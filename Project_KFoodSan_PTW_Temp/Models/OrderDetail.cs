using System;
using System.Collections.Generic;

namespace Project_KFoodSan_PTW_Temp.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public double? Price { get; set; }

    public int? Quantity { get; set; }

    public int? OrderBookId { get; set; }

    public int? FoodId { get; set; }

    public virtual Food? Food { get; set; }

    public virtual OrderBook? OrderBook { get; set; }
}
