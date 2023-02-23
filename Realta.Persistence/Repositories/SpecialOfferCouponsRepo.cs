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
    internal class SpecialOfferCouponsRepo : RepositoryBase<SpecialOfferCoupons>, ISpecialOfferCouponsRepo

    {
        public SpecialOfferCouponsRepo(AdoDbContext AdoContext) : base(AdoContext)
        {
        }

        public void Edit(SpecialOfferCoupons soco)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "UPDATE Booking.Special_offer_coupons SET soco_borde_id = @socoBordeId,soco_spof_id = @socoSpofId WHERE soco_id = @socoId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@socoId",
                        DataType = DbType.Int32,
                        Value = soco.soco_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@socoBordeId",
                        DataType = DbType.Int32,
                        Value = soco.soco_borde_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@socoSpofId",
                        DataType = DbType.Int32,
                        Value = soco.soco_spof_id
                    }
                }
            };

            _adoContext.ExecuteNonQuery(model);
            _adoContext.Dispose();
        }

        public IEnumerable<SpecialOfferCoupons> FindAllSoco()
        {
            IEnumerator<SpecialOfferCoupons> dataSet = FindAll<SpecialOfferCoupons>("select * from Booking.Special_offer_coupons");

            while (dataSet.MoveNext())
            {
                var data = dataSet.Current;
                yield return data;
            }
        }

        public async Task<IEnumerable<SpecialOfferCoupons>> FindAllSocoAsync()
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "select * from Booking.Special_offer_coupons;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] { }

            };

            IAsyncEnumerator<SpecialOfferCoupons> dataSet = FindAllAsync<SpecialOfferCoupons>(model);

            var item = new List<SpecialOfferCoupons>();


            while (await dataSet.MoveNextAsync())
            {
                item.Add(dataSet.Current);
            }


            return item;
        }

        public SpecialOfferCoupons FindSocoById(int id)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "select * from Booking.Special_offer_coupons where soco_id=@socoId order by soco_id asc;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@socoId",
                        DataType = DbType.Int32,
                        Value = id
                    }
                }
            };

            var dataSet = FindByCondition<SpecialOfferCoupons>(model);

            SpecialOfferCoupons? item = dataSet.Current;

            while (dataSet.MoveNext())
            {
                item = dataSet.Current;
            }


            return item;
        }

        public void Insert(SpecialOfferCoupons soco)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "INSERT INTO Booking.Special_offer_coupons (soco_borde_id, soco_spof_id) VALUES(@socoBordeId, @socoSpofId);" +
                " SELECT CAST(scope_identity() as int);",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@socoBordeId",
                        DataType = DbType.Int32,
                        Value = soco.soco_borde_id
                    },
                    new SqlCommandParameterModel() {
                        ParameterName = "@socoSpofId",
                        DataType = DbType.Int32,
                        Value = soco.soco_spof_id
                    }
                }
            };

            soco.soco_id = _adoContext.ExecuteScalar<int>(model);

            _adoContext.Dispose();
        }

        public void Remove(SpecialOfferCoupons soco)
        {
            SqlCommandModel model = new SqlCommandModel()
            {
                CommandText = "DELETE FROM Booking.Special_offer_coupons WHERE soco_id = @socoId;",
                CommandType = CommandType.Text,
                CommandParameters = new SqlCommandParameterModel[] {
                    new SqlCommandParameterModel() {
                        ParameterName = "@socoId",
                        DataType = DbType.Int32,
                        Value = soco.soco_id
                    }
                }
            };
        }
    }
}
