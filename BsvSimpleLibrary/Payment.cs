using System;
using System.Collections.Generic;
using System.Text;

namespace BsvSimpleLibrary
{
    public class Payment_class
    {
        public Payment_class() { 
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="privatekeyStr"></param>
        /// <param name="payAddressStr"></param>
        /// <param name="sendSatoshi"></param>
        /// <param name="changeAddressStr"></param>
        /// <param name="opreturnData"></param>
        /// <param name="sequence"></param>
        /// <param name="locktime"></param>
        public Payment_class(string privatekeyStr, string payAddressStr, long sendSatoshi
            , string changeAddressStr, string opreturnData
            , uint sequence, uint locktime) {
            this.privatekeyStr = privatekeyStr;
            this.payAddressStr = payAddressStr;
            this.sendSatoshi = sendSatoshi;
            this.changeAddressStr = changeAddressStr;
            this.opreturnData = opreturnData;        
            this.sequence = sequence;
            this.locktime = locktime;
        }
        public string privatekeyStr;
        public string payAddressStr;
        public long sendSatoshi;     
        public string changeAddressStr;
        public string opreturnData;     
        public uint sequence;
        public uint locktime;

        /// <summary>
        /// 重写ToString
        /// </summary>
        /// <returns></returns>
        public override  string ToString()
        {
            return "Payment: " + "privatekeyStr = "+ privatekeyStr + ", payAddressStr =  " + payAddressStr +
                ", sendSatoshi = " + sendSatoshi + ", changeAddressStr = " + changeAddressStr + ", opreturnData = "
                + opreturnData + ", sequence = " + sequence + ", locktime = " + locktime;
        }
    }
}
