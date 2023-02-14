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
    internal class BordeRepository : RepositoryBase<Booking_order_detail>, IBordeRepository


    {
        public BordeRepository(AdoDbContext adoContext) : base(adoContext)
        {
        }
        public IEnumerable<Booking_order_detail> FindAllBorde()
        {
            IEnumerator<Booking_order_detail> dataSet = FindAll<Booking_order_detail>("select * from Booking.booking_order_detail");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }
        public void Edit(Booking_order_detail borde)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Booking.Booking_order_detail SET borde_boor_id = @bordeBoorId, borde_checkin = @bordeCheckin, borde_checkout = @bordeCheckout, borde_adults = @bordeAdult, borde_kids = @bordeKids, borde_price = @bordePrice, borde_extra = @bordeExtra, borde_discount = @bordeDiscount, borde_tax = @bordeTax, borde_subtotal = @bordeSubtotal, borde_faci_id = @bordeFaciId WHERE borde_id = @bordeId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeId",
                        DataType = DbType.Int32,
                        Value = borde.borde_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeBoorId",
                        DataType = DbType.Int32,
                        Value = borde.borde_boor_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeCheckin",
                        DataType = DbType.DateTime,
                        Value = borde.borde_checkin
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeCheckout",
                        DataType = DbType.DateTime,
                        Value = borde.borde_checkout
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeAdult",
                        DataType = DbType.Int32,
                        Value = borde.borde_adults
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeKids",
                        DataType = DbType.Int32,
                        Value = borde.borde_kids
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordePrice",
                        DataType = DbType.Decimal,
                        Value = borde.borde_price
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeExtra",
                        DataType = DbType.Decimal,
                        Value = borde.borde_extra
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeDiscount",
                        DataType = DbType.Decimal,
                        Value = borde.borde_discount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeTax",
                        DataType = DbType.Decimal,
                        Value = borde.borde_tax
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeSubtotal",
                        DataType = DbType.Decimal,
                        Value = borde.borde_subtotal
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeFaciId",
                        DataType = DbType.Int32,
                        Value = borde.borde_faci_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }


        public async Task<IEnumerable<Booking_order_detail>> FindAllBordeAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT * FROM Booking.booking_order_detail;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }

            };

            IAsyncEnumerator<Booking_order_detail> dataSet = FindAllAsync<Booking_order_detail>(model);

            var item = new List<Booking_order_detail>();


            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }


            return item;
        }

        public Booking_order_detail FindBordeById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT * FROM Booking.booking_order_detail where borde_id=@bordeId order by borde_id asc;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var dataSet = FindByCondition<Booking_order_detail>(model);

            Booking_order_detail? item = dataSet.Current;

            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }


            return item;
        }

        public void Insert(Booking_order_detail borde)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "INSERT INTO Booking.booking_order_detail (Borde_boor_id, Borde_checkin, Borde_checkout, Borde_adults, Borde_kids, Borde_price, Borde_extra, Borde_discount, Borde_tax, Borde_subtotal, Borde_faci_id) " +
                              "VALUES(@bordeBoorId, @bordeCheckin, @bordeCheckout, @bordeAdult, @bordeKids, @bordePrice, @bordeExtra, @bordeDiscount, @bordeTax, @bordeSubtotal, @bordeFaciId);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeId",
                        DataType = DbType.Int32,
                        Value = borde.borde_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeBoorId",
                        DataType = DbType.Int32,
                        Value = borde.borde_boor_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeCheckin",
                        DataType = DbType.DateTime,
                        Value = borde.borde_checkin
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeCheckout",
                        DataType = DbType.DateTime,
                        Value = borde.borde_checkout
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeAdult",
                        DataType = DbType.Int32,
                        Value = borde.borde_adults
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeKids",
                        DataType = DbType.Int32,
                        Value = borde.borde_kids
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordePrice",
                        DataType = DbType.Decimal,
                        Value = borde.borde_price
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeExtra",
                        DataType = DbType.Decimal,
                        Value = borde.borde_extra
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeDiscount",
                        DataType = DbType.Decimal,
                        Value = borde.borde_discount
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeTax",
                        DataType = DbType.Decimal,
                        Value = borde.borde_tax
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeSubtotal",
                        DataType = DbType.Decimal,
                        Value = borde.borde_subtotal
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeFaciId",
                        DataType = DbType.Int32,
                        Value = borde.borde_faci_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public void Remove(Booking_order_detail borde)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Booking.Booking_order_detail WHERE borde_id = @bordeId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@bordeId",
                        DataType = DbType.Int32,
                        Value = borde.borde_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }
    }
}
