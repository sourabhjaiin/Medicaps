using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCaps.BusinessLogic.Repos;
using MediCaps.DataAccess.DTOs;
using MediCaps.DataAccess.Entities;

namespace MediCaps.BusinessLogic.Services
{
    public class CartServices
    {
        public readonly CartRepository cartRepository;

        public CartServices()
        {
            cartRepository = new CartRepository();
        }

        public bool Add(Cartdto dto)
        {
            if (!cartRepository.Exists(dto.UserId, dto.MedicineId))
            {
                var Cart = new Cart { UserId = dto.UserId, MedicineId = dto.MedicineId, Quantity = dto.Quantity, Price = dto.MedicinePrice };
                return cartRepository.Add(Cart) == 1;
            }
            var Item = cartRepository.GetCartItem(dto.UserId, dto.MedicineId);
            Item.Price = dto.MedicinePrice;
            Item.Quantity += dto.Quantity;
            return cartRepository.Update(Item) == 1;
        }

        public bool ClearCart(int userId)
        {
            return cartRepository.ClearCart(userId) > 0;
        }

        public bool Remove(int cartItemId)
        {
            return cartRepository.Remove(cartItemId) == 1;
        }

        public IEnumerable<Cartdto> GetCart(int userId)
        {
            var CartItems = cartRepository.GetCart(userId);
            var Dtos = new List<Cartdto>();
            foreach (var item in CartItems)
                Dtos.Add(new Cartdto
                {
                    ID = item.ID,
                    MedicineId = item.MedicineId,
                    UserId = item.UserId,
                    Quantity = item.Quantity,
                    MedicinePrice = item.Price,
                    MedicineName = item.Medicine.MedicineName
                }) ;
            return Dtos;
        }
    }
}
