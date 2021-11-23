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
		
		

		static void Main(string[] args)
        {
			

			string destAddress = "myXNut61z3g7ThKMTnwai9hfPWuRT2GnzT";//test            
            string privateKey = "cTNMvkiS25SYNnWHN4WioFW7FKHdWgcLymTo8Y2YWAJPXeu6v8nJ"; //(test) your private key
            //string txid = "d45bdda15e197e068288012f1764fd10cf884f5befcafb7d545af55f9d6e9cf0";
           // string uri = bsvConfiguration_class.RestApiUri;
            string network = bsvConfiguration_class.testNetwork;
            string opReturnData = "This is None in the SigHash";
            string sendAddress = "mjHyPC49GKEp8NsJQXJ1D4zhpCuciJ7bna";

            Dictionary<string, string> response;


            //本来是1100支付的金额，为验证最终性，改为1111；第一笔c7ec32bac33e6ae998af39c0f601d9b4894cb978ac836de1e8b577b065a0da2a；第二笔8dc186dfa22f6b8dae0ab6b512c8c7bfe0f203a0fdff062fc3bffe51f20a44c0
            response = bsvTransaction_class.sendLS(privateKey, 10, network, sendAddress, destAddress, opReturnData, 0.55,0, 4294967295, 0);//518e7aff4ad71bca60f21f7bcb5472ac95b2f9234b0a33fa413633201d534fda 55也应该会出块

		



            //BitcoinSecret privateKey1;
            //privateKey1 = new BitcoinSecret(privateKey);
            //var a = privateKey1.PubKey.ScriptPubKey;
            //var b = privateKey1.GetAddress(ScriptPubKeyType.Legacy);
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine(destAddress);
            //BitcoinAddress destAddress1 = null;
            //if (destAddress != null)
            //    destAddress1 = BitcoinAddress.Create(destAddress, privateKey1.Network);
            //var a = destAddress1.ScriptPubKey;

            ////生成输出锁定脚本
            //Script scriptPubKey = privateKey1.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;
            //Console.WriteLine(scriptPubKey.ToString());
            //Console.WriteLine(a);






            //     Console.WriteLine("Hello World! " + new Key().GetWif(Network.Main));





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
