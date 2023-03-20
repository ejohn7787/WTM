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

    public class MMSSystemService
    {
        private string urlMMS = "http://23451v6g02.qicp.vip:58841/api/home/getvalue?name=MMS";
        private Timer timer = new Timer();                               //定时器
        private CommonService commonService = new CommonService();    //实例化与数据接口的通用访问类
        private string mmsOriginalData = string.Empty;                //存储从接口读入的原始数据
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

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            mmsOriginalData = commonService.GetDataFromSWJByApi(urlMMS);
            if (mmsOriginalData != string.Empty)
            {
                commonService.InsertMemoryCache("mmsCacheData", mmsOriginalData, 1);

            }
            else //如果没有数据，放入模拟数据
            {
                commonService.InsertMemoryCache("mmsCacheData", mmsSysMocData(), 1);
            }
        }
        /// <summary>
        /// 如果API接口没有参数，返回一个模拟的数据
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private object mmsSysMocData()
        {
            string mmsSysMocData = "{ Motor1Start :1, Motor1Stop :0, Motor1State :1, Motor1Mode :1, Motor2Start :1, Motor2Stop :1, Motor2State :1, Motor2Mode :1, Motor3Start :1, Motor3Stop :1, Motor3State :1, Motor3Mode :1, Motor4Start :1, Motor4Stop :1, Motor4State :1, Motor4Mode :1, Motor5Start :1, Motor5Stop :1, Motor5State :1, Motor5Mode :1, Motor6Start :1, Motor6Stop :1, Motor6State :1, Motor6Mode :1, Motor1Voltage :50.0, Motor1Current :50.0, Motor1Fre :50.0, Motor2Voltage :50.0, Motor2Current :50.0, Motor2Fre :50.0, Motor3Voltage :50.0, Motor3Current :50.0, Motor3Fre :50.0, Motor4Voltage :50.0, Motor4Current :50.0, Motor4Fre :50.0, Motor5Voltage :50.0, Motor5Current :50.0, Motor5Fre :50.0, Motor6Voltage :50.0, Motor6Current :50.0, Motor6Fre :50.0}";
            return mmsSysMocData;
        }
        /// <summary>
        /// 获取制冷站的数据，并分装到对象集合中，并返回
        /// </summary>
        /// <returns></returns>
        public List<MMSSystem> MMSSystems()
        {
            List<MMSSystem> mmsSystems = new List<MMSSystem>();
            //从缓存中读取数据
            string mmsReadCacheData = commonService.ReadMemoryCache("mmsCacheData").ToString();
            if (mmsReadCacheData != string.Empty)
            {
                mmsSystems = MMSSystems(mmsReadCacheData);
            }
            else //如果缓存没有，直接从API读取
            {
                mmsOriginalData = commonService.GetDataFromSWJByApi(urlMMS);
                mmsSystems = MMSSystems(mmsOriginalData);
            }
            return mmsSystems;
        }
        /// <summary>
        /// 将JSON字符串封装到类型集合中
        /// </summary>
        /// <param name="zlzData"></param>
        /// <returns></returns>
        private List<MMSSystem> MMSSystems(string mmsData)
        {
            //JSON字符串反序列化为字典类型
            Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(mmsData);
            List<MMSSystem> mmsSystems = new List<MMSSystem>();
            mmsSystems.Add(new MMSSystem()
            {
                Motor1Start = Convert.ToInt32(dic["Motor1Start"]),  //1号电机启动
                Motor1Stop = Convert.ToInt32(dic["Motor1Stop"]),  //1号电机停止
                Motor1State = Convert.ToInt32(dic["Motor1State"]),   //1号电机状态
                Motor1Mode = Convert.ToInt32(dic["Motor1Mode"]),   //1号电机手自动模式
                Motor2Start = Convert.ToInt32(dic["Motor2Start"]), //2号电机启动
                Motor2Stop = Convert.ToInt32(dic["Motor2Stop"]),  //2号电机停止
                Motor2State = Convert.ToInt32(dic["Motor2State"]),   //2号电机状态
                Motor2Mode = Convert.ToInt32(dic["Motor2Mode"]),   //2号电机手自动模式
                Motor3Start = Convert.ToInt32(dic["Motor3Start"]), //3号电机启动
                Motor3Stop = Convert.ToInt32(dic["Motor3Stop"]),  //3号电机停止
                Motor3State = Convert.ToInt32(dic["Motor3State"]),   //3号电机状态
                Motor3Mode = Convert.ToInt32(dic["Motor3Mode"]),   //3号电机手自动模式
                Motor4Start = Convert.ToInt32(dic["Motor4Start"]), //4号电机启动
                Motor4Stop = Convert.ToInt32(dic["Motor4Stop"]),  //4号电机停止
                Motor4State = Convert.ToInt32(dic["Motor4State"]),   //4号电机状态
                Motor4Mode = Convert.ToInt32(dic["Motor4Mode"]),   //4号电机手自动模式
                Motor5Start = Convert.ToInt32(dic["Motor5Start"]), //5号电机启动
                Motor5Stop = Convert.ToInt32(dic["Motor5Stop"]),  //5号电机停止
                Motor5State = Convert.ToInt32(dic["Motor5State"]),   //5号电机状态
                Motor5Mode = Convert.ToInt32(dic["Motor5Mode"]),   //5号电机手自动模式
                Motor6Start = Convert.ToInt32(dic["Motor6Start"]), //6号电机启动
                Motor6Stop = Convert.ToInt32(dic["Motor6Stop"]),  //6号电机停止
                Motor6State = Convert.ToInt32(dic["Motor6State"]),   //6号电机状态
                Motor6Mode = Convert.ToInt32(dic["Motor6Mode"]),   //6号电机手自动模式

                Motor1Voltage = Convert.ToInt32(dic["Motor1Voltage"]), //1号电机电压
                Motor1Current = Convert.ToInt32(dic["Motor1Current"]),  //1号电机电流
                Motor1Fre = Convert.ToInt32(dic["Motor1Fre"]),   //1号电机频率
                Motor2Voltage = Convert.ToInt32(dic["Motor2Voltage"]), //2号电机电压
                Motor2Current = Convert.ToInt32(dic["Motor2Current"]),  //2号电机电流
                Motor2Fre = Convert.ToInt32(dic["Motor2Fre"]),   //2号电机频率
                Motor3Voltage = Convert.ToInt32(dic["Motor3Voltage"]), //3号电机电压
                Motor3Current = Convert.ToInt32(dic["Motor3Current"]),  //3号电机电流
                Motor3Fre = Convert.ToInt32(dic["Motor3Fre"]),   //3号电机频率
                Motor4Voltage = Convert.ToInt32(dic["Motor4Voltage"]), //4号电机电压
                Motor4Current = Convert.ToInt32(dic["Motor4Current"]),  //4号电机电流
                Motor4Fre = Convert.ToInt32(dic["Motor4Fre"]),   //4号电机频率
                Motor5Voltage = Convert.ToInt32(dic["Motor5Voltage"]), //5号电机电压
                Motor5Current = Convert.ToInt32(dic["Motor5Current"]),  //5号电机电流
                Motor5Fre = Convert.ToInt32(dic["Motor5Fre"]),   //5号电机频率
                Motor6Voltage = Convert.ToInt32(dic["Motor6Voltage"]), //6号电机电压
                Motor6Current = Convert.ToInt32(dic["Motor6Current"]),  //6号电机电流
                Motor6Fre = Convert.ToInt32(dic["Motor6Fre"])   //6号电机频率

            });
            return mmsSystems;
        }
    }
}
