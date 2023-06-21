namespace Project_KFoodSan_PTW_Temp.Models
{
    public class CartModel
    {
        public string ID { get; set; }
        public double TotalPrice { get; set; }
        List<Item> items = new List<Item>();
        public List<Item> getAllItems()
        {
            return items;
        }
        public void setAllItems(List<Item> _items)
        {
            items = _items;
        }
        public int AddItem(Item item)
        {
            foreach (var it in items)
            {
                if (it.Id == item.Id)
                {
                    it.quantity += 1;
                    it.lineTotal += it.quantity * it.price;
                    return items.Count;
                }
            }
            items.Add(item);
            return items.Count;
        }
        public int getCountItems()
        {
            return items.Count;
        }
        public void UpdateQuantity(string btnUpdate, string id, int quantity)
        {
            foreach (Item item in items)
            {
                if (item.Id == id)
                {
                    if (btnUpdate == "+")
                    {
                        item.quantity += 1;

                    }
                    else if (btnUpdate == "-")
                    {
                        item.quantity -= 1;
                    }
                    item.lineTotal = item.quantity * item.price;

                }
            }
            TotalPrice = 0;
            foreach (Item item in items)
            {
                TotalPrice += item.lineTotal;
            }

        }

        public void RemoveToCart(string id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id)
                {
                    items.Remove(items[i]);
                    Console.WriteLine(items.Count);
                    //Sap xep vi tri phan tu sau khi xoa
                    for (int j = i; j < items.Count -1; j++)
                    {
                        items[j].Id = items[j + 1].Id;    
                    }
                    break;
                }

            }
            Console.WriteLine(items);
        }

        public double getSubPrice()
        {
            TotalPrice = 0;
            foreach (Item item in items)
            {
                TotalPrice += item.lineTotal;
            }
            return TotalPrice;
        }
        public double TotalPriceAfterTax()
        {
            TotalPrice = 0;
            foreach (Item item in items)
            {
                TotalPrice += item.lineTotal;
            }
            double tax = TotalPrice * 0.1;
            double TotalPriceAfterTax = TotalPrice + tax;
            return TotalPriceAfterTax;
        }
        public double getTax()
        {
            TotalPrice = 0;
            foreach (Item item in items)
            {
                TotalPrice += item.lineTotal;
            }
            double tax = TotalPrice * 0.1;
            return tax;
        }


    }
}
