using App.Entity;
using App.Logic;
using App.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace App.UI
{
    public interface IAppCacheManager
    {
        List<ReferenceData> GetReferenceDataListByType(ReferenceDataType type);
        void ClearCache(string CacheKey);
       
    }

    public class APPCacheManager:IAppCacheManager
    {
        private const string CACHE_REFERENCE_DATA = "CACHE_REFERENCE_DATA";
        private BaseLogic baseLogic;
        private IAppLogManager iAppLogManager;
        public APPCacheManager()
        {
            baseLogic = new BaseLogic();
            iAppLogManager = new AppLogManager();
        }

        private object GetObjectForKeyOf(string Key)
        {
            return HttpContext.Current.Cache[Key];

        }

        private void Insert(string key, object value, DateTime cacheTime)
        {
            var cache = GetObjectForKeyOf(key);

            if (cache == null)
                HttpContext.Current.Cache.Insert(key, value, null, cacheTime, System.Web.Caching.Cache.NoSlidingExpiration);
            else
                HttpContext.Current.Cache[key] = value;
        }
        public void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        public static void RemoveAll()
        {
            System.Collections.IDictionaryEnumerator CacheKeys = System.Web.HttpContext.Current.Cache.GetEnumerator();
            while (CacheKeys.MoveNext())
            {
                var currentKey = CacheKeys.Key.ToString();
                System.Web.HttpContext.Current.Cache.Remove(currentKey);
            }
        }


        public List<ReferenceData> GetReferenceDataListByType(ReferenceDataType type)
        {
            return GetReferenceData((int)type);
        }

        public void ClearCache(string CacheKey)
        {
            throw new NotImplementedException();
        }
        private List<ReferenceData> GetReferenceData(int dataType)
        {
            DateTime cacheExpireTime = DateTime.Now.AddDays(1);

            string cacheKey = CACHE_REFERENCE_DATA + dataType.ToString();

            try
            {
                var cashedData = GetObjectForKeyOf(cacheKey) as List<ReferenceData>;
                if (cashedData != null)
                {
                    return cashedData;
                }
                else
                {

                    var retResult = baseLogic.GetReferenceData(dataType);

                    if (retResult !=  null && retResult.ResultStatus != null && retResult.ResultStatus.IsSuccess ==true && retResult.Result.Count > 0)
                    {
                        var dataFromAPI = retResult.Result.ToList();
                        if (dataFromAPI != null)
                        {
                            Insert(cacheKey, dataFromAPI.ToList(), cacheExpireTime);
                            return dataFromAPI.ToList();
                        }
                    }
                    else
                    {
                        iAppLogManager.WriteLog("Cash referance data error occred");
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                iAppLogManager.WriteLog(ex);
                throw ex;
            }
        }

    }
    public enum ReferenceDataType
    {
        TEXT_DATA_LIST = 1,
      
    }

}
