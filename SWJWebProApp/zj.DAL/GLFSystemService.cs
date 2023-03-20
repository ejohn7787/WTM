using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using zj.Models;
namespace zj.DAL
{

    /// <summary>
    /// 锅炉房系统数据访问
    /// </summary>
    public class GLFSystemService
    {
        #region 字段
        /// <summary>
        /// 锅炉房接口地址
        /// </summary>
        private string urlGLF = "http://23451v6g02.qicp.vip:58841/api/home/getvalue?name=GLF";
        private Timer timer = new Timer(); //定时器
        // 与数据接口的访问通用服务
        private CommonService commonService = new CommonService();
        //存储从接口读入的原始数据
        private string GLFOriginalData = string.Empty;
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
        private object GLFSysMocData()
        {
            string GLFSysMocData = "{RSXLevel:\"100.0\",RJHQTemp:\"56.0\",RJHQPre:\"55.5\",RSX1Fre:\"55.8\",RSX1Current:\"34.5\",RSX2Fre:\"33.8\",RSX2Current:\"32.5\",CYQ1Temp:\"55\",CYQ1Pre:\"45\",CYQ1Level:\"55.5\",CYQ2Temp:\"55\",CYQ2Pre:\"45\",CYQ2Level:\"55.5\",GL1Pre:\"44\",GL1Level:\"44\",GL1OutPre:\"16\",GL1OutFlow:\"44\",GL2Pre:\"44\",GL2Level:\"44\",GL2OutPre:\"16\",GL2OutFlow:\"44\",GL3Pre:\"44\",GL3Level:\"44\",GL3OutPre:\"16\",GL3OutFlow:\"44\",RSJYFState:5,CYQ1LevelState:2,CYQ1PreState:2,CYQ2LevelState:2,CYQ2PreState:2,RJHQCYFState:2,GLRSXJYFState:2,RSX1PumpState:2,RSX2PumpState:2,GS1PumpState:2,GS2PumpState:1,GS3PumpState:1,GS4PumpState:1,GS5PumpState:1,GS6PumpState:1,ZQF1State:1,ZQF2State:1,ZQF3State:1}";//JSON字符串的数据
            return GLFSysMocData;
        }
        /// <summary>
        /// 定时器事件,循环读取实时数据，并保存到缓存中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            GLFOriginalData = commonService.GetDataFromSWJByApi(urlGLF);
            if(GLFOriginalData!= string.Empty)
            {
                commonService.InsertMemoryCache("GLFCacheData", GLFOriginalData,1);
            }
            else
            {
                commonService.InsertMemoryCache("GLFCacheData", GLFSysMocData(),1);
            }
        }
        #endregion
        #region 获取锅炉房数据
        public List<GLFSystem> GLFSystems()
        {
            List<GLFSystem> glfSystems= new List<GLFSystem>();
            string GLFReadCacheData = commonService.ReadMemoryCache("GLFCacheData").ToString();
            if(GLFReadCacheData!=null)
            {
                glfSystems = GLFSystems(GLFReadCacheData);
            }
            else
            {
                GLFOriginalData = commonService.GetDataFromSWJByApi(urlGLF);
                glfSystems = GLFSystems(GLFOriginalData);
            }
            return glfSystems;
            
        }
        public List<GLFSystem> GLFSystems(string glfData)
        {
            Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(glfData);
            List<GLFSystem> glfSystems = new List<GLFSystem>();
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

                glfSystems.Add(new GLFSystem()
                {
                    RSXLevel = dic["RSXLevel"],
                    RJHQTemp = dic["RJHQTemp"],
                    RJHQPre = dic["RJHQPre"],
                    RSX1Fre = dic["RSX1Fre"],
                    RSX1Current = dic["RSX1Current"],
                    RSX2Fre = dic["RSX2Fre"],
                    RSX2Current = dic["RSX2Current"],
                    CYQ1Temp = dic["CYQ1Temp"],
                    CYQ1Pre = dic["CYQ1Pre"],
                    CYQ1Level = dic["CYQ1Level"],
                    CYQ2Temp = dic["CYQ2Temp"],
                    CYQ2Pre = dic["CYQ2Pre"],
                    CYQ2Level = dic["CYQ2Level"],
                    GL1Pre = dic["GL1Pre"],
                    GL1Level = dic["GL1Level"],
                    GL1OutPre = dic["GL1OutPre"],
                    GL1OutFlow = dic["GL1OutFlow"],
                    GL2Pre = dic["GL2Pre"],
                    GL2Level = dic["GL2Level"],
                    GL2OutPre = dic["GL2OutPre"],
                    GL2OutFlow = dic["GL2OutFlow"],
                    GL3Pre = dic["GL3Pre"],
                    GL3Level = dic["GL3Level"],
                    GL3OutPre = dic["GL3OutPre"],
                    GL3OutFlow = dic["GL3OutFlow"],
                    RSJYFState =Convert.ToInt32( dic["RSJYFState"]),
                    CYQ1LevelState = Convert.ToInt32(dic["CYQ1LevelState"]),
                    CYQ1PreState = Convert.ToInt32(dic["CYQ1PreState"]),
                    CYQ2LevelState = Convert.ToInt32(dic["CYQ2LevelState"]),
                    CYQ2PreState = Convert.ToInt32(dic["CYQ2PreState"]),
                    RJHQCYFState = Convert.ToInt32(dic["RJHQCYFState"]),
                    GLRSXJYFState = Convert.ToInt32(dic["GLRSXJYFState"]),
                    RSX1PumpState = Convert.ToInt32(dic["RSX1PumpState"]),
                    RSX2PumpState = Convert.ToInt32(dic["RSX2PumpState"]),
                    GS1PumpState = Convert.ToInt32(dic["GS1PumpState"]),
                    GS2PumpState = Convert.ToInt32(dic["GS2PumpState"]),
                    GS3PumpState = Convert.ToInt32(dic["GS3PumpState"]),
                    GS4PumpState = Convert.ToInt32(dic["GS4PumpState"]),
                    GS5PumpState = Convert.ToInt32(dic["GS5PumpState"]),
                    GS6PumpState = Convert.ToInt32(dic["GS6PumpState"]),
                    ZQF1State = Convert.ToInt32(dic["ZQF1State"]),
                    ZQF2State = Convert.ToInt32(dic["ZQF2State"]),
                    ZQF3State = Convert.ToInt32(dic["ZQF3State"])
                });
                return glfSystems;
            }
            #endregion



        }
        #endregion
    }
}
