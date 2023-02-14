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
    internal class BoexRepository : RepositoryBase<Booking_order_detail_extra>, IBoexRepository

    {
        public BoexRepository(AdoDbContext AdoContext) : base(AdoContext)
        {
        }

        public void Edit(Booking_order_detail_extra boex)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Booking.Booking_order_detail_extra SET boex_price = @boexPrice, boex_qty = @boexQty, boex_subtotal = @boexSubtotal, boex_measure_unit = @boexMeasureUnit, boex_borde_id = @boexBordeId, boex_prit_id = @boexPritId WHERE boex_id = @boexId",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexId",
                        DataType = DbType.Int32,
                        Value = boex.boex_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexPrice",
                        DataType = DbType.Decimal,
                        Value = boex.boex_price
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexQty",
                        DataType = DbType.Int16,
                        Value = boex.boex_qty
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexSubtotal",
                        DataType = DbType.Decimal,
                        Value = boex.boex_subtotal
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexMeasureUnit",
                        DataType = DbType.String,
                        Value = boex.boex_measure_unit
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexBordeId",
                        DataType = DbType.Int32,
                        Value = boex.boex_borde_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexPritId",
                        DataType = DbType.Int32,
                        Value = boex.boex_prit_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<Booking_order_detail_extra> FindAllBoex()
        {
            IEnumerator<Booking_order_detail_extra> dataSet = FindAll<Booking_order_detail_extra>("SELECT * From Booking.booking_order_detail_extra");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }

        public async Task<IEnumerable<Booking_order_detail_extra>> FindAllBoexAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT * From Booking.booking_order_detail_extra;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }

            };

            IAsyncEnumerator<Booking_order_detail_extra> dataSet = FindAllAsync<Booking_order_detail_extra>(model);

            var item = new List<Booking_order_detail_extra>();


            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }


            return item;
        }

        public Booking_order_detail_extra FindBoexById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT * FROM Booking.booking_order_detail_extra where boex_id=@boexId order by boex_id asc;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var dataSet = FindByCondition<Booking_order_detail_extra>(model);

            Booking_order_detail_extra? item = dataSet.Current;

            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }


            return item;
        }

        public void Insert(Booking_order_detail_extra boex)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "INSERT INTO Booking.Booking_order_detail_extra (boex_price, boex_qty, boex_subtotal, boex_measure_unit, boex_borde_id, boex_prit_id) " +
                              "VALUES (@boexPrice, @boexQty, @boexSubtotal, @boexMeasureUnit, @boexBordeId, @boexPritId)",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexId",
                        DataType = DbType.Int32,
                        Value = boex.boex_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexPrice",
                        DataType = DbType.Decimal,
                        Value = boex.boex_price
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexQty",
                        DataType = DbType.Int16,
                        Value = boex.boex_qty
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexSubtotal",
                        DataType = DbType.Decimal,
                        Value = boex.boex_subtotal
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexMeasureUnit",
                        DataType = DbType.String,
                        Value = boex.boex_measure_unit
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexBordeId",
                        DataType = DbType.Int32,
                        Value = boex.boex_borde_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexPritId",
                        DataType = DbType.Int32,
                        Value = boex.boex_prit_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public void Remove(Booking_order_detail_extra boex)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Booking.Booking_order_detail_extra WHERE boex_id = @boexId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@boexId",
                        DataType = DbType.Int32,
                        Value = boex.boex_id
                    }
                }
            };
        }
    }
}
