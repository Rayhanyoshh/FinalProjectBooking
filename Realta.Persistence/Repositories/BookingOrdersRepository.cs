using Realta.Domain.Entities;
using Realta.Domain.Repositories;
using Realta.Persistence.Base;
using Realta.Persistence.Interface;
using Realta.Persistence.RepositoryContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Persistence.Repositories
{
    internal class BookingOrdersRepository : RepositoryBase<Booking_orders>, IBookingOrdersRepository


    {
        public BookingOrdersRepository (AdoDbContext AdoContext) : base(AdoContext)
        {
        }
        public IEnumerable<Booking_orders> FindAllBookingOrders()
        {
            IEnumerator<Booking_orders> dataSet = FindAll<Booking_orders>("SELECT  * From Booking.booking_orders");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }


        public void Edit(Booking_orders booking_Orders)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking_orders>> FindAllBookingOrdersAsync()
        {
            throw new NotImplementedException();
        }


        public Booking_orders FindBookingOrdersById(int id)
        {
            throw new NotImplementedException();
        }


        public void Insert(Booking_orders booking_Orders)
        {
            throw new NotImplementedException();
        }

        public void Remove(Booking_orders booking_Orders)
        {
            throw new NotImplementedException();
        }
    }
}
