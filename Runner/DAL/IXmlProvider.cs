using Runner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner.DAL
{
    public interface IXmlProvider
    {
        void AddRecord(User user);
        void UpdateRecord(User user);
        void RemoveRecord(Guid userId);
        IEnumerable<User> GetAllRecords();
        User GetRecord(Guid userId);
    }
}
