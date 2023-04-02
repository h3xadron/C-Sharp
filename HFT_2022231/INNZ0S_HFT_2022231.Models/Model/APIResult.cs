using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INNZ0S_HFT_2022231.Models.Model
{
    public class APIResult
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public APIResult()
        {
        }

        public APIResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}
