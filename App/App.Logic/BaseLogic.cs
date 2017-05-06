using App.Data;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Logic
{

    public class BaseLogic
    {
        private BaseAccess baseAccess;

        public BaseLogic()
        {
            baseAccess = new BaseAccess();
        }
        public ServiceResult<List<ReferenceData>> GetReferenceData(int type)
        {
            return baseAccess.GetReferenceData(type);

        }
    }
}
