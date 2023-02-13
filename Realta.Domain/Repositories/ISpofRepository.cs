using Realta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Repositories
{
    public interface ISpofRepository
    {
        IEnumerable<Special_offers> FindAllSpof();
        Task<IEnumerable<Special_offers>> FindAllSpofAsync();
        Special_offers FindSpofById(int id);
        void Insert(Special_offers spof);
        void Edit(Special_offers spof);
        void Remove(Special_offers spof);
    }
}
