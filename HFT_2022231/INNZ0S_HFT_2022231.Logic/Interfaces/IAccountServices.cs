using INNZ0S_HFT_2022231.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNZ0S_HFT_2022231.Logic.Interfaces
{
    public interface IAccountServices : IServicesParent<Account>
    {
        IEnumerable<Account> AccountsMadeByTexanClient();
    }
}
