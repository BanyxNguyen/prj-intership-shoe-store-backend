using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Attributes
{
    public class AuthorizeJWT : AuthorizeAttribute
    {
        public AuthorizeJWT()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
