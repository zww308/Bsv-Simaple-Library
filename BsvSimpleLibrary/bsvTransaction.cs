﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NBitcoin;
using NBitcoin.Altcoins;
//using System.Runtime.InteropServices;

namespace BsvSimpleLibrary
{
    public class bsvTransaction_class
    {


        //[DllImport("KERNEL32")]
        //static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
        /// <summary>
        /// Send bsv satoshis to an address from an address and/or write/read data to/from BSV blockchain.
        /// If changeBackAddress is null, the sending address would be set as default changeBackAddress..
        /// The fee would be set to 1.0x Sat/B automatically.
        /// Set the "donationSatoshi" =0 if do not donate.  
        /// If success, return the txid; else return error information.
        /// </summary>
        /// <param name = "privateKeyStr" ></ param >
        /// < param name= "sendSatoshi" ></ param >
        /// < param name= "network" ></ param >
        /// < param name= "destAddress" ></ param >
        /// < param name= "changeBackAddress" > If changeBackAddress is null, it would be set to the sending address automatically. </param>
        /// <param name = "opreturnData" > If opreturnData is not null, the data would be write to the blockchain.</param>
        /// <param name = "feeSatPerByte" > fee rate is represented by Satoshis per Byte</param>
        /// <param name = "donationSatoshi" > Set the "donationSatoshi" parameter = 0 if do not donate. 
        /// It does not donate everytiem if donationSatoshi is greater than 0 and less than 1000.
        /// The average donation fee is the set value.</param>
        /// <returns>If success, return the txid; else return error information</returns>
        //public static Dictionary<string, string> send(string privateKeyStr, long sendSatoshi, string network,
        //    string destAddressStr = null, string changeBackAddressStr = null,
        //    string opreturnData = null, double feeSatPerByte = 1, long donationSatoshi = 100)
        //{
        //    Transaction tx = null;
        //    long txfee = 0;
        //    long donationFee = 0;
        //    Dictionary<string, string> response = send(privateKeyStr, sendSatoshi, network,
        //        out tx, out txfee, out donationFee,
        //        destAddressStr, changeBackAddressStr, opreturnData,
        //        feeSatPerByte, donationSatoshi);
        //    return (response);
        //}

        /// <summary>
        /// Send bsv satoshis to an address from an address and/or write/read data to/from BSV blockchain.
        /// If changeBackAddress is null, the sending address would be set as default changeBackAddress..
        /// The fee would be set to 1.0x Sat/B automatically.
        /// Set the "donationSatoshi" =0 if do not donate.  
        /// If success, return the txid; else return error information.
        /// </summary>
        /// <param name = "privateKeyStr" ></ param >
        /// < param name= "sendSatoshi" ></ param >
        /// < param name= "network" ></ param >
        /// < param name= "tx" > nbitcoin transaction.pass the sent tx out</param>
        /// <param name = "txfee" > tx fee.satoshi.</param>
        /// <param name = "donationFee" > donated satoshis in the tx.</param>
        /// <param name = "destAddress" ></ param >
        /// < param name= "changeBackAddress" > If changeBackAddress is null, it would be set to the sending address automatically. </param>
        /// <param name = "opreturnData" > If opreturnData is not null, the data would be write to the blockchain.</param>
        /// <param name = "feeSatPerByte" > fee rate is represented by Satoshis per Byte</param>
        /// <param name = "donationSatoshi" > Set the "donationSatoshi" parameter = 0 if do not donate. 
        /// It does not donate everytiem if donationSatoshi is greater than 0 and less than 1000.
        /// The average donation fee is the set value.</param>
        /// <returns>If success, return the txid; else return error information</returns>
        //public static Dictionary<string, string> send(string privateKeyStr, long sendSatoshi, string network,
        //    out Transaction tx, out long txfee, out long donationFee, string destAddressStr = null, string changeBackAddressStr = null,
        //    string opreturnData = null, double feeSatPerByte = 1, long donationSatoshi = 100)
        //{
        //    tx = null;
        //    txfee = 0;
        //    Dictionary<string, string> response = new Dictionary<string, string>();
        //    long donationSat = setDonationSatoshi(donationSatoshi);
        //    donationFee = donationSat;
        //    /////////////////////////
        //    BitcoinSecret privateKey = null;
        //    try { privateKey = new BitcoinSecret(privateKeyStr); }
        //    catch (FormatException e)
        //    {
        //        Console.WriteLine();
        //        Console.WriteLine(e.Message);
        //        response.Add("Error", e.Message);
        //        return (response);
        //    }
        //    if (destAddressStr == null && sendSatoshi > 0)
        //    {
        //        string err = " the destAddress is null, but the sendSatoshi is not 0";
        //        Console.WriteLine();
        //        Console.WriteLine("Error: " + err);
        //        response.Add("Error", err);
        //        return (response);
        //    }
        //    Network networkFlag = privateKey.Network;
        //    BitcoinAddress destAddress = null;
        //    if (destAddressStr != null)
        //        destAddress = BitcoinAddress.Create(destAddressStr, networkFlag);
        //    BitcoinAddress changeBackAddress = null;
        //    if (changeBackAddressStr == null)
        //        changeBackAddress = privateKey.GetAddress(ScriptPubKeyType.Legacy);
        //    else
        //        changeBackAddress = BitcoinAddress.Create(changeBackAddressStr, networkFlag);
        //    //////////////////////////////////////
        //    if (networkFlag.Name == bsvConfiguration_class.NbitTestNet)
        //    {
        //        tx = ForkIdTransaction.Create(NBitcoin.Altcoins.BCash.Instance.Testnet);
        //        if (network != bsvConfiguration_class.testNetwork)
        //        {
        //            string err = string.Format("Error. the privake key is for {0}, but the selected network is for {1}.",
        //                bsvConfiguration_class.NbitTestNet, network);
        //            Console.WriteLine();
        //            Console.WriteLine(err);
        //            response.Add("Error.", err);
        //            return (response);
        //        }
        //    }
        //    if (networkFlag.Name == bsvConfiguration_class.NbitMainNet)
        //    {
        //        tx = ForkIdTransaction.Create(NBitcoin.Altcoins.BCash.Instance.Mainnet);
        //        if (network != bsvConfiguration_class.mainNetwork)
        //        {
        //            string err = string.Format("Error. the privake key is for {0}, but the selected network is for {1}.",
        //                bsvConfiguration_class.NbitMainNet, network);
        //            Console.WriteLine();
        //            Console.WriteLine(err);
        //            response.Add("Error.", err);
        //            return (response);
        //        }
        //    }
        //    Script scriptPubKey = privateKey.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;
        //    //////////////////////////
        //    RestApiUtxo_class[] utxos = RestApi_class.getUtxosByAnAddress(bsvConfiguration_class.RestApiUri, network,
        //        privateKey.GetAddress(ScriptPubKeyType.Legacy).ToString());
        //    addout(tx, opreturnData, destAddress, changeBackAddress, sendSatoshi, donationSat, network, networkFlag);
        //    计算支付后源地址的金额
        //    long changeBacksats = addin(sendSatoshi, tx, utxos, donationSat, feeSatPerByte, scriptPubKey, out txfee);
        //    sign(tx, privateKeyStr, utxos, changeBacksats, scriptPubKey);
        //    string responseStr = RestApi_class.sendTransaction(bsvConfiguration_class.RestApiUri, network, tx.ToHex());
        //    response.Add("send info", responseStr);
        //    return (response);
        //}


       






        /// <summary>
        /// 
        /// </summary>
        /// <param name="privateKeyStr"></param>
        /// <param name="sendSatoshi"></param>
        /// <param name="network"></param>
        /// <param name="destAddressStr"></param>支付地址
        /// <param name="changeBackAddressStr"></param>接收地址
        /// <param name="opreturnData"></param>
        /// <param name="feeSatPerByte"></param>
        /// <param name="donationSatoshi"></param>
        /// <param name="sequence"></param>
        /// <param name="locktime"></param>
        /// <returns></returns>
        public static Dictionary<string, string> sendLS(string privateKeyStr, long sendSatoshi, string network,
           string destAddressStr = null, string changeBackAddressStr = null,
           string opreturnData = null, double feeSatPerByte = 1, long donationSatoshi = 100,uint sequence = 4294967295, int locktime = 0)
        {
            Transaction tx = null;
            long txfee = 0;
            long donationFee = 0;
            Dictionary<string, string> response = sendLS(privateKeyStr, sendSatoshi, network,
                out tx, out txfee, out donationFee,
                destAddressStr, changeBackAddressStr, opreturnData,
                feeSatPerByte, donationSatoshi,sequence,locktime);
            return (response);
        }

        //前面的函数调用它进行支付 destAddressStr找零地址 changeBackAddressStr支付地址
        private static Dictionary<string, string> sendLS( string privateKeyStr, long sendSatoshi, string network,
            out Transaction tx, out long txfee, out long donationFee, string destAddressStr = null,
            string changeBackAddressStr = null, string opreturnData = null, double feeSatPerByte = 0.55,
            long donationSatoshi = 100, uint sequence = 4294967295, int locktime = 0)
        {
            tx = null;
            txfee = 0;
            //定义response字典类型
            Dictionary<string, string> response = new Dictionary<string, string>();

            //捐款多少钱，不用看
            long donationSat = setDonationSatoshi(donationSatoshi);
            donationFee = donationSat;

            //判断私钥是否符合base58格式,并将其转换为BitcoinSecret类型，这样可以获取私钥所属网络
            BitcoinSecret privateKey = null;
            try { privateKey = new BitcoinSecret(privateKeyStr);
            }
            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                response.Add("Error", e.Message);
                return (response);
            }
            //找零地址为空时且支付金额不为0时，这笔交易没有意义，报错
            if (destAddressStr == null && sendSatoshi > 0)
            {
                string err = " the destAddress is null, but the sendSatoshi is not 0";
                Console.WriteLine();
                Console.WriteLine("Error: " + err);
                response.Add("Error", err);
                return (response);
            }
            
            //找零地址和支付地址确认，并转成BitcoinAddress类型
            Network networkFlag = privateKey.Network;//获取网络
            BitcoinAddress destAddress = null;
            if (destAddressStr != null)
                destAddress = BitcoinAddress.Create(destAddressStr, networkFlag);
            BitcoinAddress changeBackAddress = null;
            if (changeBackAddressStr == null)
                changeBackAddress = privateKey.GetAddress(ScriptPubKeyType.Legacy);//未使用隔离见证的版本
            else
                changeBackAddress = BitcoinAddress.Create(changeBackAddressStr, networkFlag);


            //测试网络构造交易结构
            if (networkFlag.Name == bsvConfiguration_class.NbitTestNet)
            {
                //换回BCH的测试网交易的类型模板
                tx = ForkIdTransaction.Create(NBitcoin.Altcoins.BCash.Instance.Testnet);
                if (network != bsvConfiguration_class.testNetwork)
                {
                    string err = string.Format("Error. the privake key is for {0}, but the selected network is for {1}.",
                        bsvConfiguration_class.NbitTestNet, network);
                    Console.WriteLine();
                    Console.WriteLine(err);
                    response.Add("Error.", err);
                    return (response);
                }
            }

            //主网络构造交易，不用看
            if (networkFlag.Name == bsvConfiguration_class.NbitMainNet)
            {
                tx = ForkIdTransaction.Create(NBitcoin.Altcoins.BCash.Instance.Mainnet);
                if (network != bsvConfiguration_class.mainNetwork)
                {
                    string err = string.Format("Error. the privake key is for {0}, but the selected network is for {1}.",
                        bsvConfiguration_class.NbitMainNet, network);
                    Console.WriteLine();
                    Console.WriteLine(err);
                    response.Add("Error.", err);
                    return (response);
                }
            }

            //生成支付地址的输出锁定脚本，如果支付地址的UTXO不是用的ALL方式，这里可能需要更改
            Script scriptPubKey = privateKey.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;

            // privateKey.GetAddress(ScriptPubKeyType.Legacy).ToString()获取支付地址
            // "v1/bsv/test/address/mjHyPC49GKEp8NsJQXJ1D4zhpCuciJ7bna/unspent"
            // 获取前一笔交易的out内容,确定该地址上未花费的钱{height，outindex，txid,value}
             RestApiUtxo_class[] utxos = RestApi_class.getUtxosByAnAddress(bsvConfiguration_class.RestApiUri, network,
                privateKey.GetAddress(ScriptPubKeyType.Legacy).ToString());

            //构造交易
             addoutLS(tx, opreturnData, destAddress, changeBackAddress, sendSatoshi, donationSat, network, networkFlag,locktime);
            //计算支付地址支付后的余额
            long changeBacksats = addinLS(sendSatoshi, tx, utxos, donationSat, feeSatPerByte, scriptPubKey, out txfee,sequence);
            signNone(tx, privateKeyStr, utxos, changeBacksats, scriptPubKey, networkFlag);
            //sign(tx, privateKeyStr, utxos, changeBacksats, scriptPubKey);
            //发送交易
            string responseStr = RestApi_class.sendTransaction(bsvConfiguration_class.RestApiUri, network, tx.ToHex());

            Console.WriteLine();

            Console.WriteLine("\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\");

            Console.WriteLine(tx.ToString());
            Console.WriteLine(tx.ToHex());
            response.Add("send info", responseStr);
            return (response);
        }


        /// <summary>
        /// 构造支付通道输出，只用于输出一个目标地址与上传数据
        /// </summary>
        /// <param name="tx"></param>交易
        /// <param name="opreturnData"></param>上传数据
        /// <param name="destAddress"></param>支付地址
        /// <param name="changeBackAddress"></param>找零地址
        /// <param name="sendSatoshi"></param>支付金额
        /// <param name="donationSat"></param>捐款金额
        /// <param name="network"></param>所属网络
        /// <param name="networkFlag"></param>私钥的网络
        /// <param name="locktime"></param>绝对时间锁
        static void addoutLS(Transaction tx, string opreturnData,
            BitcoinAddress destAddress, BitcoinAddress changeBackAddress,
            long sendSatoshi, long donationSat, string network, Network networkFlag,int locktime)
        {
            tx.LockTime = (LockTime)locktime;
            //
            if (destAddress != null)
            {
                //构建输出的锁定脚本ScriptPubKey和UTXO余额
                TxOut txout = new TxOut(new Money(sendSatoshi), destAddress.ScriptPubKey);
                tx.Outputs.Add(txout);
            }
            //不用看，用来捐款的
            if (donationSat >= 1000 && network == bsvConfiguration_class.mainNetwork)
            {

                BitcoinAddress outAddress = BitcoinAddress.Create("199Kjhv6PLS8xn61y2fmJjvun2XwqA1UMm",
                    networkFlag);
                TxOut txout = new TxOut(new Money(donationSat), outAddress.ScriptPubKey);
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


        /// <summary>
        /// 构造支付通道输入
        /// </summary>
        /// <param name="sendSatoshi"></param>支付金额
        /// <param name="tx"></param>交易类型，这里应该out的构造好了。疑问👀
        /// <param name="utxos"></param>RestApiUtxo_class类型，当前地址的UTXO，用于利用交易ID，查询UTXO的每笔锁定脚本
        /// <param name="donationSat"></param>捐款金额
        /// <param name="feeSatPerByte"></param>每个字节的矿工费用
        /// <param name="scriptPubKey"></param>支付地址的锁定脚本
        /// <param name="fee"></param>交易费用
        /// <param name="sequence"></param>相对时间锁
        /// <returns></returns>
        static long addinLS(long sendSatoshi, Transaction tx, RestApiUtxo_class[] utxos, long donationSat,
            double feeSatPerByte, Script scriptPubKey, out long fee,uint sequence)
        {
            long satsInTxInputs = 0;//输入结构中的余额
            long neededSatoshi = sendSatoshi + donationSat;
            fee = 0;
            Sequence sq = (Sequence)sequence;
            foreach (RestApiUtxo_class utxo in utxos)
            {
                //outpoint=txid+index，一笔交易的UTXO所在的第几个索引
                OutPoint outPoint = new OutPoint(uint256.Parse(utxo.TxId), utxo.OutIndex);
                Console.WriteLine("输入时的："+outPoint);
                TxIn txin = new TxIn(outPoint);
                txin.Sequence = sequence;
                txin.ScriptSig = scriptPubKey;//Script.FromHex(utxo.ScriptPubKey);
                //添加sequence
                tx.Inputs.Add(txin);            
                satsInTxInputs += utxo.Value;
                fee = getTxFee(tx, feeSatPerByte);
                neededSatoshi += fee;
                //支付地址余额大于所有所需金额，就说明这笔UTXO够花，跳出UTXO的遍历
                if (satsInTxInputs >= neededSatoshi)
                    break;
            }
            long changBackSatoshi = satsInTxInputs - sendSatoshi - fee - donationSat;//找零
            Console.WriteLine();
            Console.WriteLine("fee : {0}", fee);
            return (changBackSatoshi);
        }



        //其他工具方法，设置捐款金额
        static long setDonationSatoshi(long donationSatoshi)
        {
            if (donationSatoshi == 0 || donationSatoshi >= 1000)
                return (donationSatoshi);
            else
            {
                //long l;
                //QueryPerformanceCounter(out l);                
                DateTime dt = DateTime.Now;
                int seed = (int)dt.Ticks;
                //Console.WriteLine("tick=" + seed);
                Random rand = new Random(seed);
                int v = rand.Next(1000 + (int)donationSatoshi);
                //Thread.Sleep(1);
                //Console.WriteLine("v=" + v);
                if (v >= 1000)
                    return (v);
                else
                    return (0);
            }
        }

        ///// <summary>
        ///// return satoshis of chang back
        ///// </summary>
        ///// <param name="sendSatoshi"></param>
        ///// <param name="tx"></param>
        ///// <param name="utxos"></param>
        ///// <param name="donationSat"></param>
        ///// <param name="feeSatPerByte"></param>
        ///// <returns></returns>
        ///// 
        ////构造输入
        //static long addin(long sendSatoshi, Transaction tx, RestApiUtxo_class[] utxos, long donationSat,
        //    double feeSatPerByte, Script scriptPubKey, out long fee)
        //{
        //    long satsInTxInputs = 0;
        //    long neededSatoshi = sendSatoshi + donationSat;
        //    fee = 0;
        //    foreach (RestApiUtxo_class utxo in utxos)
        //    {
        //        OutPoint outPoint = new OutPoint(uint256.Parse(utxo.TxId), utxo.OutIndex);
        //        TxIn txin = new TxIn(outPoint);
        //        txin.ScriptSig = scriptPubKey;//Script.FromHex(utxo.ScriptPubKey);
        //        //添加sequence
        //        tx.Inputs.Add(txin);
        //        satsInTxInputs += utxo.Value;
        //        fee = getTxFee(tx, feeSatPerByte);
        //        neededSatoshi += fee;
        //        //支付地址减去矿工费用加支付金额
        //        if (satsInTxInputs >= neededSatoshi)
        //            break;
        //    }
        //    long changBackSatoshi = satsInTxInputs - sendSatoshi - fee - donationSat;
        //    Console.WriteLine();
        //    Console.WriteLine("fee : {0}", fee);
        //    return (changBackSatoshi);
        //}

        //获取这笔交易需要花费的金额

        /**
         * 获取这笔交易需要花费的金额
         */
        static long getTxFee(Transaction tx, double feeSatPerByte)
        {
            double feeDouble = (tx.ToBytes().Length + tx.Inputs.Count * 81) * feeSatPerByte;
            long fee = Convert.ToInt64(Math.Ceiling(feeDouble));
            return (fee);
        }

        //
        //  构造输出
        // 
        //static void addout(Transaction tx, string opreturnData,
        //    BitcoinAddress destAddress, BitcoinAddress changeBackAddress,
        //    long sendSatoshi, long donationSat, string network, Network networkFlag)
        //{
        //    //
        //    if (destAddress != null)
        //    {
        //        TxOut txout = new TxOut(new Money(sendSatoshi), destAddress.ScriptPubKey);
        //        tx.Outputs.Add(txout);
        //    }
        //    if (donationSat >= 1000 && network == bsvConfiguration_class.mainNetwork)
        //    {

        //        BitcoinAddress outAddress = BitcoinAddress.Create("199Kjhv6PLS8xn61y2fmJjvun2XwqA1UMm",
        //            networkFlag);
        //        TxOut txout = new TxOut(new Money(donationSat), outAddress.ScriptPubKey);
        //        tx.Outputs.Add(txout);
        //    }
        //    //添加上传数据
        //    if (opreturnData != null)
        //    {
        //        byte[] strBytes = Encoding.UTF8.GetBytes(opreturnData);
        //        byte[] opretrunBytes = new byte[] { 0, 106 }.Concat(strBytes).ToArray();
        //        Script opreturnScript = new Script(opretrunBytes);
        //        tx.Outputs.Add(new TxOut()
        //        {
        //            Value = Money.Zero,
        //            ScriptPubKey = opreturnScript
        //        });
        //    }
        //    TxOut txback = new TxOut(new Money(Money.Zero), changeBackAddress.ScriptPubKey);
        //    tx.Outputs.Add(txback);
        //}

        //SigHashOld、SigHashALL对所有输出签名

       
        /// <summary>
        /// 对所有输入输出签名
        /// </summary>
        /// <param name="tx"></param>
        /// <param name="privateKeyStr"></param>
        /// <param name="utxos"></param>
        /// <param name="changeBackSatoshi"></param>
        /// <param name="scriptPubKey"></param>
        private static void sign(Transaction tx, string privateKeyStr, RestApiUtxo_class[] utxos, long changeBackSatoshi,
            Script scriptPubKey)
        {
            //the change back address must be at last.
            //集合保存交易输出
            List<Coin> coinList = new List<Coin>();
            foreach (RestApiUtxo_class utxo in utxos)
                coinList.Add(new Coin(uint256.Parse(utxo.TxId), utxo.OutIndex, new Money(utxo.Value), scriptPubKey));
            BitcoinSecret privateKey = new BitcoinSecret(privateKeyStr);
            //转成数组
            Coin[] coins = coinList.ToArray();
            tx.Outputs.Last().Value = changeBackSatoshi;
            BitcoinSecret[] privateKeys = { privateKey };
            tx.Sign(privateKeys, coins);
        }

        //SigHashNone对所有输入签名
        private static void signNone(Transaction tx, string privateKeyStr, RestApiUtxo_class[] utxos, long changeBackSatoshi,
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
            //txBuilder.SignTransactionInPlace(tx, SigHash.All );
            //txBuilder.SignTransactionInPlace(tx, SigHash.None);
            //txBuilder.SignTransactionInPlace(tx, SigHash.All | SigHash.AnyoneCanPay);
            // txBuilder.SignTransactionInPlace(tx, SigHash.None | SigHash.AnyoneCanPay);
            //txBuilder.SignTransactionInPlace(tx, SigHash.Single);
            txBuilder.SignTransactionInPlace(tx, SigHash.Single | SigHash.AnyoneCanPay);
        }



        
    }
}
