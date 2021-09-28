using DapperWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Repo
{
   public interface IOffice
    {
        public Task<IEnumerable<Staff>> Get();
        public Task<Staff> Get(Guid ID);
        public Task<Staff> Create(Staff staff);
        public Task Update(Staff staff);
        public Task Delete(Guid ID);
    }
}
