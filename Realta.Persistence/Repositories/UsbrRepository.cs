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
                CommandText = "UPDATE Booking.user_breakfast " +
                " SET " +
                " usbr_modified_date = @usbr_modified_date,"+
                " usbr_total_vacant = @usbr_total_vacant" +
                " WHERE usbr_borde_id = @usbr_borde_id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_borde_id",
                        DataType = DbType.Int32,
                        Value = usbr.usbr_borde_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_modified_date",
                        DataType = DbType.DateTime,
                        Value = usbr.usbr_modified_date
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_total_vacant",
                        DataType = DbType.Int16,
                        Value = usbr.usbr_total_vacant
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
                CommandText = "select * from Booking.User_breakfast where usbr_borde_id=@usbr_borde_id;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_borde_id",
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
                CommandText = "INSERT INTO Booking.user_breakfast (usbr_borde_id, usbr_modified_date, usbr_total_vacant) " +
                " VALUES (@usbr_borde_id, @usbr_modified_date, @usbr_total_vacant);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_borde_id",
                        DataType = DbType.Int32,
                        Value = usbr.usbr_borde_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_modified_date",
                        DataType = DbType.DateTime,
                        Value = usbr.usbr_modified_date
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_total_vacant",
                        DataType = DbType.Int16,
                        Value = usbr.usbr_total_vacant
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public void Remove(User_breakfast usbr)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Booking.user_breakfast" +
                "WHERE usbr_modified_date=@usbr_modified_date AND usbr_borde_id=@usbr_borde_id",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_borde_id",
                        DataType = DbType.Int32,
                        Value = usbr.usbr_borde_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_modified_date",
                        DataType = DbType.DateTime,
                        Value = usbr.usbr_modified_date
                    }
                }
            };
        }
    }
}
