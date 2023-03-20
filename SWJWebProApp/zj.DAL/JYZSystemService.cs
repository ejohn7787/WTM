using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;
using zj.Models;
using Newtonsoft.Json;
using System.Reflection;

namespace zj.DAL
{
    /// <summary>
    /// 加压站数据访问
    /// </summary>
    public class JYZSystemService
    {
        private string urlJYZ = "http://23451v6g02.qicp.vip:58841/api/home/getvalue?name=JYZ";
        private Timer timer = new Timer(); //定时器
        private CommonService commonService = new CommonService();    //实例化与数据接口的通用访问类
        private string jyzOriginalData = string.Empty;  //存储从接口读入的原始数据
        public void InitialTimer()
        {
            timer.Interval= 1000;
            timer.AutoReset= true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        /// <summary>
        /// 通过API接口定时获取加压站的实时数据，并保存到缓存中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            jyzOriginalData = commonService.GetDataFromSWJByApi(urlJYZ);
            if(jyzOriginalData != string.Empty)
            {
                commonService.InsertMemoryCache("jyzCacheData", jyzOriginalData, 1);

            }
            else //如果没有数据，放入模拟数据
            {
                commonService.InsertMemoryCache("jyzCacheData", jyzSysMocData(), 1);
            }
        }
        /// <summary>
        /// 如果API接口没有参数，返回一个模拟的数据
        /// </summary>
        /// <returns></returns>
        private object jyzSysMocData()
        {
            string jyzSysMocData = "{RemainTime:48,FreSet:42.85061,PreSet:15.4,VoltageAB:223,VoltageBC:224,VoltageAC:223,CurrentA:9.69,CurrentB:9.75,CurrentC:8.94,PreIn:1.34,PreOut:1.775,Pump1State:1,Pump2State:0,Pump3State:1,Pump4State:0,Temp1A:32,Temp1B:33,Temp1C:34,Temp2A:33,Temp2B:32,Temp2C:30,Temp3A:31,Temp3B:33,Temp3C:31}";//JSON字符串的数据
            return jyzSysMocData;
        }
        /// <summary>
        /// 获取加压站的数据，并分装到对象集合中，并返回
        /// </summary>
        /// <returns></returns>
        public List<JYZSystem> JYZSystems()
        {
            List<JYZSystem> jyzSystems= new List<JYZSystem>();
            //从缓存中读取数据
            string jyzReadCacheData = commonService.ReadMemoryCache("jyzCacheData").ToString();
            if(jyzReadCacheData != string.Empty)
            {
                jyzSystems = JYZSystems(jyzReadCacheData);
            }
            else
            {
                jyzOriginalData = commonService.GetDataFromSWJByApi(urlJYZ);
                jyzSystems = JYZSystems(jyzOriginalData);
            }
            return jyzSystems;
        }
        /// <summary>
        /// 将JSON字符串封装到类型集合中
        /// </summary>
        /// <param name="jyzData"></param>
        /// <returns></returns>
        private List<JYZSystem> JYZSystems(string jyzData)
        {
            Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(jyzData);
            List<JYZSystem> jyzSystems= new List<JYZSystem>();
            jyzSystems.Add(new JYZSystem()
            {
                RemainTime = Convert.ToInt32( dic["RemainTime"]),
                FreSet = Convert.ToDouble( dic["FreSet"]),
                PreSet = Convert.ToDouble(dic["PreSet"]),
                VoltageAB = Convert.ToInt32(dic["VoltageAB"]),
                VoltageBC = Convert.ToInt32(dic["VoltageBC"]),
                VoltageAC = Convert.ToInt32(dic["VoltageAC"]),
                CurrentA = Convert.ToDouble(dic["CurrentA"]),
                CurrentB = Convert.ToDouble(dic["CurrentB"]),
                CurrentC = Convert.ToDouble(dic["CurrentC"]),
                PreIn = Convert.ToDouble(dic["PreIn"]),
                PreOut = Convert.ToDouble(dic["PreOut"]),
                Pump1State = Convert.ToInt32(dic["Pump1State"]),
                Pump2State = Convert.ToInt32(dic["Pump2State"]),
                Pump3State = Convert.ToInt32(dic["Pump3State"]),
                Pump4State = Convert.ToInt32(dic["Pump4State"]),
                Temp1A = Convert.ToInt32(dic["Temp1A"]),
                Temp1B = Convert.ToInt32(dic["Temp1B"]),
                Temp1C = Convert.ToInt32(dic["Temp1C"]),
                Temp2A = Convert.ToInt32(dic["Temp2A"]),
                Temp2B = Convert.ToInt32(dic["Temp2B"]),
                Temp2C = Convert.ToInt32(dic["Temp2C"]),
                Temp3A = Convert.ToInt32(dic["Temp3A"]),
                Temp3B = Convert.ToInt32(dic["Temp3B"]),
                Temp3C = Convert.ToInt32(dic["Temp3C"])
            });
            return jyzSystems;
        }
    }
}
