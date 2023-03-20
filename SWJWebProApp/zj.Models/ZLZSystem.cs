using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zj.Models
{
    public class ZLZSystem
    {
        public string LSJSQTemp { get; set; }       //冷水集水器温度
        public string LSJSQPre { get; set; }         //冷水集水器压力
        public string LSFSQTemp { get; set; }       //冷水分水器温度
        public string LSFSQPre { get; set; }         //冷水分水器压力
        public string LRSJSQTemp { get; set; }       //冷热水集水器温度
        public string LRSJSQPre { get; set; }         //冷热水集水器压力
        public string LRSFSQTemp { get; set; }       //冷热水分水器温度
        public string LRSFSQPre { get; set; }         //冷热水分水器压力
        public string HRJZInTemp { get; set; }        //换热机组进口温度
        public string HRJZInPre { get; set; }         //换热机组进口压力
        public string HRJZOutTemp { get; set; }        //换热机组出口温度
        public string HRJZOutPre { get; set; }         //换热机组出口压力
        public string LDB1Fre { get; set; }           //1号冷冻泵频率
        public string LDB1Current { get; set; }           //1号冷冻泵电流
        public string LDB2Fre { get; set; }           //2号冷冻泵频率
        public string LDB2Current { get; set; }           //2号冷冻泵电流
        public string LDB3Fre { get; set; }           //3号冷冻泵频率
        public string LDB3Current { get; set; }           //3号冷冻泵电流
        public string LDB4Fre { get; set; }           //4号冷冻泵频率
        public string LDB4Current { get; set; }           //4号冷冻泵电流
        public string LDB5Fre { get; set; }           //5号冷冻泵频率
        public string LDB5Current { get; set; }           //5号冷冻泵电流

        public string LQJ1Temp { get; set; }          //1号冷却机组温度
        public string LQJ1Pre { get; set; }            //1号冷却机组压力
        public string LQJ2Temp { get; set; }          //2号冷却机组温度
       
        public string LQJ2Pre { get; set; }            //2号冷却机组压力
        public string LQJ3Temp { get; set; }          //3号冷却机组温度

        public string LQJ3Pre { get; set; }            //3号冷却机组压力
        public string LQJ4Temp { get; set; }          //4号冷却机组温度
        public string LQJ4Pre { get; set; }            //4号冷却机组压力
        public string LQJ5Temp { get; set; }          //5号冷却机组温度
        public string LQJ5Pre { get; set; }            //5号冷却机组压力


        public string LQB1Current { get; set; }        //1号冷却泵电流
        public string LQB2Current { get; set; }        //2号冷却泵电流
        public string LQB3Current { get; set; }        //3号冷却泵电流
        public string LQB4Current { get; set; }        //4号冷却泵电流
        public string LQB5Current { get; set; }        //5号冷却泵电流
        public string LQB6Current { get; set; }        //6号冷却泵电流

        public string LQT1Level { get; set; }         //冷却塔1液位
        public string LQT2Level { get; set; }         //冷却塔2液位
        public string LQT3Level { get; set; }         //冷却塔3液位
        public string LQT4Level { get; set; }         //冷却塔4液位
        public string LQT5Level { get; set; }         //冷却塔5液位

        public int LDB1State { get; set; }            //1号冷冻泵状态
        public int LDB2State { get; set; }            //2号冷冻泵状态
        public int LDB3State { get; set; }            //3号冷冻泵状态
        public int LDB4State { get; set; }            //4号冷冻泵状态
        public int LDB5State { get; set; }            //5号冷冻泵状态
        public int LQJZ1State { get; set; }           //1号冷却机组状态
        public int LQJZ2State { get; set; }           //2号冷却机组状态

        public int LQJZ3State { get; set; }           //3号冷却机组状态
        public int LQJZ4State { get; set; }           //4号冷却机组状态
        public int LQJZ5State { get; set; }           //5号冷却机组状态

        public int LQB1State { get; set; }            //1号冷却泵状态
        public int LQB2State { get; set; }            //2号冷却泵状态
        public int LQB3State { get; set; }            //3号冷却泵状态
        public int LQB4State { get; set; }            //4号冷却泵状态

        public int LQB5State { get; set; }            //5号冷却泵状态
        public int LQB6State { get; set; }            //6号冷却泵状态
        

    }
}
