using Realta.Domain.Entities;
using Realta.Domain.Repositories;
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
    internal class SpecialOffersRepo : RepositoryBase<SpecialOffers>,ISpecialOffersRepo
    {
        public SpecialOffersRepo(AdoDbContext adoContext) : base(adoContext)
        {
        }

        public void Edit(SpecialOffers spof)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
              CommandText= "Update Booking.Special_offers " +
                        " SET " +
                        " spof_name=@spofName, " +
                        "spof_description=@spofDesc, " +
                        "spof_type=@spofType, " +
                        "spof_discount=@spofDiscount, " +
                        "spof_start_date=@spofStartDate, " +
                        "spof_end_date=@spofEndDate, " +
                        "spof_min_qty=@spofMinQty, " +
                        "spof_max_qty=@spofMaxQty, " +
                        "spof_modified_date=@spofModDate " +
                        " WHERE spof_id = @spofId; ",
              CommandType=CommandType.Text,
              CommandParameters=new SqlCommandParameterModel[]
              {
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofName",
                      DataType=DbType.String,
                      Value=spof.spof_name
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofDesc",
                      DataType=DbType.String,
                      Value=spof.spof_description
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofType",
                      DataType=DbType.String,
                      Value=spof.spof_type
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofDiscount",
                      DataType=DbType.Decimal,
                      Value=spof.spof_discount
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofStartDate",
                      DataType=DbType.DateTime,
                      Value=spof.spof_start_date
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofEndDate",
                      DataType=DbType.DateTime,
                      Value=spof.spof_end_date
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofMinQty",
                      DataType=DbType.Int32,
                      Value=spof.spof_min_qty
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofMaxQty",
                      DataType=DbType.Int32,
                      Value=spof.spof_max_qty
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofModDate",
                      DataType=DbType.DateTime,
                      Value=spof.spof_modified_date
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofId",
                      DataType=DbType.Int32,
                      Value=spof.spof_id
                  }
              }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<SpecialOffers> FindAllSpof()
        {
            IEnumerator<SpecialOffers> enumerator = FindAll<SpecialOffers>("select * from Booking.Special_offers");
            while (enumerator.MoveNext())
            {
                var data = enumerator.Current;
                yield return data;
            }
        }

        public async Task<IEnumerable<SpecialOffers>> FindAllSpofAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "select * from Booking.Special_offers;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }
            };
            IAsyncEnumerator<SpecialOffers> dataSet = FindAllAsync<SpecialOffers>(model);
            var item = new List<SpecialOffers>();
            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }
            return item;
        }

        public SpecialOffers FindSpofById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT * FROM Booking.special_offers WHERE spof_id = @spofId",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                new SqlCommandParameterModel()
                  {
                      ParameterName="@spofId",
                      DataType=DbType.Int32,
                      Value=id
                  }}
            };
            var dataSet = FindByCondition<SpecialOffers>(model);

            SpecialOffers? item = dataSet.Current;

            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }

            return item;
        }

        public void Insert(SpecialOffers spof)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "INSERT INTO" +
                " Booking.special_offers " +
                "(" +
                "spof_name, " +
                "spof_description, " +
                "spof_type, " +
                "spof_discount, " +
                "spof_start_date, " +
                "spof_end_date, " +
                "spof_min_qty, " +
                "spof_max_qty, " +
                "spof_modified_date " +
                ")" +
                "VALUES " +
                "(" +
                "@spofName, " +
                "@spofDesc, " +
                "@spofType, " +
                "@spofDiscount, " +
                "@spofStartDate, " +
                "@spofEndDate, " +
                "@spofMinQty, " +
                "@spofMaxQty, " +
                "@spofModDate " +
                "); "+
                "SELECT CAST(scope_identity() AS Integer);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofName",
                      DataType=DbType.String,
                      Value=spof.spof_name
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofDesc",
                      DataType=DbType.String,
                      Value=spof.spof_description
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofType",
                      DataType=DbType.String,
                      Value=spof.spof_type
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofDiscount",
                      DataType=DbType.Decimal,
                      Value=spof.spof_discount
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofStartDate",
                      DataType=DbType.DateTime,
                      Value=spof.spof_start_date
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofEndDate",
                      DataType=DbType.DateTime,
                      Value=spof.spof_end_date
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofMinQty",
                      DataType=DbType.Int32,
                      Value=spof.spof_min_qty
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofMaxQty",
                      DataType=DbType.Int32,
                      Value=spof.spof_max_qty
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofModDate",
                      DataType=DbType.DateTime,
                      Value=spof.spof_modified_date
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofId",
                      DataType=DbType.Int32,
                      Value=spof.spof_id
                  }
                }
            };
            spof.spof_id= _adoContext.ExecuteScalar<int>(model);
            _adoContext.Dispose();
        }

        public void Remove(SpecialOffers spof)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "delete from Booking.special_offers where spof_id =@spofId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@spofId",
                        DataType = DbType.Int32,
                        Value = spof.spof_id
                    }
                }
            };
        }
    }
}
