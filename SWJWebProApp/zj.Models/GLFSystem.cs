using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zj.Models
{
    /// <summary>
    /// 锅炉房系统
    /// </summary>
    public class GLFSystem
    {
        public string RSXLevel { get; set; }        //热水箱液位
        public string RJHQTemp { get; set; }        //热交换器温度
        public string RJHQPre { get; set; }         //热交换器压力
        public string RSX1Fre { get; set; }          //1号热水箱水泵频率
        public string RSX1Current { get; set; }      //1号热水箱水泵电流
        public string RSX2Fre { get; set; }          //2号热水箱水泵频率
        public string RSX2Current { get; set; }      //2号热水箱水泵电流
        public string CYQ1Temp { get; set; }          //1号除氧器温度
        public string CYQ1Pre { get; set; }           //1号除氧器压力
        public string CYQ1Level { get; set; }         //1号除氧器液位
        public string CYQ2Temp { get; set; }          //2号除氧器温度
        public string CYQ2Pre { get; set; }           //2号除氧器压力
        public string CYQ2Level { get; set; }         //2号除氧器液位
        public string GL1Pre { get; set; }            //1号锅炉压力
        public string GL1Level{ get; set; }           //1号锅炉液位
        public string GL1OutPre { get; set; }         //1号锅炉出口压力
        public string GL1OutFlow { get; set; }        //1号锅炉出口流量
        public string GL2Pre { get; set; }            //2号锅炉压力
        public string GL2Level { get; set; }           //2号锅炉液位
        public string GL2OutPre { get; set; }         //2号锅炉出口压力
        public string GL2OutFlow { get; set; }        //2号锅炉出口流量
        public string GL3Pre { get; set; }            //3号锅炉压力
        public string GL3Level { get; set; }           //3号锅炉液位
        public string GL3OutPre { get; set; }         //3号锅炉出口压力
        public string GL3OutFlow { get; set; }        //3号锅炉出口流量
        public int RSJYFState { get; set; }           //软水进液阀状态
        public int CYQ1LevelState { get; set; }       //除氧器1液位调试阀开度
        public int CYQ1PreState { get; set; }       //除氧器1压力调试阀开度
        public int CYQ2LevelState { get; set; }       //除氧器2液位调试阀开度
        public int CYQ2PreState { get; set; }       //除氧器2压力调试阀开度
        public int RJHQCYFState { get; set; }       //热交换器出液阀状态
        public int GLRSXJYFState { get; set; }       //锅炉软水箱进液阀状态
        public int RSX1PumpState { get; set; }       //1号热水箱水泵状态
        public int RSX2PumpState { get; set; }       //2号热水箱水泵状态
        public int GS1PumpState { get; set; }          //1号给水泵状态
        public int GS2PumpState { get; set; }          //2号给水泵状态
        public int GS3PumpState { get; set; }          //3号给水泵状态
        public int GS4PumpState { get; set; }          //4号给水泵状态
        public int GS5PumpState { get; set; }          //5号给水泵状态
        public int GS6PumpState { get; set; }          //6号给水泵状态
        public int ZQF1State { get; set; }            //1号主蒸汽阀状态
        public int ZQF2State { get; set; }            //2号主蒸汽阀状态
        public int ZQF3State { get; set; }            //3号主蒸汽阀状态
    }
}
