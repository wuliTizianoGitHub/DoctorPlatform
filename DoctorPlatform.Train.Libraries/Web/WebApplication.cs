using DoctorPlatform.Train.Libraries.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DoctorPlatform.Train.Libraries.Web
{
    /// <summary>
    /// 这个类简单引用了<see cref="Libraries.Bootstrapper"/>类来启动系统，
    /// 继承自global.asax所继承的<see cref="HttpApplication"/>
    /// </summary>
    /// <typeparam name="TStartupModule"></typeparam>
    public abstract class WebApplication<TStartupModule> : HttpApplication
        where TStartupModule : BaseModule
    {
        /// <summary>
        /// 获取<see cref="Libraries.Bootstrapper"/> 实例的引用
        /// </summary>
        public static Bootstrapper Bootstrapper { get; } = Bootstrapper.Create<TStartupModule>();

        //todo:一些配置


        /// <summary>
        /// 调用ASP.NET系统的启动方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Application_Start(object sender, EventArgs e)
        {
            Bootstrapper.Initialize();
        }

        protected virtual void Application_End(object sender, EventArgs e)
        {
            Bootstrapper.Dispose();
        }

        protected virtual void Session_Start(object sender, EventArgs e)
        {

        }

        protected virtual void Session_End(object sender, EventArgs e)
        {

        }

        protected virtual void Application_BeginRequest(object sender, EventArgs e)
        {
            //SetCurrentCulture();
        }

        protected virtual void Application_EndRequest(object sender, EventArgs e)
        {

        }

        protected virtual void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected virtual void Application_Error(object sender, EventArgs e)
        {

        }

        protected virtual void SetCurrentCulture()
        {

        }
    }
}
