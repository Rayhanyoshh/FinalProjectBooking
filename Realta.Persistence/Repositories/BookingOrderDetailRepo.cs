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
    internal class BookingOrderDetailrepo : RepositoryBase<BookingOrderDetail>, IBookingOrderDetailRepo


    {
        public BookingOrderDetailrepo(AdoDbContext adoContext) : base(adoContext)
        {
        }
        public IEnumerable<BookingOrderDetail> FindAllBorde()
        {
            IEnumerator<BookingOrderDetail> dataSet = FindAll<BookingOrderDetail>
               ("SELECT " +
                "borde_id AS BordeId, " +
                "borde_boor_id AS BordeBoorId, " +
                "borde_checkin AS BordeCheckin, " +
                "borde_checkout AS BordeCheckout, " +
                "borde_adults AS BordeAdults, " +
                "borde_kids AS BordeKids, " +
                "borde_price AS BordePrice, " +
                "borde_extra AS BordeExtra, " +
                "borde_discount AS BordeDiscount, " +
                "borde_tax AS BordeTax, " +
                "borde_subtotal AS BordeSubtotal, " +
                "borde_faci_id AS BordeFaciId" +
                " from Booking.booking_order_detail");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }
        public void Edit(BookingOrderDetail borde)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Booking.Booking_order_detail SET borde_boor_id = @bordeBoorId, borde_checkin = @bordeCheckin, borde_checkout = @bordeCheckout, borde_adults = @bordeAdult, borde_kids = @bordeKids, borde_price = @bordePrice, borde_extra = @bordeExtra, borde_discount = @bordeDiscount, borde_tax = @bordeTax, borde_subtotal = @bordeSubtotal, borde_faci_id = @bordeFaciId WHERE borde_id = @bordeId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeId",
                        DataType = DbType.Int32,
                        Value = borde.BordeId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeBoorId",
                        DataType = DbType.Int32,
                        Value = borde.BordeBoorId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeCheckin",
                        DataType = DbType.DateTime,
                        Value = borde.BordeCheckin
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeCheckout",
                        DataType = DbType.DateTime,
                        Value = borde.BordeCheckout
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeAdult",
                        DataType = DbType.Int32,
                        Value = borde.BordeAdults
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeKids",
                        DataType = DbType.Int32,
                        Value = borde.BordeKids
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordePrice",
                        DataType = DbType.Decimal,
                        Value = borde.BordePrice
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeExtra",
                        DataType = DbType.Decimal,
                        Value = borde.BordeExtra
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeDiscount",
                        DataType = DbType.Decimal,
                        Value = borde.BordeDiscount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeTax",
                        DataType = DbType.Decimal,
                        Value = borde.BordeTax
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeSubtotal",
                        DataType = DbType.Decimal,
                        Value = borde.BordeSubtotal
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeFaciId",
                        DataType = DbType.Int32,
                        Value = borde.BordeFaciId
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }


        public async Task<IEnumerable<BookingOrderDetail>> FindAllBordeAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT " +
                "borde_id AS BordeId, " +
                "borde_boor_id AS BordeBoorId, " +
                "borde_checkin AS BordeCheckin, " +
                "borde_checkout AS BordeCheckout, " +
                "borde_adults AS BordeAdults, " +
                "borde_kids AS BordeKids, " +
                "borde_price AS BordePrice, " +
                "borde_extra AS BordeExtra, " +
                "borde_discount AS BordeDiscount, " +
                "borde_tax AS BordeTax, " +
                "borde_subtotal AS BordeSubtotal, " +
                "borde_faci_id AS BordeFaciId" +
                " from Booking.booking_order_detail",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }

            };

            IAsyncEnumerator<BookingOrderDetail> dataSet = FindAllAsync<BookingOrderDetail>(model);

            var item = new List<BookingOrderDetail>();


            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }


            return item;
        }

        public BookingOrderDetail FindBordeById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT " +
                "borde_id AS BordeId, " +
                "borde_boor_id AS BordeBoorId, " +
                "borde_checkin AS BordeCheckin, " +
                "borde_checkout AS BordeCheckout, " +
                "borde_adults AS BordeAdults, " +
                "borde_kids AS BordeKids, " +
                "borde_price AS BordePrice, " +
                "borde_extra AS BordeExtra, " +
                "borde_discount AS BordeDiscount, " +
                "borde_tax AS BordeTax, " +
                "borde_subtotal AS BordeSubtotal, " +
                "borde_faci_id AS BordeFaciId" +
                " from Booking.booking_order_detail where borde_id=@bordeId order by borde_id asc;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var dataSet = FindByCondition<BookingOrderDetail>(model);

            BookingOrderDetail? item = dataSet.Current;

            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }


            return item;
        }

        public void Insert(BookingOrderDetail borde)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "INSERT INTO Booking.booking_order_detail (Borde_boor_id, Borde_checkin, Borde_checkout, Borde_adults, Borde_kids, Borde_price, Borde_extra, Borde_discount, Borde_tax, Borde_subtotal, Borde_faci_id) " +
                              "VALUES(@bordeBoorId, @bordeCheckin, @bordeCheckout, @bordeAdult, @bordeKids, @bordePrice, @bordeExtra, @bordeDiscount, @bordeTax, @bordeSubtotal, @bordeFaciId);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeBoorId",
                        DataType = DbType.Int32,
                        Value = borde.BordeBoorId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeCheckin",
                        DataType = DbType.DateTime,
                        Value = borde.BordeCheckin
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeCheckout",
                        DataType = DbType.DateTime,
                        Value = borde.BordeCheckout
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeAdult",
                        DataType = DbType.Int32,
                        Value = borde.BordeAdults
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeKids",
                        DataType = DbType.Int32,
                        Value = borde.BordeKids
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordePrice",
                        DataType = DbType.Decimal,
                        Value = borde.BordePrice
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeExtra",
                        DataType = DbType.Decimal,
                        Value = borde.BordeExtra
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeDiscount",
                        DataType = DbType.Decimal,
                        Value = borde.BordeDiscount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeTax",
                        DataType = DbType.Decimal,
                        Value = borde.BordeTax
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeSubtotal",
                        DataType = DbType.Decimal,
                        Value = borde.BordeSubtotal
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeFaciId",
                        DataType = DbType.Int32,
                        Value = borde.BordeFaciId
                    }
                }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public void Remove(BookingOrderDetail borde)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Booking.Booking_order_detail WHERE borde_id = @bordeId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeId",
                        DataType = DbType.Int32,
                        Value = borde.BordeId
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }


        public int GetBordeDetailSequenceId()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT IDENT_CURRENT('Booking.booking_order_detail');",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }
            };

            var id = _adoContext.ExecuteScalar<decimal>(model);
            _adoContext.Dispose();

            return (int)id;
        }

        public async Task<IEnumerable<BookingOrderDetail>> FindAllBordeByBoorId(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = 
                @"
                    SELECT
	                    d.borde_boor_id BordeBoorId,
	                    d.borde_id BordeId,
	                    f.faci_name FaciName,
	                    d.borde_checkin BordeCheckin,
	                    d.borde_checkout BordeCheckout,
	                    d.borde_adults BordeAdults,
	                    d.borde_kids BordeKids,
	                    d.borde_price BordePrice,
	                    d.borde_extra BordeExtra,
	                    d.borde_discount BordeDiscount,
	                    d.borde_tax BordeTax,
	                    d.borde_subtotal BordeSubtotal,
	                    d.borde_faci_id BordeFaciId
                    FROM 
	                    Booking.booking_order_detail d
	                    join Booking.booking_order_detail_extra e ON d.borde_id=e.boex_borde_id 
	                    join Hotel.Facilities f ON f.faci_id=d.borde_faci_id
	                    join Master.price_items p ON e.boex_prit_id=p.prit_id
                    WHERE 
	                    d.borde_boor_id=@boorId;
                ",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boorId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };
            IAsyncEnumerator<BookingOrderDetail> dataSet = FindAllAsync<BookingOrderDetail>(model);
            var item = new List<BookingOrderDetail>();
            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }
            return item;
        }
    }
}
