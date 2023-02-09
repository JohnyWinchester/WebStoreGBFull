using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreGB.Interfaces.TestAPI
{
    public interface IValuesService
    {
        IEnumerable<string> GetAll();
        int Count();
        string GetById(int id);
        void Add(string value);
        void Edit(int id, string value);
        bool Delete(int id);
    }
}
