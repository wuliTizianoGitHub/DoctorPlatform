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
        public static void CostomAlipaySubmit(this HttpContextBase context, string out_trade_no, string subject, string total_fee)
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", Config.service);
            sParaTemp.Add("partner", Config.partner);
            sParaTemp.Add("seller_id", Config.seller_id);
            sParaTemp.Add("_input_charset", Config.input_charset.ToLower());
            sParaTemp.Add("payment_type", Config.payment_type);
            sParaTemp.Add("notify_url", Config.notify_url);
            sParaTemp.Add("return_url", Config.return_url);
            sParaTemp.Add("anti_phishing_key", Config.anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", Config.exter_invoke_ip);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", string.Empty);
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            context.Response.Write(sHtmlText);
        }

        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="out_trade_no">订单号</param>
        /// <param name="subject">订单名称</param>
        /// <param name="total_fee">金额</param>
        /// <param name="trade_desciption">描述</param>
        /// <returns>请求字符串</returns>
        public static void CostomAlipaySubmit(this HttpContextBase context, string out_trade_no, string subject, string total_fee, string trade_desciption)
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", Config.service);
            sParaTemp.Add("partner", Config.partner);
            sParaTemp.Add("seller_id", Config.seller_id);
            sParaTemp.Add("_input_charset", Config.input_charset.ToLower());
            sParaTemp.Add("payment_type", Config.payment_type);
            sParaTemp.Add("notify_url", Config.notify_url);
            sParaTemp.Add("return_url", Config.return_url);
            sParaTemp.Add("anti_phishing_key", Config.anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", Config.exter_invoke_ip);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", trade_desciption);
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            context.Response.Write(sHtmlText);
        }

        /// <summary>
        /// 订单支付
        /// </summary>
        /// <param name="out_trade_no">订单号</param>
        /// <param name="subject">订单名称</param>
        /// <param name="total_fee">金额</param>
        /// <param name="trade_desciption">描述</param>
        /// <param name="partner">合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串</param>
        /// <param name="seller_id">收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号</param>
        /// <param name="input_charset">字符编码格式 目前支持 gbk 或 utf-8</param>
        /// <param name="notify_url">服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问</param>
        /// <param name="return_url">页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问</param>
        /// <param name="anti_phishing_key">防钓鱼时间戳  若要使用请调用类文件submit中的Query_timestamp函数</param>
        /// <param name="exter_invoke_ip">客户端的IP地址 非局域网的外网IP地址，如：221.0.0.1</param>
        /// <returns></returns>
        public static void CostomAlipaySubmit(this HttpContextBase context, string out_trade_no, string subject, string total_fee, string trade_desciption = "",  string partner = "", string seller_id = "", string input_charset = "", string notify_url = "", string return_url = "", string anti_phishing_key = "", string exter_invoke_ip = "")
        {
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", Config.service);
            sParaTemp.Add("partner", partner == string.Empty ? Config.partner : partner);
            sParaTemp.Add("seller_id", seller_id == string.Empty ? Config.seller_id : seller_id);
            sParaTemp.Add("_input_charset", input_charset == string.Empty ? Config.input_charset.ToLower() : input_charset.ToLower());
            sParaTemp.Add("payment_type", Config.payment_type);
            sParaTemp.Add("notify_url", notify_url == string.Empty ? Config.notify_url : notify_url);
            sParaTemp.Add("return_url", return_url == string.Empty ? Config.return_url : return_url);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key == string.Empty ? Config.anti_phishing_key : anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip == string.Empty ? Config.exter_invoke_ip : exter_invoke_ip);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", trade_desciption == string.Empty ? "" : trade_desciption);
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            context.Response.Write(sHtmlText);
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
                        logic(out_trade_no, trade_no, trade_status, buyer_id, total_fee, gmt_create, subject);
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
                        logic(out_trade_no, trade_no, trade_status, buyer_id, total_fee, gmt_create, subject);
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
