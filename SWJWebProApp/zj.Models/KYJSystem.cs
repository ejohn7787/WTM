using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zj.Models
{
    public class KYJSystem
    {
        public string KYJ1Temp { get; set; }        //1号空压机温度
        public string KYJ1Pre { get; set; }         //1号空压机压力
        public string KYJ1Current { get; set; }     //1号空压机电流
        public string KYJ2Temp { get; set; }        //2号空压机温度
        public string KYJ2Pre { get; set; }         //2号空压机压力
        public string KYJ2Current { get; set; }     //2号空压机电流
        public string KYJ3Temp { get; set; }        //3号空压机温度
        public string KYJ3Pre { get; set; }         //3号空压机压力
        public string KYJ3Current { get; set; }     //3号空压机电流
        public string KYJ4Temp { get; set; }        //4号空压机温度
        public string KYJ4Pre { get; set; }         //4号空压机压力
        public string KYJ4Current { get; set; }     //4号空压机电流
        public string LQTInPre { get; set; }        //冷却塔供水压力
        public string LQTOutPre { get;set; }        //冷却塔回水压力
        public string LQTInTemp { get; set; }        //冷却塔供水温度
        public string LQTOutTemp { get; set; }      //冷却塔回水温度
        public string LQTLevel { get; set; }        //冷却塔液位
        public int Pump1State { get; set; }         //循环泵1状态
        public int Pump2State { get; set; }         //循环泵2状态
        public int KYJ1State { get; set; }         //空压机1状态
        public int KYJ2State { get; set; }         //空压机2状态
        public int KYJ3State { get; set; }         //空压机3状态
        public int KYJ4State { get; set; }         //空压机4状态
        public int KYJ1InState { get; set; }       //空压机1进气阀的状态
        public int KYJ2InState { get; set; }       //空压机2进气阀的状态
        public int KYJ3InState { get; set; }       //空压机3进气阀的状态
        public int KYJ4InState { get; set; }       //空压机4进气阀的状态

        public int KYJ1OutState { get; set; }      //空压机1出气阀的状态
        public int KYJ2OutState { get; set; }      //空压机2出气阀的状态

        public int KYJ3OutState { get; set; }      //空压机3出气阀的状态
        public int KYJ4OutState { get; set; }      //空压机4出气阀的状态
        public int KYJ1Remain { get; set; }        //空压机1剩余保养天数
        public int KYJ2Remain { get; set; }        //空压机2剩余保养天数
        public int KYJ3Remain { get; set; }        //空压机3剩余保养天数
        public int KYJ4Remain { get; set; }        //空压机4剩余保养天数
        public int KYJRunNum { get; set; }         //设备运行数量
        public int KYJStopNum { get; set; }        //设备停止数量
    }
}
