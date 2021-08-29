using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Options
{
    public class JwtSetting
    {
        public string SecretKey { get; set; }
        public int TokenExpireTime { get; set; }
    }
}
