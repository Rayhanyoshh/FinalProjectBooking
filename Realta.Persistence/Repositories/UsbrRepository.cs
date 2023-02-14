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
    internal class UsbrRepository : RepositoryBase<User_breakfast>, IUsbrRepository

    {
        public UsbrRepository(AdoDbContext AdoContext) : base(AdoContext)
        {
        }

        public void Edit(User_breakfast usbr)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Booking.User_breakfast SET usbr_borde_id = @usbrBordeId,usbr_spof_id = @usbrSpofId WHERE usbr_id = @usbrId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbrBorde_id",
                        DataType = DbType.Int32,
                        Value = usbr.Usbr_borde_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<User_breakfast> FindAllUsbr()
        {
            IEnumerator<User_breakfast> dataSet = FindAll<User_breakfast>("select * from Booking.User_breakfast");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }

        public async Task<IEnumerable<User_breakfast>> FindAllUsbrAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "select * from Booking.User_breakfast;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }

            };

            IAsyncEnumerator<User_breakfast> dataSet = FindAllAsync<User_breakfast>(model);

            var item = new List<User_breakfast>();


            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }


            return item;
        }

        public User_breakfast FindUsbrById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "select * from Booking.User_breakfast where usbr_id=@usbrId order by usbr_id asc;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbrId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var dataSet = FindByCondition<User_breakfast>(model);

            User_breakfast? item = dataSet.Current;

            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }


            return item;
        }

        public void Insert(User_breakfast usbr)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "INSERT INTO Booking.User_breakfast (usbr_borde_id, usbr_spof_id) VALUES(@usbrBordeId, @usbrSpofId);" +
                " SELECT CAST(scope_identity() as int);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbrBordeId",
                        DataType = DbType.Int32,
                        Value = usbr.Usbr_borde_id
                    }
                }
            };

            usbr.Usbr_borde_id = _adoContext.ExecuteScalar<int>(model);

            _adoContext.Dispose();
        }

        public void Remove(User_breakfast usbr)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Booking.User_breakfast WHERE usbr_id = @usbrId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbrId",
                        DataType = DbType.Int32,
                        Value = usbr.Usbr_borde_id
                    }
                }
            };
        }
    }
}
