using Realta.Contract.Models;
using Realta.Domain.Base;
using Realta.Domain.Entities;
using Realta.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Services
{
    internal class BookingService : IBookingService
    {
        private readonly IRepositoryManager _repositoryManager;

        public BookingService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void CreateBooking(BoorBordeDto bordeDto, out int boor_id)
        {
            //1. hold data boor from boorBordeDto
            var bookingOrder = new BookingOrders
            {
                BoorHotelId = bordeDto.BookingOrders.BoorHotelId,
                BoorUserId = bordeDto.BookingOrders.BoorUserId,
                BoorPayType = bordeDto.BookingOrders.BoorPayType,
                BoorIsPaid = bordeDto.BookingOrders.BoorIsPaid
            };
            var arrBorderDto = bordeDto.BookingDetailExtra.ToArray();
            //2. insert to booking_orders
            int boorId = _repositoryManager.bookingRepo.insertBookingBySP(bookingOrder);

            //3. hold data bookingOrderDetail using foreach
            var bordes = bordeDto.BookingDetailExtra.ToList();
            foreach (var item in bordes)
            {
                var borde = new BookingOrderDetail
                {
                    BordeBoorId = boorId,
                    BordeFaciId = item.BookingOrderDetail.BordeFaciId,
                    BordeCheckin = item.BookingOrderDetail.BordeCheckin,
                    BordeCheckout = item.BookingOrderDetail.BordeCheckout
                };
                //retrive borde_id
                var bordeId = _repositoryManager.bookingRepo.insertBookDetailBySP(borde);

                //retrive boex data, check if not null do insert
                var boexs = item.BookingOrderDetailExtra.ToList();
                if (boexs != null)
                {
                    foreach (var itemExtra in boexs)
                    {
                        //hold data bookingOrderDetailExtra
                        var boex = new BookingOrderDetailExtra
                        {
                            BoexBordeId = bordeId,
                            BoexPritId = itemExtra.BoexPritId,
                            BoexQty = itemExtra.BoexQty,
                            BoexMeasureUnit = itemExtra.BoexMeasureUnit
                        };
                        //insert data boex
                        var BoexId = _repositoryManager.bookingRepo.insertBookExtraBySP(boex);
                    }
                }
            }
            boor_id = boorId;
        }
    }
}
