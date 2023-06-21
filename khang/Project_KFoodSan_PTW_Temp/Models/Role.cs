using System;
using System.Collections.Generic;

namespace Project_KFoodSan_PTW_Temp.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
