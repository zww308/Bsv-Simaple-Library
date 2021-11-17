using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using NBitcoin.DataEncoders;
using BsvSimpleLibrary;
using NBitcoin;
using NBitcoin.Altcoins;

namespace bsv
{    
    class Program
    {
        public static long GetTimeStampTen()
        {
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds * 1000);
        }
        static void Main(string[] args)
        {
            //int[] numbers = { 5, 4, 1, 3, 6, 9, 5, 7, 0 };
            //int oldNumbers = numbers.Count();
            //Console.WriteLine(oldNumbers);
            //int oldNumbers2 = numbers.Count(n => n % 2 == 1);
            //Console.WriteLine(oldNumbers2);
            //long s = Program.GetTimeStamp();
            //long b = Program.GetTimeStampTen();
            //Console.WriteLine(s+"\t"+b);

            //string privateKeyStr = "sss";
            //BitcoinSecret privateKey = null;
            //try { privateKey = new BitcoinSecret(privateKeyStr); }
            //catch (FormatException e)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine(e.Message);

            //}
            //Console.WriteLine(privateKey);
            //Console.WriteLine(UInt32.MaxValue); 

            //Console.WriteLine(Int32.MaxValue);

            //int sq = 1 << 31;
            //Console.WriteLine(sq);//-2147483648

            //Console.WriteLine(sq);
            string destAddress = "mjHyPC49GKEp8NsJQXJ1D4zhpCuciJ7bna";//test            
            string privateKey = "cSKfdLTTdFhymeXPTnkTqubmQuTr3fti32G7opa84k6bhodog9Vg"; //(test) your private key
            //string txid = "d45bdda15e197e068288012f1764fd10cf884f5befcafb7d545af55f9d6e9cf0";
            string uri = bsvConfiguration_class.RestApiUri;
            string network = bsvConfiguration_class.testNetwork;
            string opReturnData = "zww and ljq love bsv test locktime 0 and 1sat";
            string sendAddress = "mmzARSDGW94BNBXpAhUpneVA3Lxq1eCEZf";

            Dictionary<string, string> response;

            //send bsv and / or write data.
            //1、response = bsvTransaction_class.sendLS(privateKey, 1, network, sendAddress, destAddress, opReturnData, 0.55, 0, 1, 1637021142);
            //response = bsvTransaction_class.sendLS(privateKey, 1, network, sendAddress, destAddress, opReturnData, 0.55, 0, 2, 1637021142);be150d489834ab45c2f4a44a17f631ddd4c230e498bf39d6027438c64f96c071
            // response = bsvTransaction_class.sendLS(privateKey, 3, network, sendAddress, destAddress, opReturnData, 0.55, 0, 3, 1637021142); 5622384701cb7ad5c89fde3258c01dbbca4df157d306417666b6320b8177ceff
            //response = bsvTransaction_class.sendLS(privateKey, 3, network, sendAddress, destAddress, opReturnData, 0.55, 0, 4, 1637021142);
            // response = bsvTransaction_class.sendLS(privateKey, 5, network, sendAddress, destAddress, opReturnData, 0.55, 0, 5, 1637021142); ed6e44f92284468b54aab5e41527922e7cb2eaa2a88a36095b383169f0a43da5


            // response = bsvTransaction_class.sendLS(privateKey, 5, network, sendAddress, destAddress, opReturnData, 0.55, 0, 4194306, 1636992342); 69cad8d9c113d9dac75fb54e3fbcf767176801745aac8befc084f6331cdebb2b

            response = bsvTransaction_class.sendLS(privateKey, 5, network, sendAddress, destAddress, opReturnData, 0.55, 0);//6300f06eb395527d1081e6e0d1f1b4c43ac5fa2f9e71f94a50825a983f43c86a 55也应该会出块











            // response = bsvTransaction_class.sendLS(privateKey, 333, network, sendAddress, destAddress, opReturnData, 0.55, 0,1234);
            //Transaction tx = null;
            //long txfee = 0;
            //long donationFee = 0;
            //response = bsvTransaction_class.send(privateKey, 0, network, out tx, out txfee, out donationFee,
            //    null, null, opReturnData, 1, 0);
            //Console.WriteLine("tx fee: " + txfee);

            ////get opreturn data
            //byte[] bytes = RestApi_class.getOpReturnFullData(uri, network, txid);
            //string s = RestApi_class.getOpReturnData(uri, network, txid, bsvConfiguration_class.encoding);

            ////get tx
            //RestApiTransaction tx = RestApi_class.getTransaction(uri, network, txid);

            ////get utxo
            //RestApiUtxo_class[] utxos = RestApi_class.getUtxosByAnAddress(uri, network, destAddress);

            ////get address Info
            //RestApiAddressHistoryTx[] addrHistory = RestApi_class.getAddressHistory(uri, network, destAddress);

            ////get txs. Max 20 transactions per request
            //string[] txHashs ={"2443b5def7bc400ce71b973e70114cbdb7695f84d2f3ad881f6f0d12c085a5c4",
            //    "21b3b70f51bee8882fa40778a6fc68eab33239f20b01a559f110c2ba229f8c98",
            //    "fc4471fb3761da4cc317b09a4fae5a68a11f8db41e703cd75125310f39a975fc" };
            //RestApiTransaction[] txs = RestApi_class.getTransactions(uri, network, txHashs);
            //foreach (RestApiTransaction tx in txs)
            //{
            //    string s = RestApi_class.getOpReturnData(tx, bsvConfiguration_class.encoding);
            //    Console.WriteLine(s);
            //}

            ////get BSV price based on USDT from OKEX
            //double price = BsvPrice_class.getBsvPriceOnUSDT();
            //double priceOnSat = BsvPrice_class.getSatoshiPriceOnCent();

            /*Unavailable at present. More functions will be listed on furture version.
            ////get raw tx
            //response = RestApi_class.getRawTransaction(uri, network, txid);
            */
            //Console.WriteLine();
            //Console.WriteLine("press any key to exist");
            //Console.ReadKey();
            Console.ReadLine();
        }
    }
}
