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
    /// 制冷站数据访问
    /// </summary>
    public class ZLZSystemService
    {
        private string urlZLZ = "http://23451v6g02.qicp.vip:58841/api/home/getvalue?name=ZLZ";
        private Timer timer = new Timer(); //定时器
        private CommonService commonService = new CommonService();    //实例化与数据接口的通用访问类
        private string zlzOriginalData = string.Empty;  //存储从接口读入的原始数据
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
            zlzOriginalData = commonService.GetDataFromSWJByApi(urlZLZ);
            if (zlzOriginalData != string.Empty)
            {
                commonService.InsertMemoryCache("zlzCacheData", zlzOriginalData, 1);

            }
            else //如果没有数据，放入模拟数据
            {
                commonService.InsertMemoryCache("zlzCacheData", zlzSysMocData(), 1);
            }
        }
        /// <summary>
        /// 如果API接口没有参数，返回一个模拟的数据
        /// </summary>
        /// <returns></returns>
        private object zlzSysMocData()
        {
            string zlzSysMocData = "{LSJSQTemp:\"52\",LSJSQPre:\"50\",LSFSQTemp:\"52\",LSFSQPre:\"50\",LRSJSQTemp:\"50\",LRSJSQPre:\"50\",LRSFSQTemp:\"50\",LRSFSQPre:\"50\",HRJZInTemp:\"50\",HRJZInPre:\"50\",HRJZOutTemp:\"50\",HRJZOutPre:\"50\",LDB1Fre:\"50\",LDB1Current:\"50\",LDB2Fre:\"50\",LDB2Current:\"50\",LDB3Fre:\"50\",LDB3Current:\"50\",LDB4Fre:\"50\",LDB4Current:\"50\",LDB5Fre:\"50\",LDB5Current:\"50\",LQJ1Temp:\"50\",LQJ1Pre:\"50\",LQJ2Temp:\"50\",LQJ2Pre:\"50\",LQJ3Temp:\"50\",LQJ3Pre:\"50\",LQJ4Temp:\"50\",LQJ4Pre:\"50\",LQJ5Temp:\"50\",LQJ5Pre:\"50\",LQB1Current:\"50\",LQB2Current:\"50\",LQB3Current:\"50\",LQB4Current:\"50\",LQB5Current:\"50\",LQB6Current:\"50\",LQT1Level:\"50\",LQT2Level:\"50\",LQT3Level:\"50\",LQT4Level:\"50\",LQT5Level:\"50\",LDB1State:1,LDB2State:1,LDB3State:1,LDB4State:1,LDB5State:1,LQJZ1State:1,LQJZ2State:1,LQJZ3State:1,LQJZ4State:1,LQJZ5State:1,LQB1State:1,LQB2State:1,LQB3State:1,LQB4State:1,LQB5State:1,LQB6State:1}";//JSON字符串的数据
            return zlzSysMocData;
        }
        /// <summary>
        /// 获取制冷站的数据，并分装到对象集合中，并返回
        /// </summary>
        /// <returns></returns>
        public List<ZLZSystem> ZLZSystems()
        {
            List<ZLZSystem> zlzSystems = new List<ZLZSystem>();
            //从缓存中读取数据
            string zlzReadCacheData = commonService.ReadMemoryCache("zlzCacheData").ToString();
            if (zlzReadCacheData != string.Empty)
            {
                zlzSystems = ZLZSystems(zlzReadCacheData);
            }
            else //如果缓存没有，直接从API读取
            {
                zlzOriginalData = commonService.GetDataFromSWJByApi(urlZLZ);
                zlzSystems = ZLZSystems(zlzOriginalData);
            }
            return zlzSystems;
        }
        /// <summary>
        /// 将JSON字符串封装到类型集合中
        /// </summary>
        /// <param name="zlzData"></param>
        /// <returns></returns>
        private List<ZLZSystem> ZLZSystems(string zlzData)
        {
            //JSON字符串反序列化为字典类型
            Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(zlzData);
            List<ZLZSystem> zlzSystems = new List<ZLZSystem>();
            zlzSystems.Add(new ZLZSystem()
            {
                
                LSJSQTemp = dic["LSJSQTemp"],     //冷水集水器温度
                LSJSQPre = dic["LSJSQPre"],        //冷水集水器压力
                LSFSQTemp = dic["LSFSQTemp"],      //冷水分水器温度
                LSFSQPre = dic["LSFSQPre"],        //冷水分水器压力
                LRSJSQTemp = dic["LRSJSQTemp"],      //冷热水集水器温度
                LRSJSQPre = dic["LRSJSQPre"],        //冷热水集水器压力
                LRSFSQTemp = dic["LRSFSQTemp"],      //冷热水分水器温度
                LRSFSQPre = dic["LRSFSQPre"],      //冷热水分水器压力
                HRJZInTemp = dic["HRJZInTemp"],        //换热机组进口温度
                HRJZInPre = dic["HRJZInPre"],         //换热机组进口压力
                HRJZOutTemp = dic["HRJZOutTemp"],     //换热机组出口温度
                HRJZOutPre = dic["HRJZOutPre"],         //换热机组出口压力
                LDB1Fre = dic["LDB1Fre"],        //1号冷冻泵频率
                LDB1Current = dic["LDB1Fre"],          //1号冷冻泵电流
                LDB2Fre = dic["LDB2Fre"],         //2号冷冻泵频率
                LDB2Current = dic["LDB2Current"],          //2号冷冻泵电流
                LDB3Fre = dic["LDB3Fre"],           //3号冷冻泵频率
                LDB3Current = dic["LDB3Current"],           //3号冷冻泵电流
                LDB4Fre = dic["LDB4Fre"],           //4号冷冻泵频率
                LDB4Current = dic["LDB4Current"],           //4号冷冻泵电流
                LDB5Fre = dic["LDB5Fre"],           //5号冷冻泵频率
                LDB5Current = dic["LDB5Current"],          //5号冷冻泵电流
                LQJ1Temp = dic["LQJ1Temp"],          //1号冷却机组温度
                LQJ1Pre = dic["LQJ1Pre"],           //1号冷却机组压力
                LQJ2Temp = dic["LQJ2Temp"],         //2号冷却机组温度
                LQJ2Pre = dic["LQJ2Pre"],             //2号冷却机组压力
                LQJ3Temp = dic["LQJ3Temp"],          //3号冷却机组温度
                LQJ3Pre = dic["LQJ3Pre"],           //3号冷却机组压力
                LQJ4Temp = dic["LQJ4Temp"],          //4号冷却机组温度
                LQJ4Pre = dic["LQJ4Pre"],           //4号冷却机组压力
                LQJ5Temp = dic["LQJ5Temp"],          //5号冷却机组温度
                LQJ5Pre = dic["LQJ5Pre"],           //5号冷却机组压力
                LQB1Current = dic["LQB1Current"],        //1号冷却泵电流
                LQB2Current = dic["LQB2Current"],       //2号冷却泵电流
                LQB3Current = dic["LQB3Current"],       //3号冷却泵电流
                LQB4Current = dic["LQB4Current"],        //4号冷却泵电流
                LQB5Current = dic["LQB5Current"],         //5号冷却泵电流
                LQB6Current = dic["LQB6Current"],        //6号冷却泵电流
                LQT1Level = dic["LQT1Level"],         //冷却塔1液位
                LQT2Level = dic["LQT2Level"],         //冷却塔2液位
                LQT3Level = dic["LQT3Level"],         //冷却塔3液位
                LQT4Level = dic["LQT4Level"],        //冷却塔4液位
                LQT5Level = dic["LQT5Level"],        //冷却塔5液位

                 LDB1State = Convert.ToInt32(dic["LDB1State"]),           //1号冷冻泵状态
                 LDB2State = Convert.ToInt32(dic["LDB2State"]),            //2号冷冻泵状态
                LDB3State = Convert.ToInt32(dic["LDB3State"]),           //3号冷冻泵状态
                LDB4State = Convert.ToInt32(dic["LDB4State"]),            //4号冷冻泵状态
                LDB5State = Convert.ToInt32(dic["LDB5State"]),           //5号冷冻泵状态
                LQJZ1State = Convert.ToInt32(dic["LQJZ1State"]),            //1号冷却机组状态
                LQJZ2State = Convert.ToInt32(dic["LQJZ2State"]),           //2号冷却机组状态

                LQJZ3State = Convert.ToInt32(dic["LQJZ3State"]),           //3号冷却机组状态
                LQJZ4State = Convert.ToInt32(dic["LQJZ4State"]),           //4号冷却机组状态
                LQJZ5State = Convert.ToInt32(dic["LQJZ5State"]),           //5号冷却机组状态

                LQB1State = Convert.ToInt32(dic["LQB1State"]),            //1号冷却泵状态
                LQB2State = Convert.ToInt32(dic["LQB2State"]),           //2号冷却泵状态
                LQB3State = Convert.ToInt32(dic["LQB3State"]),            //3号冷却泵状态
                LQB4State = Convert.ToInt32(dic["LQB4State"]),            //4号冷却泵状态

                LQB5State = Convert.ToInt32(dic["LQB5State"]),           //5号冷却泵状态
                LQB6State = Convert.ToInt32(dic["LQB6State"]),           //6号冷却泵状态
            });
            return zlzSystems;
        }
    }
}
