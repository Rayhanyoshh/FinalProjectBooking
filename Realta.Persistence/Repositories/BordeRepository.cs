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

        public void Edit(Booking_order_detail borde)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking_order_detail> FindAllBorde()
        {
            IEnumerator<Booking_order_detail> dataSet = FindAll<Booking_order_detail>("SELECT * From Booking.booking_order_detail");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
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
            throw new NotImplementedException();
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
                        Value = borde.Borde_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }
    }
}
