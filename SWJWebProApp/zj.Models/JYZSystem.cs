using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zj.Models
{
    /// <summary>
    /// 加压站系统模型类
    /// </summary>
    [Serializable]
    public class JYZSystem
    {
        public int JyzSystemId { get; set; }    
        public int  RemainTime { get; set; }        //剩余时间
        public double FreSet { get; set; }         //频率给定
        public double  PreSet { get; set; }        //目标压力
        public int VoltageAB { get; set; }         //Uab电压

        public int VoltageBC { get; set; }         //Ubc电压
        public int VoltageAC { get; set; }         //Uac电压

        public double  CurrentA { get; set; }           //Ia电流

        public double CurrentB { get; set; }           //Ib电流
        public double CurrentC { get; set; }           //Ic电流
        public double PreIn { get; set; }           //入口压力值
        public double PreOut { get; set; }          //出口压力值
        //以下是水泵的状态 0：停止 1：运行 2 故障   3 备用
        public int Pump1State { get; set; }
        public int Pump2State { get; set; }
        public int Pump3State { get; set; }
        public int Pump4State { get; set; }
        public int Temp1A { get; set; }      // 1区温度A
        public int Temp1B { get; set; }      // 1区温度B
        public int Temp1C { get; set; }      // 1区温度C
        public int Temp2A { get; set; }      // 2区温度A
        public int Temp2B { get; set; }      // 2区温度B
        public int Temp2C { get; set; }      // 2区温度C
        public int Temp3A { get; set; }      // 3区温度A
        public int Temp3B { get; set; }      // 3区温度B
        public int Temp3C { get; set; }      // 3区温度C

    }
}
