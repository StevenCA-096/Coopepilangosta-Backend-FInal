using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IEntryRepository : IGenericRepository<Entry>
    {
        public int InsertEntry(Entry entry);
        public int CheckEntryDone(int idProducerOrder, int idProduct);
        public List<IGrouping<int, Entry>> GetEntries();
    }
}
