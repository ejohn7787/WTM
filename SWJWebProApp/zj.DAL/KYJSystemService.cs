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
    public class KYJSystemService
    {
        #region 字段
        /// <summary>
        /// 锅炉房接口地址
        /// </summary>
        private string urlKYJ = "http://23451v6g02.qicp.vip:58841/api/home/getvalue?name=KYJ";
        private Timer timer = new Timer(); //定时器
        // 与数据接口的访问通用服务
        private CommonService commonService = new CommonService();
        //存储从接口读入的原始数据
        private string KYJOriginalData = string.Empty;
        #endregion
        #region 定时器
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
        /// 如果API接口没有参数，返回一个模拟的数据
        /// </summary>
        /// <returns></returns>
        private object KYJSysMocData()
        {
            string KYJSysMocData = "{KYJ1Temp:\"55\",KYJ1Pre:\"40\",KYJ1Current:\"50\",KYJ2Temp:\"55\",KYJ2Pre:\"40\",KYJ2Current:\"50\",KYJ3Temp:\"55\",KYJ3Pre:\"40\",KYJ3Current:\"50\",KYJ4Temp:\"55\",KYJ4Pre:\"40\",KYJ4Current:\"50\",LQTInPre:\"55\",LQTOutPre:\"40\",LQTInTemp:\"50\",LQTOutTemp:\"30\",LQTLevel:\"50\",Pump1State:1,Pump2State:1,KYJ1State:1,KYJ2State:1,KYJ3State:1,KYJ4State:1,KYJ1InState:1,KYJ2InState:1,KYJ3InState:1,KYJ4InState:1,KYJ1OutState:1,KYJ2OutState:1,KYJ3OutState:1,KYJ4OutState:1,KYJ1Remain:1,KYJ2Remain:1,KYJ3Remain:1,KYJ4Remain:1,KYJRunNum:1,KYJStopNum:1}";//JSON字符串的数据
            return KYJSysMocData;
        }
        /// <summary>
        /// 定时器事件,循环读取实时数据，并保存到缓存中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            KYJOriginalData = commonService.GetDataFromSWJByApi(urlKYJ);
            if (KYJOriginalData != string.Empty)
            {
                commonService.InsertMemoryCache("KYJCacheData", KYJOriginalData, 1);
            }
            else
            {
                commonService.InsertMemoryCache("KYJCacheData", KYJSysMocData(), 1);
            }
        }
        #endregion
        #region 获取锅炉房数据
        public List<KYJSystem> KYJSystems()
        {
            List<KYJSystem> glfSystems = new List<KYJSystem>();
            string KYJReadCacheData = commonService.ReadMemoryCache("KYJCacheData").ToString();
            if (KYJReadCacheData != null)
            {
                glfSystems = KYJSystems(KYJReadCacheData);
            }
            else
            {
                KYJOriginalData = commonService.GetDataFromSWJByApi(urlKYJ);
                glfSystems = KYJSystems(KYJOriginalData);
            }
            return glfSystems;

        }
        public List<KYJSystem> KYJSystems(string kyjData)
        {
            Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(kyjData);
            List<KYJSystem> kyjSystems = new List<KYJSystem>();
            #region 反射的方法
            //反射的方法
            {
                //GLFSystem glfSystem = new GLFSystem();
                //Type t = typeof(GLFSystem);
                //PropertyInfo[] propertyInfos = t.GetProperties();
                //foreach (PropertyInfo propertyInfo in propertyInfos)
                //{
                //    propertyInfo.SetValue(glfSystem, dic[propertyInfo.Name]);
                //}
                //glfSystems.Add(glfSystem);
            }
            #endregion
            #region 一般方法
            //传统的方法
            {

                kyjSystems.Add(new KYJSystem()
                {
                    KYJ1Temp = dic["KYJ1Temp"],        //1号空压机温度
                    KYJ1Pre = dic["KYJ1Pre"],
                    KYJ1Current = dic["stringKYJ1Current"],  //1号空压机电流
                    KYJ2Temp = dic["stringKYJ2Temp"],  //2号空压机温度
                    KYJ2Pre = dic["stringKYJ2Pre"],   //2号空压机压力
                    KYJ2Current = dic["stringKYJ2Current"],  //2号空压机电流
                    KYJ3Temp = dic["stringKYJ3Temp"],      //3号空压机温度
                    KYJ3Pre = dic["stringKYJ3Pre"],        //3号空压机压力
                    KYJ3Current = dic["KYJ3Current"],    //3号空压机电流
                    KYJ4Temp = dic["KYJ4Temp"],       //4号空压机温度
                    KYJ4Pre = dic["KYJ4Pre"],         //4号空压机压力
                    KYJ4Current = dic["KYJ4Current"],     //4号空压机电流
                    LQTInPre = dic["LQTInPre"],       //冷却塔供水压力
                    LQTOutPre = dic["LQTOutPre"],        //冷却塔回水压力
                    LQTInTemp = dic["LQTInTemp"],        //冷却塔供水温度
                    LQTOutTemp = dic["LQTOutTemp"],     //冷却塔回水温度
                    LQTLevel = dic["LQTLevel"],        //冷却塔液位
                    Pump1State = Convert.ToInt32(dic["Pump1State"]),         //循环泵1状态
                    Pump2State = Convert.ToInt32(dic["Pump2State"]),         //循环泵2状态
                    KYJ1State = Convert.ToInt32(dic["KYJ1State"]),         //空压机1状态
                    KYJ2State = Convert.ToInt32(dic["KYJ2State"]),         //空压机2状态
                    KYJ3State = Convert.ToInt32(dic["KYJ3State"]),         //空压机3状态
                    KYJ4State = Convert.ToInt32(dic["KYJ4State"]),          //空压机4状态
                    KYJ1InState = Convert.ToInt32(dic["KYJ1InState"]),       //空压机1进气阀的状态
                    KYJ2InState = Convert.ToInt32(dic["KYJ2InState"]),      //空压机2进气阀的状态
                    KYJ3InState = Convert.ToInt32(dic["KYJ3InState"]),      //空压机3进气阀的状态
                    KYJ4InState = Convert.ToInt32(dic["KYJ4InState"]),      //空压机4进气阀的状态
                    KYJ1OutState = Convert.ToInt32(dic["KYJ1OutState"]),      //空压机1出气阀的状态
                    KYJ2OutState = Convert.ToInt32(dic["KYJ2OutState"]),      //空压机2出气阀的状态
                    KYJ3OutState = Convert.ToInt32(dic["KYJ3OutState"]),     //空压机3出气阀的状态
                    KYJ4OutState = Convert.ToInt32(dic["KYJ4OutState"]),      //空压机4出气阀的状态
                    KYJ1Remain = Convert.ToInt32(dic["KYJ1Remain"]),       //空压机1剩余保养天数
                    KYJ2Remain = Convert.ToInt32(dic["KYJ2Remain"]),         //空压机2剩余保养天数
                    KYJ3Remain = Convert.ToInt32(dic["KYJ3Remain"]),       //空压机3剩余保养天数
                    KYJ4Remain = Convert.ToInt32(dic["KYJ4Remain"]),        //空压机4剩余保养天数
                    KYJRunNum = Convert.ToInt32(dic["KYJRunNum"]),         //设备运行数量
                    KYJStopNum = Convert.ToInt32(dic["KYJStopNum"]),      //设备停止数量
                });
                return kyjSystems;
            }
            #endregion



        }
        #endregion
    }
}
