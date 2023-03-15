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
using Realta.Domain.RequestFeatures;
using Realta.Persistence.Repositories.RepositoryExtensions;

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
                        " spof_description=@spofDesc, " +
                        " spof_type=@spofType, " +
                        " spof_discount=@spofDiscount, " +
                        " spof_start_date=@spofStartDate, " +
                        " spof_end_date=@spofEndDate, " +
                        " spof_min_qty=@spofMinQty, " +
                        " spof_max_qty=@spofMaxQty, " +
                        " spof_modified_date=@spofModDate " +
                        " WHERE spof_id = @spofId; ",
              CommandType=CommandType.Text,
              CommandParameters=new SqlCommandParameterModel[]
              {
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofName",
                      DataType=DbType.String,
                      Value=spof.SpofName
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofDesc",
                      DataType=DbType.String,
                      Value=spof.SpofDescription
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofType",
                      DataType=DbType.String,
                      Value=spof.SpofType
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofDiscount",
                      DataType=DbType.Decimal,
                      Value=spof.SpofDiscount
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofStartDate",
                      DataType=DbType.DateTime,
                      Value=spof.SpofStartDate
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofEndDate",
                      DataType=DbType.DateTime,
                      Value=spof.SpofEndDate
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofMinQty",
                      DataType=DbType.Int32,
                      Value=spof.SpofMinQty
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofMaxQty",
                      DataType=DbType.Int32,
                      Value=spof.SpofMaxQty
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofModDate",
                      DataType=DbType.DateTime,
                      Value=spof.SpofModifiedDate
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofId",
                      DataType=DbType.Int32,
                      Value=spof.SpofId
                  }
              }
            };
            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<SpecialOffers> FindAllSpof()
        {
            IEnumerator<SpecialOffers> enumerator = FindAll<SpecialOffers>
                ("select " +
                "spof_id AS SpofId, " +
                "spof_name AS SpofName, " +
                "spof_description AS SpofDescription, " +
                "spof_type AS SpofType, " +
                "spof_discount AS SpofDiscount, " +
                "spof_start_date AS SpofStartDate, " +
                "spof_end_date AS SpofEndDate, " +
                "spof_min_qty AS SpofMinQty, " +
                "spof_max_qty AS SpofMaxQty, " +
                "spof_modified_date AS SpofModifiedDate" +
                " FROM Booking.Special_offers");
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
                CommandText = "SELECT " +
                "spof_id AS SpofId " +
                "spof_name AS SpofName " +
                "spof_description AS SpofDescription " +
                "spof_type AS SpofType " +
                "spof_discount AS SpofDiscount " +
                "spof_start_date AS SpofStartDate " +
                "spof_end_date AS SpofEndDate " +
                "spof_min_qty AS SpofMinQty " +
                "spof_max_qty AS SpofMaxQty " +
                "spof_modified_date AS SpofModifiedDate" +
                " FROM Booking.Special_offers",
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

        public async Task<IEnumerable<SpecialOffers>> GetSpofPaging(SpecialOfferParameters specialOfferparameters)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = @"select " +
                              "spof_id AS SpofId, " +
                              "spof_name AS SpofName, " +
                              "spof_description AS SpofDescription, " +
                              "spof_type AS SpofType, " +
                              "spof_discount AS SpofDiscount, " +
                              "spof_start_date AS SpofStartDate, " +
                              "spof_end_date AS SpofEndDate, " +
                              "spof_min_qty AS SpofMinQty, " +
                              "spof_max_qty AS SpofMaxQty, " +
                              "spof_modified_date AS SpofModifiedDate" +
                              " FROM Booking.Special_offers " +
                              " ORDER BY SpofId offset @pageNo Rows fetch next @pageSize rows only",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {

                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@pageNo",
                        DataType = DbType.Int32,
                        Value = specialOfferparameters.PageNumber
                    },
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@pageSize",
                        DataType = DbType.Int32,
                        Value = specialOfferparameters.PageSize
                    }
                }
                
            };
            IAsyncEnumerator<SpecialOffers> dataSet = FindAllAsync<SpecialOffers>(model);
            var item = new List<SpecialOffers>();

            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }

            return item;
        }

        public async Task<PagedList<SpecialOffers>> GetSpofPageList(SpecialOfferParameters specialOfferparameters)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = @"select " +
                              "spof_id AS SpofId, " +
                              "spof_name AS SpofName, " +
                              "spof_description AS SpofDescription, " +
                              "spof_type AS SpofType, " +
                              "spof_discount AS SpofDiscount, " +
                              "spof_start_date AS SpofStartDate, " +
                              "spof_end_date AS SpofEndDate, " +
                              "spof_min_qty AS SpofMinQty, " +
                              "spof_max_qty AS SpofMaxQty, " +
                              "spof_modified_date AS SpofModifiedDate" +
                              " FROM Booking.Special_offers WHERE spof_max_qty between @minQty and @maxQty " +
                              " ORDER BY SpofId offset @pageNo Rows fetch next @pageSize rows only",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[]
                {

                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@pageNo",
                        DataType = DbType.Int32,
                        Value = specialOfferparameters.PageNumber
                    },
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@pageSize",
                        DataType = DbType.Int32,
                        Value = specialOfferparameters.PageSize
                    },
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@minQty",
                        DataType = DbType.Int32,
                        Value = specialOfferparameters.MinQty
                    },
                    new SqlCommandParameterModel()
                    {
                        ParameterName = "@maxQty",
                        DataType = DbType.Int32,
                        Value = specialOfferparameters.MaxQty
                    }
                }
            };
            var spof = await GetAllAsync<SpecialOffers>(model);
            var totalRow = FindAllSpof().Count();

            // var spofSearch = spof.Where(p =>
            //     p.SpofName.ToLower().Contains(specialOfferparameters.SearchTerm.Trim().ToLower()));
            var spofSearch = spof.AsQueryable()
                .SearchSpof(specialOfferparameters.SearchTerm)
                .Sort(specialOfferparameters.OrderBy);
            
            return new PagedList<SpecialOffers>(spofSearch.ToList(), totalRow,specialOfferparameters.PageNumber,
                specialOfferparameters.PageSize);
        }

        public SpecialOffers FindSpofById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "SELECT " +
                "spof_id AS SpofId, " +
                "spof_name AS SpofName, " +
                "spof_description AS SpofDescription, " +
                "spof_type AS SpofType, " +
                "spof_discount AS SpofDiscount, " +
                "spof_start_date AS SpofStartDate, " +
                "spof_end_date AS SpofEndDate, " +
                "spof_min_qty AS SpofMinQty, " +
                "spof_max_qty AS SpofMaxQty, " +
                "spof_modified_date AS SpofModifiedDate " +
                " FROM Booking.Special_offers WHERE spof_id = @spofId",
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
                      Value=spof.SpofName
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofDesc",
                      DataType=DbType.String,
                      Value=spof.SpofDescription
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofType",
                      DataType=DbType.String,
                      Value=spof.SpofType
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofDiscount",
                      DataType=DbType.Decimal,
                      Value=spof.SpofDiscount
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofStartDate",
                      DataType=DbType.DateTime,
                      Value=spof.SpofStartDate
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofEndDate",
                      DataType=DbType.DateTime,
                      Value=spof.SpofEndDate
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofMinQty",
                      DataType=DbType.Int32,
                      Value=spof.SpofMinQty
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofMaxQty",
                      DataType=DbType.Int32,
                      Value=spof.SpofMaxQty
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofModDate",
                      DataType=DbType.DateTime,
                      Value=spof.SpofModifiedDate
                  },
                  new SqlCommandParameterModel()
                  {
                      ParameterName="@spofId",
                      DataType=DbType.Int32,
                      Value=spof.SpofId
                  }
                }
            };
            spof.SpofId= _adoContext.ExecuteScalar<int>(model);
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
                        Value = spof.SpofId
                    }
                }
            };
        }
    }
}
