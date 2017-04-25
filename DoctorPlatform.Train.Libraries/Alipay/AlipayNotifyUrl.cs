using Com.Alipay;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DoctorPlatform.Train.Libraries.Alipay
{
    public static class AlipayNotifyUrl
    {
        /// <summary>
        /// 支付成功之后的业务逻辑
        /// </summary>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="trade_no">支付宝交易号</param>
        /// <param name="trade_status">支付状态</param>
        /// <param name="buyer_id">买家支付宝账号</param>
        /// <param name="total_fee">交易金额</param>
        /// <param name="gmt_create">交易时间</param>
        /// <param name="subject">订单名称</param>
        public delegate void PaySuccessLogic(string out_trade_no, string trade_no, string trade_status, long? buyer_id, decimal? total_fee, DateTime? gmt_create, string subject);

        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="out_trade_no">订单号</param>
        /// <param name="subject">订单名称</param>
        /// <param name="total_fee">金额</param>
        /// <returns>请求字符串</returns>
        public static string CostomAlipaySubmit(string out_trade_no, string total_fee, string subject, string trade_desciption = "")
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            AlipayConfiguration config = new AlipayConfiguration();
            sParaTemp.Add("service", config.Service);
            sParaTemp.Add("partner", config.Partner);
            sParaTemp.Add("seller_id", config.Seller_id);
            sParaTemp.Add("_input_charset", config.Input_charset.ToLower());
            sParaTemp.Add("payment_type", config.Payment_type);
            sParaTemp.Add("notify_url", config.Notify_url);
            sParaTemp.Add("return_url", config.Return_url);
            sParaTemp.Add("anti_phishing_key", config.Anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", config.Exter_invoke_ip);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", trade_desciption);
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            return sHtmlText;
        }

        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="config">Alipay的基础配置</param>
        /// <param name="out_trade_no">订单号</param>
        /// <param name="subject">订单名称</param>
        /// <param name="total_fee">金额</param>
        /// <returns>请求字符串</returns>
        public static string CostomAlipaySubmit(AlipayConfiguration config, string out_trade_no, string total_fee, string subject,string trade_desciption = "")
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", config.Service);
            sParaTemp.Add("partner", config.Partner);
            sParaTemp.Add("seller_id", config.Seller_id);
            sParaTemp.Add("_input_charset", config.Input_charset.ToLower());
            sParaTemp.Add("payment_type", config.Payment_type);
            sParaTemp.Add("notify_url", config.Notify_url);
            sParaTemp.Add("return_url", config.Return_url);
            sParaTemp.Add("anti_phishing_key", config.Anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", config.Exter_invoke_ip);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", trade_desciption);
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            return sHtmlText;
        }

        /// <summary>
        /// 服务器同步通知
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <param name="logic">支付成功委托(out_trade_no:商户订单号,trade_no:支付宝交易号,trade_status:支付状态,buyer_id:买家支付宝账号,total_fee:交易金额,gmt_create:交易时间,subject:订单名称)</param>     
        /// <param name="paystatus">交易状态</param>
        public static void NotifySync(this HttpContextBase context, PaySuccessLogic logic, out EnumPayStatus paystatus)
        {
            SortedDictionary<string, string> sPara = GetRequestGet(context.Request);

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, context.Request.QueryString["notify_id"], context.Request.QueryString["sign"]);

                if (verifyResult)//验证成功
                {
                    //商户订单号

                    string out_trade_no = context.Request.QueryString["out_trade_no"];

                    //买家支付宝账号

                    long? buyer_id = Convert.ToInt64(context.Request.QueryString["buyer_id"]);

                    //交易金额

                    decimal? total_fee = Convert.ToDecimal(context.Request.QueryString["total_fee"]);

                    //交易时间

                    DateTime? gmt_create = Convert.ToDateTime(context.Request.QueryString["gmt_create"]);

                    //支付宝交易号

                    string trade_no = context.Request.QueryString["trade_no"];

                    //交易状态
                    string trade_status = context.Request.QueryString["trade_status"];

                    //订单名称
                    string subject = context.Request.QueryString["subject"];


                    if (context.Request.QueryString["trade_status"] == "TRADE_FINISHED" || context.Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                    {
                        paystatus = EnumPayStatus.TRADE_SUCCESS;
                        try
                        {
                           logic(out_trade_no, trade_no, trade_status, buyer_id, total_fee, gmt_create, subject);
                        }
                        catch (System.Exception ex)
                        {

                            throw ex;
                        }   
                    }
                    else
                    {
                        paystatus = EnumPayStatus.TRADE_ERROR;
                    }
                }
                else
                {
                    paystatus = EnumPayStatus.VERIFY_ERROR;
                }
            }
            else
            {
                paystatus = EnumPayStatus.NO_PARAMENTER;
            }
        }

        /// <summary>
        /// 服务器异步通知
        /// </summary>
        /// <param name="context">请求上下文</param>
        /// <param name="logic">支付成功委托(out_trade_no:商户订单号,trade_no:支付宝交易号,trade_status:支付状态,buyer_id:买家支付宝账号,total_fee:交易金额,gmt_create:交易时间,subject:订单名称)</param>     
        /// <param name="paystatus">交易状态</param>
        public static void NotifyAsync(this HttpContextBase context, PaySuccessLogic logic, out EnumPayStatus paystatus)
        {
            SortedDictionary<string, string> sPara = GetRequestGet(context.Request);

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, context.Request.QueryString["notify_id"], context.Request.QueryString["sign"]);

                if (verifyResult)//验证成功
                {
                    //商户订单号

                    string out_trade_no = context.Request.QueryString["out_trade_no"];

                    //买家支付宝账号

                    long? buyer_id = Convert.ToInt64(context.Request.QueryString["buyer_id"]);

                    //交易金额

                    decimal? total_fee = Convert.ToDecimal(context.Request.QueryString["total_fee"]);

                    //交易时间

                    DateTime? gmt_create = Convert.ToDateTime(context.Request.QueryString["gmt_create"]);

                    //支付宝交易号

                    string trade_no = context.Request.QueryString["trade_no"];

                    //交易状态
                    string trade_status = context.Request.QueryString["trade_status"];

                    //订单名称
                    string subject = context.Request.QueryString["subject"];


                    if (context.Request.QueryString["trade_status"] == "TRADE_FINISHED" || context.Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                    {
                        paystatus = EnumPayStatus.TRADE_SUCCESS;
                        try
                        {
                            logic(out_trade_no, trade_no, trade_status, buyer_id, total_fee, gmt_create, subject);
                        }
                        catch (System.Exception ex)
                        {

                            throw ex;
                        } 
                    }
                    else
                    {
                        paystatus = EnumPayStatus.TRADE_ERROR;
                    }
                }
                else
                {
                    paystatus = EnumPayStatus.VERIFY_ERROR;
                }
            }
            else
            {
                paystatus = EnumPayStatus.NO_PARAMENTER;
            }
        }


        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public static SortedDictionary<string, string> GetRequestGet(HttpRequestBase request)
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = request.QueryString;

            // Get names of all forms into a string array
            string[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], request.QueryString[requestItem[i]]);
            }

            return sArray;
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public static SortedDictionary<string, string> GetRequestPost(HttpRequestBase request)
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], request.Form[requestItem[i]]);
            }

            return sArray;
        }
    }
}
