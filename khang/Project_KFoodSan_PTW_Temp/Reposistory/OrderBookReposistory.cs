using Microsoft.AspNetCore.Mvc;
using Project_KFoodSan_PTW_Temp.Models;

namespace Project_KFoodSan_PTW_Temp.Reposistory
{
    public interface IOrderBookReposistory
    {
        public bool CreateOrderBook(OrderBook orderBook);
        public bool UpdateOrderBook(OrderBook orderBook);
        public bool DeleteOrderBook(int id);
        public List<OrderBook> GetAllOrderBook();
        public OrderBook FindOrderBookByID(string id);


    }
    public class OrderBookReposistory : IOrderBookReposistory
    {
        public KfoodSanContext _ctx;
        public OrderBookReposistory(KfoodSanContext ctx)
        {
            _ctx = ctx;
        }
        public bool CreateOrderBook(OrderBook orderBook)
        {
            _ctx.OrderBooks.Add(orderBook);
            _ctx.SaveChanges();
            return true;
        }

        public bool DeleteOrderBook(int id)
        {
            OrderBook o = _ctx.OrderBooks.Where(x => x.Id == id).FirstOrDefault();
            if (o != null)
            {
                _ctx.OrderBooks.Remove(o);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public OrderBook FindOrderBookByID(string id)
        {
            if (int.TryParse(id, out int OrderBookID))
            {
                OrderBook o = _ctx.OrderBooks.Where(x => x.Id == OrderBookID).FirstOrDefault();
                if (o != null)
                {
                    return o;
                }
            }
            return null;
        }

        public List<OrderBook> GetAllOrderBook()
        {
            return _ctx.OrderBooks.ToList();
        }

        public bool UpdateOrderBook(OrderBook orderBook)
        {
            OrderBook o = _ctx.OrderBooks.Where(x => x.Id == orderBook.Id).FirstOrDefault();
            if (o != null)
            {
                _ctx.Entry(o).CurrentValues.SetValues(orderBook);
                _ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
