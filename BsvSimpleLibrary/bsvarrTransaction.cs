using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NBitcoin;
using NBitcoin.Altcoins;

namespace BsvSimpleLibrary
{
    public class bsvarrTransaction_class
    {
        public static Dictionary<string, string> send(Dictionary<string, string> payAddrandKey, long sendSatoshi, List<string> recaddress, 
            string network, string opreturnData = null, double feeSatPerByte = 0.55, uint sequence = 4294967295, int locktime = 0)
        {

            Transaction tx = null;
            long txfee = 0;
            Dictionary<string, string> response = send( payAddrandKey, sendSatoshi,recaddress
                , network, out tx, out txfee, opreturnData ,  feeSatPerByte,
                 sequence, locktime);
            return (response);
        }

        private static Dictionary<string, string> send(Dictionary<string, string> payAddrandKey, long sendSatoshi,
            List<string> recaddress, string network, out Transaction tx, out long txfee,
            string opreturnData=null, double feeSatPerByte=0.55, uint sequence=4294967295, int locktime=0)
        {
            tx = null;
            txfee = 0;
        
            Dictionary<string, string> response = new Dictionary<string, string>();

           
            return (response);
        }
    }
}
