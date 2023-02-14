using Realta.Domain.Entities;
using Realta.Domain.Repositories;
using Realta.Persistence.Base;
using Realta.Persistence.Interface;
using Realta.Persistence.RepositoryContext;
using System;
using System.Collections.Generic;
using System.Data;
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
            IEnumerator<Booking_orders> dataSet = FindAll<Booking_orders>("SELECT * From Booking.booking_orders");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }


        public void Edit(Booking_orders booking_Orders)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Booking.Booking_orders SET boor_order_number = @boorOrderNumber,boor_order_date = @boorOrderDate,boor_arrival_date = @boorArrivalDate,boor_total_room = @boorTotalRoom,boor_total_guest = @boorTotalGuest,boor_discount = @boorDiscount,boor_total_tax = @boorTotalTax,boor_total_ammount = @boorTotalAmmount,boor_down_payment = @boorDownPayment,boor_pay_type = @boorPayType,boor_is_paid = @boorIsPaid,boor_type = @boorType,boor_cardnumber = @boorCardnumber,boor_member_type = @boorMemberType,boor_status = @boorStatus,boor_user_id = @boorUserId,boor_hotel_id = @boorHotelId WHERE boor_id = @boorId",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.boor_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorOrderNumber",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_order_number
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorOrderDate",
                        DataType = DbType.DateTime,
                        Value = booking_Orders.boor_order_date
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorArrivalDate",
                        DataType = DbType.DateTime,
                        Value = booking_Orders.boor_arrival_date
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalRoom",
                        DataType = DbType.Int16,
                        Value = booking_Orders.boor_total_room
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalGuest",
                        DataType = DbType.Int16,
                        Value = booking_Orders.boor_total_guest
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorDiscount",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.boor_discount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalTax",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.boor_total_tax
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalAmmount",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.boor_total_ammount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorDownPayment",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.boor_down_payment
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorPayType",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_pay_type
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorIsPaid",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_is_paid
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorType",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_type
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorCardnumber",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_cardnumber
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorMemberType",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_member_type
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorStatus",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_status
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorUserId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.boor_user_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorHotelId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.boor_hotel_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public async Task<IEnumerable<Booking_orders>> FindAllBookingOrdersAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT * FROM Booking.booking_orders;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }

            };

            IAsyncEnumerator<Booking_orders> dataSet = FindAllAsync<Booking_orders>(model);

            var item = new List<Booking_orders>();


            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }


            return item;
        }


        public Booking_orders FindBookingOrdersById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT * FROM Booking.booking_orders where boor_id=@boorId order by boor_id asc;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var dataSet = FindByCondition<Booking_orders>(model);

            Booking_orders? item = dataSet.Current;

            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }


            return item;
        }


        public void Insert(Booking_orders booking_Orders)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "INSERT INTO Booking.booking_orders (boor_order_number,boor_order_date, boor_arrival_date,boor_total_room , boor_total_guest,boor_discount,boor_total_tax,boor_total_ammount,boor_down_payment,boor_pay_type, boor_is_paid, boor_type, boor_cardnumber, boor_member_type, boor_status,boor_user_id, boor_hotel_id) " +
                "VALUES(@boorOrderNumber, @boorOrderDate, @boorArrivalDate, @boorTotalRoom, @boorTotalGuest, @boorDiscount, @boorTotalTax, @boorTotalAmmount, @boorDownPayment, @boorPayType, @boorIsPaid, @boorType, @boorCardnumber, @boorMemberType, @boorStatus, @boorUserId, @boorHotelId)",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.boor_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorOrderNumber",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_order_number
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorOrderDate",
                        DataType = DbType.DateTime,
                        Value = booking_Orders.boor_order_date
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorArrivalDate",
                        DataType = DbType.DateTime,
                        Value = booking_Orders.boor_arrival_date
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalRoom",
                        DataType = DbType.Int16,
                        Value = booking_Orders.boor_total_room
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalGuest",
                        DataType = DbType.Int16,
                        Value = booking_Orders.boor_total_guest
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorDiscount",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.boor_discount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalTax",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.boor_total_tax
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalAmmount",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.boor_total_ammount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorDownPayment",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.boor_down_payment
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorPayType",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_pay_type
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorIsPaid",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_is_paid
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorType",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_type
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorCardnumber",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_cardnumber
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorMemberType",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_member_type
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorStatus",
                        DataType = DbType.String,
                        Value = booking_Orders.boor_status
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorUserId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.boor_user_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorHotelId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.boor_hotel_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public void Remove(Booking_orders booking_Orders)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Booking.Booking_orders WHERE boor_id = @boorId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.boor_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<Booking_orders> FindLastBoorID()
        {
            IEnumerator<Booking_orders> dataset = FindAll<Booking_orders>("SELECT * FROM Booking.Booking_orders where boor_id =(SELECT IDENT_CURRENT('Booking.booking_orders'));");
            while (dataset.MoveNext())
            {
                var data = dataset.Current;
                yield return data;
            }
        }
    }
}
