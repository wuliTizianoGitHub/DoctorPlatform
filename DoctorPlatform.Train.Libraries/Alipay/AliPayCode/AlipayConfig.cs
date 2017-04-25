using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;

namespace Com.Alipay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.4
    /// 修改日期：2016-03-08
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// </summary>
    public class AlipayConfiguration
    {
        /// <summary>WW
        /// Alipay配置
        /// </summary>
        public AlipayConfiguration()
        {
            Partner = "";
            Seller_id = Partner;
            Key = "";
            Notify_url = "http://商户网关地址/create_direct_pay_by_user-CSHARP-UTF-8/notify_url.aspx";
            Return_url = "http://商户网关地址/create_direct_pay_by_user-CSHARP-UTF-8/return_url.aspx";
            Sign_type = "MD5";
            Log_path = HttpRuntime.AppDomainAppPath.ToString() + "log\\";
            Input_charset = "utf-8";
            Payment_type = "1";
            Service = "create_direct_pay_by_user";
            Anti_phishing_key = "";
            Exter_invoke_ip = "";
        }

        /// <summary>
        /// Alipay配置
        /// </summary>
        /// <param name="partner">合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串</param>
        /// <param name="key">MD5密钥，安全检验码，由数字和字母组成的32位字符串</param>
        /// <param name="notify_url">服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问</param>
        /// <param name="return_url">页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问</param>
        public AlipayConfiguration(string partner, string key, string notify_url, string return_url)
        {
            Partner = partner;
            Seller_id = partner;
            Key = key;
            Notify_url = notify_url;
            Return_url = return_url;
            Sign_type = "MD5";
            Log_path = HttpRuntime.AppDomainAppPath.ToString() + "log\\";
            Input_charset = "utf-8";
            Payment_type = "1";
            Service = "create_direct_pay_by_user";
            Anti_phishing_key = "";
            Exter_invoke_ip = "";
        }

        /// <summary>
        /// Alipay配置
        /// </summary>
        /// <param name="partner">合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串</param>
        /// <param name="key">MD5密钥，安全检验码，由数字和字母组成的32位字符串</param>
        /// <param name="notify_url">服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问</param>
        /// <param name="return_url">页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问</param>
        /// <param name="log_path">调试用，创建TXT日志文件夹路径</param>
        public AlipayConfiguration(string partner, string key, string notify_url, string return_url, string log_path)
        {
            Partner = partner;
            Seller_id = partner;
            Key = key;
            Notify_url = notify_url;
            Return_url = return_url;
            Sign_type = "MD5";
            Log_path = log_path;
            Input_charset = "utf-8";
            Payment_type = "1";
            Service = "create_direct_pay_by_user";
            Anti_phishing_key = "";
            Exter_invoke_ip = "";
        }

        /// <summary>
        /// Alipay配置
        /// </summary>
        /// <param name="partner">合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串</param>
        /// <param name="seller_id">收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号</param>
        /// <param name="key">MD5密钥，安全检验码，由数字和字母组成的32位字符串</param>
        /// <param name="notify_url">服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问</param>
        /// <param name="return_url">页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问</param>
        /// <param name="sing_type">签名方式</param>
        /// <param name="log_path">调试用，创建TXT日志文件夹路径</param>
        /// <param name="input_charset">字符编码格式 目前支持 gbk 或 utf-8</param>
        /// <param name="payment_type">支付类型 ，无需修改</param>
        /// <param name="service">调用的接口名，无需修改</param>
        /// <param name="anti_phishing_key">防钓鱼时间戳  若要使用请调用类文件submit中的Query_timestamp函数</param>
        /// <param name="exter_invoke_ip">客户端的IP地址 非局域网的外网IP地址，如：221.0.0.1</param>
        public AlipayConfiguration(string partner,string seller_id,string key,string notify_url,string return_url,string sing_type,string log_path,string input_charset,string payment_type,string service,string anti_phishing_key,string exter_invoke_ip)
        {
            Partner = partner;
            Seller_id = partner;
            Key = key;
            Notify_url = notify_url;
            Return_url = return_url;
            Sign_type = sing_type;
            Log_path = log_path;
            Input_charset = input_charset;
            Payment_type = payment_type;
            Service = service;
            Anti_phishing_key = anti_phishing_key;
            Exter_invoke_ip = exter_invoke_ip;
        }


        //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        // 合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        public string Partner { get; set; }


        // 收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号
        public string Seller_id { get; set; }

        // MD5密钥，安全检验码，由数字和字母组成的32位字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        public string Key { get; set; } 

        // 服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问
        public string Notify_url { get; set; } 

        // 页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        public string Return_url { get; set; }

        // 签名方式
        public string Sign_type { get; set; } 

        // 调试用，创建TXT日志文件夹路径，见AlipayCore.cs类中的LogResult(string sWord)打印方法。
        public string Log_path { get; set; } 

        // 字符编码格式 目前支持 gbk 或 utf-8
        public string Input_charset { get; set; } 

        // 支付类型 ，无需修改
        public string Payment_type { get; set; } 

        // 调用的接口名，无需修改
        public string Service { get; set; } 

        //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


        //↓↓↓↓↓↓↓↓↓↓请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        //防钓鱼时间戳  若要使用请调用类文件submit中的Query_timestamp函数
        public string Anti_phishing_key { get; set; } 

        //客户端的IP地址 非局域网的外网IP地址，如：221.0.0.1
        public string Exter_invoke_ip { get; set; }

        //↑↑↑↑↑↑↑↑↑↑请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    }
}