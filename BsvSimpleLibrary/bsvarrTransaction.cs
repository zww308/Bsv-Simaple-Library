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
       
        public static Dictionary<string, string> sendpay(List<Payment_class> paylist, 
            string network ,double feeSatPerByte = 0.55)
        {

            Transaction tx = null;
            long txfee = 0;
            Dictionary<string, string> response = sendpay(paylist
                , network, out tx, out txfee, feeSatPerByte
                );
            return (response);
          
        }

        private static Dictionary<string, string> sendpay(List<Payment_class> paylist, string network,
            out Transaction tx, out long txfee, double feeSatPerByte)
        {
            tx = ForkIdTransaction.Create(NBitcoin.Altcoins.BCash.Instance.Testnet);
            txfee = 0;
            Dictionary<string, string> response = new Dictionary<string, string>();
            BitcoinSecret privateKey = null;
            BitcoinAddress destAddress = null;
            BitcoinAddress changeBackAddress = null;
            foreach (Payment_class pay in paylist)
            {
                string privatekeystr = pay.privatekeyStr;               
                privateKey = new BitcoinSecret(privatekeystr);
              
                
                Network networkFlag = privateKey.Network;//获取网络
                string destAddressStr = pay.changeAddressStr;
                if (destAddressStr != null)
                    destAddress = BitcoinAddress.Create(destAddressStr, networkFlag);
                string changeBackAddressStr = pay.changeAddressStr;
                if (changeBackAddressStr == null)
                    changeBackAddress = privateKey.GetAddress(ScriptPubKeyType.Legacy);//未使用隔离见证的版本
                else
                    changeBackAddress = BitcoinAddress.Create(pay.payAddressStr, networkFlag);

                Script scriptPubKey = privateKey.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;
               
                //构造交易中的输出
                addoutLS(tx, pay.opreturnData, destAddress, changeBackAddress, pay.sendSatoshi, network, networkFlag, pay.locktime);
               
            }
            long[] chageBackarr = new long[3];
            int i = 0;
            Dictionary<BitcoinSecret, List<RestApiUtxo_class>> utxosDic = new Dictionary<BitcoinSecret, List<RestApiUtxo_class>>();
            
            foreach (Payment_class pay in paylist) {
               
                List<RestApiUtxo_class> utxoslist = null;              
                privateKey = new BitcoinSecret(pay.privatekeyStr);
                RestApiUtxo_class[] utxos = RestApi_class.getUtxosByAnAddress(bsvConfiguration_class.RestApiUri, network,
                     privateKey.GetAddress(ScriptPubKeyType.Legacy).ToString());
                utxoslist = utxos.ToList();
                utxosDic.Add(privateKey, utxoslist);
               
                Script scriptPubKey = privateKey.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;
                //计算支付地址支付后的余额
                long changeBacksats = addinLS(pay.sendSatoshi, tx, utxos, feeSatPerByte, scriptPubKey, out txfee, pay.sequence);
                chageBackarr[i++] = changeBacksats;
            }
            sign(tx,  utxosDic, chageBackarr);

            //发送交易
            string responseStr = RestApi_class.sendTransaction(bsvConfiguration_class.RestApiUri, network, tx.ToHex());
            Console.WriteLine();

            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");

            Console.WriteLine(tx.ToString());
            Console.WriteLine(tx.ToHex());
            response.Add("send info", responseStr);
            return (response);
        }

       

        //构建交易输出
        private static void addoutLS(Transaction tx, string opreturnData,
            BitcoinAddress destAddress, BitcoinAddress changeBackAddress, 
            long sendSatoshi, string network, Network networkFlag, uint locktime)
        {
            tx.LockTime = (LockTime)locktime;
            //
            if (destAddress != null)
            {
                //构建输出的锁定脚本ScriptPubKey和UTXO余额
                TxOut txout = new TxOut(new Money(sendSatoshi), destAddress.ScriptPubKey);
                tx.Outputs.Add(txout);
            }
           
            //添加上传数据
            if (opreturnData != null)
            {
                byte[] strBytes = Encoding.UTF8.GetBytes(opreturnData);
                byte[] opretrunBytes = new byte[] { 0, 106 }.Concat(strBytes).ToArray();
                Script opreturnScript = new Script(opretrunBytes);//对上传的数据进行构造脚本
                //构建输出的opreturn的格式，没有钱，锁定脚本类型是opreturnScript
                tx.Outputs.Add(new TxOut()
                {
                    Value = Money.Zero,
                    ScriptPubKey = opreturnScript
                });
            }
            //这里可以定义接口上传opreturndata到服务端，服务端进行解析展现前端物流信息，但是要上传他的交易id等等后面需要考虑
            TxOut txback = new TxOut(new Money(Money.Zero), changeBackAddress.ScriptPubKey);
            tx.Outputs.Add(txback);
        }

        //构建交易输入
        private static long addinLS(long sendSatoshi, Transaction tx,
            RestApiUtxo_class[] utxos, double feeSatPerByte,
            Script scriptPubKey, out long txfee, uint sequence)
        {
            long satsInTxInputs = 0;//输入结构中的余额
            long neededSatoshi = sendSatoshi ;
            txfee = 0;
            Sequence sq = (Sequence)sequence;
            foreach (RestApiUtxo_class utxo in utxos)
            {
                //outpoint=txid+index，一笔交易的UTXO所在的第几个索引
                OutPoint outPoint = new OutPoint(uint256.Parse(utxo.TxId), utxo.OutIndex);
                Console.WriteLine("输入时的：" + outPoint);
                TxIn txin = new TxIn(outPoint);
                txin.Sequence = sequence;
                txin.ScriptSig = scriptPubKey;//Script.FromHex(utxo.ScriptPubKey);
                //添加sequence
                tx.Inputs.Add(txin);
                satsInTxInputs += utxo.Value;
                txfee = getTxFee(tx, feeSatPerByte);
                neededSatoshi += txfee;
                //支付地址余额大于所有所需金额，就说明这笔UTXO够花，跳出UTXO的遍历
                if (satsInTxInputs >= neededSatoshi)
                    break;
            }
            long changBackSatoshi = satsInTxInputs - sendSatoshi - txfee;//找零
            Console.WriteLine();
            Console.WriteLine("fee : {0}", txfee);
            return (changBackSatoshi);
        }

        //获取这一笔交易所花费的矿工费用
        private static long getTxFee(Transaction tx, double feeSatPerByte)
        {
            double feeDouble = (tx.ToBytes().Length + tx.Inputs.Count * 81) * feeSatPerByte;
            long fee = Convert.ToInt64(Math.Ceiling(feeDouble));
            return (fee);
        }

        //对交易签名
        private static void sign(Transaction tx, string privateKeyStr, RestApiUtxo_class[] utxos, long changeBackSatoshi,
           Script scriptPubKey, Network networkFlag)
        {
            //集合保存交易输出
            List<Coin> coinList = new List<Coin>();
            //构造输出集合
            foreach (RestApiUtxo_class utxo in utxos)
                coinList.Add(new Coin(uint256.Parse(utxo.TxId), utxo.OutIndex, new Money(utxo.Value), scriptPubKey));
            BitcoinSecret privateKey = new BitcoinSecret(privateKeyStr);
            //转成数组
            Coin[] coins = coinList.ToArray();

            tx.Outputs.Last().Value = changeBackSatoshi;
            var txBuilder = networkFlag.CreateTransactionBuilder();//transactionbuilder对象
            txBuilder.AddKeys(privateKey);
            txBuilder.AddCoins(coins);
            //txBuilder.SignTransactionInPlace(tx, SigHash.All);
            //txBuilder.SignTransactionInPlace(tx, SigHash.None);
            txBuilder.SignTransactionInPlace(tx, SigHash.All | SigHash.AnyoneCanPay);
            // txBuilder.SignTransactionInPlace(tx, SigHash.None | SigHash.AnyoneCanPay);
            //txBuilder.SignTransactionInPlace(tx, SigHash.Single);
            //txBuilder.SignTransactionInPlace(tx, SigHash.Single | SigHash.AnyoneCanPay);
        }

        private static void sign(Transaction tx, Dictionary<BitcoinSecret, List<RestApiUtxo_class>> utxosDic, long[] chageBacklist)
        {
            //集合保存交易输出
            List<Coin> coinList = new List<Coin>();
            int i = 0;
            int j = 0 ;
            Network networkFlag = null;
            List<BitcoinSecret> privateKeys = new List<BitcoinSecret>();
            foreach (KeyValuePair<BitcoinSecret, List<RestApiUtxo_class>> kvp in utxosDic)
            {
                BitcoinSecret privatekey = kvp.Key;
                privateKeys.Add(privatekey);
                networkFlag = privatekey.Network;
                List<RestApiUtxo_class> utxos = kvp.Value;
                Script scriptPubKey = privatekey.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;
                foreach (RestApiUtxo_class utxo in utxos)
                    coinList.Add(new Coin(uint256.Parse(utxo.TxId), utxo.OutIndex, new Money(utxo.Value), scriptPubKey));
                tx.Outputs.Last().Value = chageBacklist[i++];
            }
            Coin[] coins = coinList.ToArray();
            BitcoinSecret[] privatearr = privateKeys.ToArray();
            var txBuilder = networkFlag.CreateTransactionBuilder();//transactionbuilder对象
            txBuilder.AddKeys(privatearr);
            txBuilder.AddCoins(coins);
            txBuilder.SignTransactionInPlace(tx, SigHash.Single | SigHash.AnyoneCanPay);
        }
    }
}
