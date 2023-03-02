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
    internal class BookingOrderDetailExtraRepo : RepositoryBase<BookingOrderDetailExtra>, IBookingOrderDetailExtraRepo

    {
        public BookingOrderDetailExtraRepo(AdoDbContext AdoContext) : base(AdoContext)
        {
        }

        public void Edit(BookingOrderDetailExtra boex)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Booking.Booking_order_detail_extra SET boex_price = @boexPrice, boex_qty = @boexQty, boex_subtotal = @boexSubtotal, boex_measure_unit = @boexMeasureUnit, boex_borde_id = @boexBordeId, boex_prit_id = @boexPritId WHERE boex_id = @boexId",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexId",
                        DataType = DbType.Int32,
                        Value = boex.BoexId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexPrice",
                        DataType = DbType.Decimal,
                        Value = boex.BoexPrice
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexQty",
                        DataType = DbType.Int16,
                        Value = boex.BoexQty
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexSubtotal",
                        DataType = DbType.Decimal,
                        Value = boex.BoexSubtotal
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexMeasureUnit",
                        DataType = DbType.String,
                        Value = boex.BoexMeasureUnit
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexBordeId",
                        DataType = DbType.Int32,
                        Value = boex.BoexBordeId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexPritId",
                        DataType = DbType.Int32,
                        Value = boex.BoexPritId
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<BookingOrderDetailExtra> FindAllBoex()
        {
            IEnumerator<BookingOrderDetailExtra> dataSet = FindAll<BookingOrderDetailExtra>
                ("SELECT boex_id AS BoexId, " +
                "boex_price AS BoexPrice, " +
                "boex_qty AS BoexQty, " +
                "boex_subtotal AS BoexSubtotal, " +
                "boex_measure_unit AS BoexMeasureUnit, " +
                "boex_borde_id AS BoexBordeId, " +
                "boex_prit_id AS BoexPritId " +
                "From Booking.booking_order_detail_extra;");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }

        public async Task<IEnumerable<BookingOrderDetailExtra>> FindAllBoexAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT boex_id AS BoexId, " +
                "boex_price AS BoexPrice, " +
                "boex_qty AS BoexQty, " +
                "boex_subtotal AS BoexSubtotal, " +
                "boex_measure_unit AS BoexMeasureUnit, " +
                "boex_borde_id AS BoexBordeId, " +
                "boex_prit_id AS BoexPritId " +
                "From Booking.booking_order_detail_extra;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }

            };

            IAsyncEnumerator<BookingOrderDetailExtra> dataSet = FindAllAsync<BookingOrderDetailExtra>(model);

            var item = new List<BookingOrderDetailExtra>();


            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }


            return item;
        }

        public BookingOrderDetailExtra FindBoexById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT boex_id AS BoexId, " +
                "boex_price AS BoexPrice, " +
                "boex_qty AS BoexQty, " +
                "boex_subtotal AS BoexSubtotal, " +
                "boex_measure_unit AS BoexMeasureUnit, " +
                "boex_borde_id AS BoexBordeId, " +
                "boex_prit_id AS BoexPritId " +
                "From Booking.booking_order_detail_extra where boex_id=@boexId order by boex_id asc;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var dataSet = FindByCondition<BookingOrderDetailExtra>(model);

            BookingOrderDetailExtra? item = dataSet.Current;

            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }


            return item;
        }

        public void Insert(BookingOrderDetailExtra boex)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "INSERT INTO Booking.Booking_order_detail_extra (boex_price, boex_qty, boex_subtotal, boex_measure_unit, boex_borde_id, boex_prit_id) " +
                              "VALUES (@boexPrice, @boexQty, @boexSubtotal, @boexMeasureUnit, @boexBordeId, @boexPritId);" +
                              " SELECT CAST(scope_identity() as int);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexPrice",
                        DataType = DbType.Decimal,
                        Value = boex.BoexPrice
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexQty",
                        DataType = DbType.Int16,
                        Value = boex.BoexQty
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexSubtotal",
                        DataType = DbType.Decimal,
                        Value = boex.BoexSubtotal
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexMeasureUnit",
                        DataType = DbType.String,
                        Value = boex.BoexMeasureUnit
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexBordeId",
                        DataType = DbType.Int32,
                        Value = boex.BoexBordeId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexPritId",
                        DataType = DbType.Int32,
                        Value = boex.BoexPritId
                    }
                }
            };

            boex.BoexId = _adoContext.ExecuteScalar<int>(model);

            _adoContext.Dispose();
        }

        public void Remove(BookingOrderDetailExtra boex)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Booking.Booking_order_detail_extra WHERE boex_id = @boexId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexId",
                        DataType = DbType.Int32,
                        Value = boex.BoexId
                    }
                }
               
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }
    }
}
