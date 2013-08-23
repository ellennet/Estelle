using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Estelle.Web
{
    /// <summary>
    /// 自定义Auth
    /// </summary>
    public class CustomAuthAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 自定义Authorize验证
        /// </summary>
        /// <param name="httpContext">httpContext</param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string currentRole = GetRole(httpContext.User.Identity.Name);
            if (Roles.Contains(currentRole))
                return true;

            //Users.

            return base.AuthorizeCore(httpContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //filterContext.HttpContext.Response.Redirect 支持重定向
            base.HandleUnauthorizedRequest(filterContext);
        }

        private string GetRole(string name)
        {
            //测试,具体从数据库中读出
            switch (name)
            {
                case "aaa": return "User";
                case "bbb": return "Admin";
                case "ccc": return "God";
                default: return "Fool";
            }
        }
    } 
}