using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.AuthorizeHelper
{
    public static class AuthorizeManage
    {
        public const string AreaAdmin = "Admin";

        public const string PolicyAdmin = "PolicyAdmin";
        public const string PolicyUser = "PolicyUser";

        public const string RoleAdmin = "Admin";
        public const string RoleUser = "User";

    }
    public static class AuthorizeExtension
    {
        public static PageConventionCollection AddAuthorizePageRazer(this PageConventionCollection Conventions)
        {
            Conventions.AuthorizeAreaFolder(AuthorizeManage.AreaAdmin, "/",AuthorizeManage.PolicyAdmin);
            //Conventions.AuthorizeAreaFolder(AuthorizeManage.AreaUser, "/");
            //Conventions.AuthorizePage(AuthorizeManage.Payment);
            return Conventions;
        }
        //public static MvcOptions AddAuthorizeMvc(this MvcOptions options)
        //{
        //    options.Conventions.AddAuthorizeAction("Values", "Get");
        //    return options;
        //}
        public static AuthorizationOptions AddPoliciesApp(this AuthorizationOptions options)
        {
            options.AddPolicy(AuthorizeManage.PolicyAdmin, config =>
            {
                config.RequireRole(AuthorizeManage.RoleAdmin);
            });
            options.AddPolicy(AuthorizeManage.PolicyUser, config =>
            {
                config.RequireRole(AuthorizeManage.RoleUser);
            });
            return options;
        }
    }
}
