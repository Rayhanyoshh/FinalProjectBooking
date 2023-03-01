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
    internal class UserBreakfastRepo : RepositoryBase<UserBreakfast>, IUserBreakfastRepo

    {
        public UserBreakfastRepo(AdoDbContext AdoContext) : base(AdoContext)
        {
        }

        public void Edit(UserBreakfast usbr)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Booking.user_breakfast " +
                " SET " +
                " usbr_total_vacant = @usbr_total_vacant" +
                " WHERE " +
                " usbr_borde_id = @usbr_borde_id " +
                " AND " +
                " usbr_modified_date = @usbr_modified_date; ",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_borde_id",
                        DataType = DbType.Int32,
                        Value = usbr.UsbrBordeId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_modified_date",
                        DataType = DbType.Date,
                        Value = usbr.UsbrModifiedDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_total_vacant",
                        DataType = DbType.Int16,
                        Value = usbr.UsbrTotalVacant
                    }
                }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<UserBreakfast> FindAllUsbr()
        {                                                                                                                                       
            IEnumerator<UserBreakfast> dataSet = FindAll<UserBreakfast>
                ("SELECT" +
                " usbr_borde_id AS UsbrBordeId," +
                " usbr_modified_date AS UsbrModifiedDate, " +
                " usbr_total_vacant AS UsbrTotalVacant " +
                " FROM Booking.User_breakfast ");
            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }

        public async Task<IEnumerable<UserBreakfast>> FindAllUsbrAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT" +
                " usbr_borde_id AS UsbrBordeID," +
                " usbr_modified_date AS UsbrModifiedDate, " +
                " usbr_total_vacant AS UsbrTotalVacant " +
                " FROM Booking.User_breakfast ",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }

            };
            IAsyncEnumerator<UserBreakfast> dataSet = FindAllAsync<UserBreakfast>(model);
            var item = new List<UserBreakfast>();
            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }
            return item;
        }

        public UserBreakfast FindUsbrByIdDate(int id,DateTime date)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT usbr_total_vacant AS UsbrTotalVacant" +
                " FROM Booking.User_breakfast where usbr_borde_id=@usbr_borde_id and usbr_modified_date=@usbr_modified_date",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_borde_id",
                        DataType = DbType.Int32,
                        Value = id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_modified_date",
                        DataType = DbType.Date,
                        Value = date
                    }
                }
            };
            var dataSet = FindByCondition<UserBreakfast>(model);
            UserBreakfast? item = dataSet.Current;
            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }
            return item;
        }

        public void Insert(UserBreakfast usbr)
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
                        Value = usbr.UsbrBordeId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_modified_date",
                        DataType = DbType.Date,
                        Value = usbr.UsbrModifiedDate
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_total_vacant",
                        DataType = DbType.Int16,
                        Value = usbr.UsbrTotalVacant
                    }
                }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public void Remove(UserBreakfast usbr)
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
                        Value = usbr.UsbrBordeId
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@usbr_modified_date",
                        DataType = DbType.Date,
                        Value = usbr.UsbrModifiedDate
                    }
                }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }
    }
}
