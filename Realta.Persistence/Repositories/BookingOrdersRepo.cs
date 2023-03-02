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
    internal class BookingOrdersRepo : RepositoryBase<BookingOrders>, IBookingOrdersRepository


    {
        public BookingOrdersRepo (AdoDbContext AdoContext) : base(AdoContext)
        {
        }
        public IEnumerable<BookingOrders> FindAllBookingOrders()
        {
            IEnumerator<BookingOrders> dataSet = FindAll<BookingOrders>("SELECT " +
                "boor_id AS BoorId, " +
                "boor_order_number AS BoorOrderNumber, " +
                "boor_order_date AS BoorOrderDate, " +
                "boor_arrival_date AS BoorArrivalDate, " +
                "boor_total_room AS BoorTotalRoom, " +
                "boor_total_guest AS BoorTotalGuest, " +
                "boor_discount AS BoorDiscount, " +
                "boor_total_tax AS BoorTotalTax, " +
                "boor_total_ammount AS BoorTotalAmmount, " +
                "boor_down_payment AS BoorDownPayment, " +
                "boor_pay_type AS BoorPayType, " +
                "boor_is_paid AS BoorIsPaid, " +
                "boor_type AS BoorType, " +
                "boor_cardnumber AS BoorCardnumber, " +
                "boor_member_type AS BoorMemberType, " +
                "boor_status AS BoorStatus, " +
                "boor_user_id AS BoorUserId, " +
                "boor_hotel_id AS BoorHotelId" +
                " FROM Booking.booking_orders;");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }


        public void Edit(BookingOrders booking_Orders)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Booking.Booking_orders SET boor_order_number = @boorOrderNumber,boor_order_date = @boorOrderDate,boor_arrival_date = @boorArrivalDate,boor_total_room = @boorTotalRoom,boor_total_guest = @boorTotalGuest,boor_discount = @boorDiscount,boor_total_tax = @boorTotalTax,boor_total_ammount = @boorTotalAmmount,boor_down_payment = @boorDownPayment,boor_pay_type = @boorPayType,boor_is_paid = @boorIsPaid,boor_type = @boorType,boor_cardnumber = @boorCardnumber,boor_member_type = @boorMemberType,boor_status = @boorStatus,boor_user_id = @boorUserId,boor_hotel_id = @boorHotelId WHERE boor_id = @boorId",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.BoorId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorOrderNumber",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorOrderNumber
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorOrderDate",
                        DataType = DbType.DateTime,
                        Value = booking_Orders.BoorOrderDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorArrivalDate",
                        DataType = DbType.DateTime,
                        Value = booking_Orders.BoorArrivalDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalRoom",
                        DataType = DbType.Int16,
                        Value = booking_Orders.BoorTotalRoom
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalGuest",
                        DataType = DbType.Int16,
                        Value = booking_Orders.BoorTotalGuest
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorDiscount",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.BoorDiscount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalTax",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.BoorTotalTax
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalAmmount",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.BoorTotalAmmount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorDownPayment",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.BoorDownPayment
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorPayType",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorPayType
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorIsPaid",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorIsPaid
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorType",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorType
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorCardnumber",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorCardnumber
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorMemberType",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorMemberType
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorStatus",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorStatus
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorUserId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.BoorUserId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorHotelId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.BoorHotelId
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public async Task<IEnumerable<BookingOrders>> FindAllBookingOrdersAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT " +
                "boor_id AS BoorId, " +
                "boor_order_number AS BoorOrderNumber, " +
                "boor_order_date AS BoorOrderDate, " +
                "boor_arrival_date AS BoorArrivalDate, " +
                "boor_total_room AS BoorTotalRoom, " +
                "boor_total_guest AS BoorTotalGuest, " +
                "boor_discount AS BoorDiscount, " +
                "boor_total_tax AS BoorTotalTax, " +
                "boor_total_ammount AS BoorTotalAmmount, " +
                "boor_down_payment AS BoorDownPayment, " +
                "boor_pay_type AS BoorPayType, " +
                "boor_is_paid AS BoorIsPaid, " +
                "boor_type AS BoorType, " +
                "boor_cardnumber AS BoorCardnumber, " +
                "boor_member_type AS BoorMemberType, " +
                "boor_status AS BoorStatus, " +
                "boor_user_id AS BoorUserId, " +
                "boor_hotel_id AS BoorHotelId" +
                " FROM Booking.booking_orders;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }

            };

            IAsyncEnumerator<BookingOrders> dataSet = FindAllAsync<BookingOrders>(model);

            var item = new List<BookingOrders>();


            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }


            return item;
        }


        public BookingOrders FindBookingOrdersById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT " +
                "boor_id AS BoorId, " +
                "boor_order_number AS BoorOrderNumber, " +
                "boor_order_date AS BoorOrderDate, " +
                "boor_arrival_date AS BoorArrivalDate, " +
                "boor_total_room AS BoorTotalRoom, " +
                "boor_total_guest AS BoorTotalGuest, " +
                "boor_discount AS BoorDiscount, " +
                "boor_total_tax AS BoorTotalTax, " +
                "boor_total_ammount AS BoorTotalAmmount, " +
                "boor_down_payment AS BoorDownPayment, " +
                "boor_pay_type AS BoorPayType, " +
                "boor_is_paid AS BoorIsPaid, " +
                "boor_type AS BoorType, " +
                "boor_cardnumber AS BoorCardnumber, " +
                "boor_member_type AS BoorMemberType, " +
                "boor_status AS BoorStatus, " +
                "boor_user_id AS BoorUserId, " +
                "boor_hotel_id AS BoorHotelId" +
                " FROM Booking.booking_orders where boor_id=@boorId order by boor_id asc;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var dataSet = FindByCondition<BookingOrders>(model);

            BookingOrders? item = dataSet.Current;

            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }


            return item;
        }


        public void Insert(BookingOrders booking_Orders)
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
                        Value = booking_Orders.BoorId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorOrderNumber",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorOrderNumber
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorOrderDate",
                        DataType = DbType.DateTime,
                        Value = booking_Orders.BoorOrderDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorArrivalDate",
                        DataType = DbType.DateTime,
                        Value = booking_Orders.BoorArrivalDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalRoom",
                        DataType = DbType.Int16,
                        Value = booking_Orders.BoorTotalRoom
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalGuest",
                        DataType = DbType.Int16,
                        Value = booking_Orders.BoorTotalGuest
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorDiscount",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.BoorDiscount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalTax",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.BoorTotalTax
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorTotalAmmount",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.BoorTotalAmmount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorDownPayment",
                        DataType = DbType.Decimal,
                        Value = booking_Orders.BoorDownPayment
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorPayType",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorPayType
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorIsPaid",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorIsPaid
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorType",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorType
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorCardnumber",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorCardnumber
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorMemberType",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorMemberType
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorStatus",
                        DataType = DbType.String,
                        Value = booking_Orders.BoorStatus
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorUserId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.BoorUserId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorHotelId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.BoorHotelId
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public void Remove(BookingOrders booking_Orders)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Booking.Booking_orders WHERE boor_id = @boorId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorId",
                        DataType = DbType.Int32,
                        Value = booking_Orders.BoorId
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<BookingOrders> FindLastBoorID()
        {
            IEnumerator<BookingOrders> dataset = FindAll<BookingOrders>("SELECT " +
                "boor_id AS BoorId, " +
                "boor_order_number AS BoorOrderNumber, " +
                "boor_order_date AS BoorOrderDate, " +
                "boor_arrival_date AS BoorArrivalDate, " +
                "boor_total_room AS BoorTotalRoom, " +
                "boor_total_guest AS BoorTotalGuest, " +
                "boor_discount AS BoorDiscount, " +
                "boor_total_tax AS BoorTotalTax, " +
                "boor_total_ammount AS BoorTotalAmmount, " +
                "boor_down_payment AS BoorDownPayment, " +
                "boor_pay_type AS BoorPayType, " +
                "boor_is_paid AS BoorIsPaid, " +
                "boor_type AS BoorType, " +
                "boor_cardnumber AS BoorCardnumber, " +
                "boor_member_type AS BoorMemberType, " +
                "boor_status AS BoorStatus, " +
                "boor_user_id AS BoorUserId, " +
                "boor_hotel_id AS BoorHotelId" +
                " FROM Booking.booking_orders where boor_id =(SELECT IDENT_CURRENT('Booking.booking_orders'));");
            while (dataset.MoveNext())
            {
                var data = dataset.Current;
                yield return data;
            }
        }
    }
}
