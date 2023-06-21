using System;
using System.Collections.Generic;

namespace Project_KFoodSan_PTW_Temp.Models;

public partial class OrderBook
{
    public int Id { get; set; }

    public string? Note { get; set; }

    public TimeSpan? ReceivedAt { get; set; }

    public double? Total { get; set; }

    public int? Status { get; set; }

    public int? UserId { get; set; }

    public int? CountryId { get; set; }

    public string? Address { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual User? User { get; set; }
}
