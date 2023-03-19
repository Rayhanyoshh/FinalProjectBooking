using HotelRealtaPayment.Domain.Dto;
using Realta.Domain.Entities;
using Realta.Domain.Repositories;
using Realta.Domain.RequestFeatures;
using Realta.Persistence.Base;
using Realta.Persistence.RepositoryContext;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Persistence.Repositories
{
    internal class BookingRepo : RepositoryBase<BookingOrders>, IBookingRepo
    {
        public BookingRepo(AdoDbContext AdoContext) : base(AdoContext)
        {
        }
        public int insertBookingBySP(BookingOrders bookingOrders)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "Booking.sp_insert_booking_orders",
                CommandType = CommandType.StoredProcedure,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boor_hotel_id",
                        DataType = DbType.Int32,
                        Value = bookingOrders.BoorHotelId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boor_user_id",
                        DataType = DbType.Int32,
                        Value = bookingOrders.BoorUserId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boor_pay_type",
                        DataType = DbType.String,
                        Value = bookingOrders.BoorPayType
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boor_is_paid",
                        DataType = DbType.String,
                        Value = bookingOrders.BoorIsPaid
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boor_down_payment",
                        DataType = DbType.Decimal,
                        Value = bookingOrders.BoorDownPayment
                    } ,
                    new SqlCommandParameterModel() {
                        ParameterName = "@boor_cardnumber",
                        DataType = DbType.String,
                        Value = bookingOrders.BoorCardnumber
                    }
                }
            };

            var id=_adoContext.ExecuteScalar<decimal>(model);
            _adoContext.Dispose();
            return (int)id;
                
        }
        public int insertBookDetailBySP(BookingOrderDetail bookingOrderDetail)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "Booking.sp_insert_booking_order_detail",
                CommandType = CommandType.StoredProcedure,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@borde_boor_id",
                        DataType = DbType.Int32,
                        Value = bookingOrderDetail.BordeBoorId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@borde_faci_id",
                        DataType = DbType.Int32,
                        Value = bookingOrderDetail.BordeFaciId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@borde_checkin",
                        DataType = DbType.DateTime,
                        Value = bookingOrderDetail.BordeCheckin
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@borde_checkout",
                        DataType = DbType.DateTime,
                        Value = bookingOrderDetail.BordeCheckout
                    }
                }
            };

            var id = _adoContext.ExecuteScalar<decimal>(model);
            _adoContext.Dispose();
            return (int)id;
        }
        public int insertBookExtraBySP(BookingOrderDetailExtra bookingOrderDetailExtra)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "Booking.sp_insert_booking_extra",
                CommandType = CommandType.StoredProcedure,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boex_borde_id",
                        DataType = DbType.Int32,
                        Value = bookingOrderDetailExtra.BoexBordeId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boex_prit_id",
                        DataType = DbType.Int32,
                        Value = bookingOrderDetailExtra.BoexPritId

                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boex_qty",
                        DataType = DbType.Int16,
                        Value = bookingOrderDetailExtra.BoexQty
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boex_measure_unit",
                        DataType = DbType.String,
                        Value = bookingOrderDetailExtra.BoexMeasureUnit
                    }
                }
            };

            var id = _adoContext.ExecuteScalar<decimal>(model);
            _adoContext.Dispose();
            return (int)id;
        }
        public async Task<IEnumerable<Hotels>> FindFaciByHotelIdAsync(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = @"Booking.sp_get_faci",
                CommandType = CommandType.StoredProcedure,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@hotel_id",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };
            IAsyncEnumerator<Hotels> dataset = FindAllAsync<Hotels>(model);
            var item = new List<Hotels>();
            while (await dataset.MoveNextAsync())
            {
                item.Add(dataset.Current);
            }
            return item;
        }
        
        //FindUserByBoorId for Invoice
        public UserMembers findUserByBoorId(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText =
                @"
                    SELECT
                        u.user_id UserId,
	                    u.user_full_name UserFullName,
	                    u.user_phone_number UserPhoneNumber,
	                    um.usme_memb_name UsmeMembName,
	                    um.usme_promote_date UsmePromoteDate,
	                    um.usme_points UsmePoints
                    FROM
	                    Users.users u 
	                    join Users.user_members um on u.user_id=um.usme_user_id
	                    join Booking.booking_orders b on u.user_id=b.boor_user_id
                    WHERE b.boor_id=@id

                ",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                new SqlCommandParameterModel()
                  {
                      ParameterName="@id",
                      DataType=DbType.Int32,
                      Value=id
                  }}
            };
            var dataSet = FindByCondition<UserMembers>(model);
            UserMembers item = dataSet.Current;
            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }
            return item;
        }
        
        //FindUserByUserId
        public Users findUserById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText =
                @"
                    SELECT
                        u.user_id UserId,
	                    u.user_full_name UserFullName,
	                    u.user_phone_number UserPhoneNumber,
	                    u.user_email UserEmail
                    FROM
	                    Users.users u 
                    WHERE u.user_id=@id

                ",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                new SqlCommandParameterModel()
                  {
                      ParameterName="@id",
                      DataType=DbType.Int32,
                      Value=id
                  }}
            };
            var dataSet = FindByCondition<Users>(model);
            Users item = dataSet.Current;
            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }
            return item;
        }
        public IEnumerable<AccountUser> FindAccountByUserId(int id)
        {
            var model = new SqlCommandModel()
            {
                CommandText = @"SELECT usac_account_number AccountNumber,
                                       user_id UserId,
                                       usac_saldo Saldo,
                                       usac_type Type,
                                       payment_name PaymentName
                                  FROM Payment.fnGetUserBalance(@userId)",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {
                    new()
                    {
                        ParameterName = "@userId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var listOfAccount = FindByCondition<AccountUser>(model);

            while (listOfAccount.MoveNext())
                yield return listOfAccount.Current;
        }

        public Hotels FindFacilitiesByFacId(int facilitiesId)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = @"SELECT " +
                              "     faci_id AS FaciId " +
                              ",    faci_name AS FaciName " +
                              ",    faci_startdate AS FaciStartdate " +
                              ",    faci_enddate AS FaciEnddate " +
                              ",    faci_max_number AS FaciMaxNumber " +
                              ",    faci_room_number AS FaciRoomNumber " +
                              ",     CASE faci_expose_price" +
                              "         WHEN 1 THEN faci_low_price " +
                              "         WHEN 2 THEN faci_rate_price " +
                              "         WHEN 3 THEN faci_high_price " +
                              "     END AS FaciPrice" +
                              ",    faci_discount AS FaciDiscount " +
                              ",    faci_tax_rate AS FaciTax" +
                              ",    faci_modified_date AS FaciModifiedDate " +
                              ",    faci_hotel_id AS HotelId " +
                              " FROM" +
                              "     Hotel.Facilities " +
                              " WHERE " +
                              "     faci_id = @faci_id;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@faci_id",
                        DataType = DbType.Int32,
                        Value = facilitiesId
                    },
                }
            };

            var dataSet = FindByCondition<Hotels>(model);
            Hotels item = dataSet.Current;
            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }
            return item;
        }
    }
}
