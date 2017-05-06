using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity
{
    public class ServiceResult<T>
    {
        public Status ResultStatus { get; set; }
        public T Result { get; set; }
    }
    public class Status
    {
        public Status(bool isSuccess, int returnID, string returnMessage)
        {
            IsSuccess =isSuccess;
            ReturnID = returnID;
            ReturnMessage = ReturnMessage;
        }
        public Status(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public Status(bool isSuccess, string returnMessage)
        {
            IsSuccess = isSuccess;
            ReturnMessage = ReturnMessage;
        }
        public int ReturnID { get; set; }
        public string ReturnMessage { get; set; }
        public bool IsSuccess { get; set; }
    }
}
