using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCaps.DataAccess.Entities;
using MediCaps.DataAccess;
using System.Data.Entity;

namespace MediCaps.BusinessLogic.Repos
{
    public class CartRepository
    {
        public readonly MedicapsContext context;
        public CartRepository()
        {
            context = new MedicapsContext();
        }

        public int Add(Cart cartItem)
        {
            context.Carts.Add(cartItem);
            
            return context.SaveChanges();
        }

        public int Update(Cart cartItem)
        {
            context.Carts.Attach(cartItem);
            context.Entry(cartItem).State = EntityState.Modified;
            return context.SaveChanges();
        }

        public bool Exists(int userId, int medicineId)
        {
            return context.Carts.Any(item => item.UserId == userId && item.MedicineId == medicineId);
        }

        public Cart GetCartItem(int userId, int medicineId)
        {
            return context.Carts.Include(c => c.Medicine).Single(item => item.UserId == userId && item.MedicineId == medicineId);
        }

        public int Remove(int cartItemId)
        {
            var Cart = context.Carts.Find(cartItemId);
            context.Carts.Remove(Cart);
            return context.SaveChanges();
        }

        public int ClearCart(int userId)
        {
            var CartItems = context.Carts.Where(cart => cart.UserId == userId);
            context.Carts.RemoveRange(CartItems);
            return context.SaveChanges();
        }
        public IEnumerable<Cart> GetCart(int userId)
        {
            var Query = from cart in context.Carts.Include(c => c.Medicine)
                        where cart.UserId == userId
                        select cart;
            return Query.ToList();
        }
    }
}
