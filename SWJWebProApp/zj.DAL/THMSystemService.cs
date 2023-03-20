using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using zj.Models;

namespace zj.DAL
{
    /// <summary>
    /// 温湿度
    /// </summary>
    public  class THMSystemService
    {
        private string urlTHM = "http://23451v6g02.qicp.vip:58841/api/home/getvalue?name=THM";
        private Timer timer = new Timer();                               //定时器
        private CommonService commonService = new CommonService();    //实例化与数据接口的通用访问类
        private string thmOriginalData = string.Empty;                //存储从接口读入的原始数据
        /// <summary>
        /// 初始化定时器
        /// </summary>
        public void InitialTimer()
        {
            timer.Interval = 1000;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        /// <summary>
        /// 定时读取数据的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            thmOriginalData = commonService.GetDataFromSWJByApi(urlTHM);
            if (thmOriginalData != string.Empty)
            {
                commonService.InsertMemoryCache("thmCacheData", thmOriginalData, 1);

            }
            else //如果没有数据，放入模拟数据
            {
                commonService.InsertMemoryCache("thmCacheData", thmSysMocData(), 1);
            }
        }
        /// <summary>
        /// 如果API接口没有参数，返回一个模拟的数据
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private object thmSysMocData()
        {
            string thmSysMocData = "{Temp1:\"50\",Humdity1:\"50\",Temp2:\"50\",Humdity2:\"50\",Temp3:\"50\",Humdity3:\"50\",Temp4:\"50\",Humdity4:\"50\",Temp5:\"50\",Humdity5:\"50\",Temp6:\"50\",Humdity6:\"50\"}";
            return thmSysMocData;
        }
        /// <summary>
        /// 获取制冷站的数据，并分装到对象集合中，并返回
        /// </summary>
        /// <returns></returns>
        public List<THMSystem> THMSystems()
        {
            List<THMSystem> thmSystems = new List<THMSystem>();
            //从缓存中读取数据
            string thmReadCacheData = commonService.ReadMemoryCache("thmCacheData").ToString();
            if (thmReadCacheData != string.Empty)
            {
                thmSystems = THMSystems(thmReadCacheData);
            }
            else //如果缓存没有，直接从API读取
            {
                thmOriginalData = commonService.GetDataFromSWJByApi(urlTHM);
                thmSystems = THMSystems(thmOriginalData);
            }
            return thmSystems;
        }
        /// <summary>
        /// 将JSON字符串封装到类型集合中
        /// </summary>
        /// <param name="zlzData"></param>
        /// <returns></returns>
        private List<THMSystem> THMSystems(string thmData)
        {
            //JSON字符串反序列化为字典类型
            Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(thmData);
            List<THMSystem> thmSystems = new List<THMSystem>();
            thmSystems.Add(new THMSystem()
            {
                Temp1 = dic["Temp1"],    //1号温度
                Humdity1 = dic["Humdity1"],//1号湿度
                Temp2 = dic["Temp2"],   //2号温度
                Humdity2 = dic["Humdity2"], //2号湿度
                Temp3 = dic["Temp3"],    //3号温度
                Humdity3 = dic["Humdity3"], //3号湿度
                Temp4 = dic["Temp4"],   //4号温度
                Humdity4 = dic["Humdity4"], //4号湿度
                Temp5 = dic["Temp5"],    //5号温度
                Humdity5 = dic["Humdity5"],//5号湿度
                Temp6 = dic["Temp6"],    //6号温度
                Humdity6 = dic["Humdity6"],//6号湿度

            });
            return thmSystems;
        }
    }
}
