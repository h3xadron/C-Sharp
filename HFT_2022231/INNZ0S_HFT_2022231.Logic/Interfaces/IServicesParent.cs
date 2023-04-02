using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNZ0S_HFT_2022231.Logic.Interfaces
{
    public interface IServicesParent<T>
    {
        T Create(T client);
        void Delete(int id);
        T Read(int id);
        List<T> ReadAll();
        T Update(T client);
    }
}
