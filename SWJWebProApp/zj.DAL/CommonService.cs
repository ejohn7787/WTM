using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace zj.DAL
{
    /// <summary>
    /// 与数据接口的访问通用服务
    /// </summary>
    public  class CommonService
    {
        private Cache cache = new Cache();
        /// <summary>
        /// 通用的访问接口的GET方法,得到JSON字符串。
        /// </summary>
        /// <param name="apiUrl">接口的地址</param>
        /// <returns></returns>
        public string GetDataFromSWJByApi(string apiUrl)
        {
            string responseData = string.Empty;     //用于接收响应的数据
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(apiUrl);  //初始化新的HTTPRequest对象
                httpWebRequest.ContentType = "application/json";  //设置请求内容的类型为JSON格式
                httpWebRequest.Method = "GET";                    //设置请求的方法
                
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse(); //获取返回API对象
                Stream stream = httpWebResponse.GetResponseStream();             //创建流对象
                StreamReader sr = new StreamReader(stream,Encoding.UTF8);           //读取流对象
                responseData = sr.ReadToEnd();
                httpWebResponse.Close();
                stream.Close();
                sr.Close();
                
            }
            catch
            {
               return string.Empty;
            }
           return responseData;
        }
        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <param name="cacheResult">值</param>
        /// <param name="cacheTime">缓存的间隔时间</param>
        public void InsertMemoryCache( string cacheKey,object cacheResult,int cacheTime)
        {
            if(cacheResult!=null)  //值不为空
            {
                //缓存插入的内容，绝对过期为永不过期，相对过期为上次访问该键的cacheTime秒后如果没有访问，过期删除。
                cache.Insert(cacheKey, cacheResult, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(cacheTime));
            }
        }
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns>返回值</returns>
        public object ReadMemoryCache(string cacheKey)
        {
            object result = cache.Get(cacheKey);
           
            if(result!=null)
            {
                return result;
            }
            else
            {
                return null;
            }
        }


    }
}
