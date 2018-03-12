using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBCBay.Data;
using TheBCBay.Models;
using Microsoft.EntityFrameworkCore;

namespace TheBCBay.Services
{
    public class SqlItemData : IItemData
    {
        private TheBCBayDBContext _context;
        public SqlItemData(TheBCBayDBContext context)
        {
            _context = context;
        }

        public ItemModel Add(ItemModel newItem)
        {
            _context.Items.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public ItemModel Get(int id)
        {
            ItemModel myItem = _context.Items.FirstOrDefault(r => r.Id == id);
            UpdateCurrentPrice(myItem);
            return myItem;
        }

        public IEnumerable<ItemModel> GetAll()
        {
            return _context.Items.OrderBy(r => r.Title).Where(item => item.Active == true);
        }

        public ItemModel Update(ItemModel item)
        {
            _context.Attach(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
        public void UpdateCurrentPrice(ItemModel myItem)
        {
            var endMinusStart = myItem.EndTime.Subtract(myItem.StartDate).TotalMinutes;
            var endMinusCurrent = myItem.EndTime.Subtract(DateTime.Now).TotalMinutes;
            int totalMinutes = (int)Math.Round(endMinusStart);
            int minutesSoFar = (int)Math.Round(endMinusCurrent);
            decimal priceDifference = myItem.TopPrice - myItem.LowPrice;
            //My algorithm
            decimal CurrentPrice = (int)((priceDifference * minutesSoFar) * 100 / totalMinutes) ;
            if (CurrentPrice < myItem.LowPrice)
            {
                myItem.CurrentPrice = myItem.LowPrice;
            }
            else
            {
                myItem.CurrentPrice = CurrentPrice / 100; 
            }

            _context.Attach(myItem);
            _context.SaveChanges();

        }
    }
}
