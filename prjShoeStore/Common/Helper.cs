using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Common
{
    public class Helper
    {
        public const string LoginProvider = "Microsoft";
        public const string Purpose = "access_token";
        public const string PathImage = "Images";
        public const string PathProduct = "Products";
        public const string PathImageDefaule = "Defaults";
        public static string ProductImageDefault { get => Path.Combine(PathImage, PathImageDefaule, "product-default.jpg"); }
    }

    public static class HelperExtension
    {
        public static string GetProductImageDefault(this IHtmlHelper htmlHelper) => Helper.ProductImageDefault;
        public static IEnumerable<string> SaveProductImage(this IEnumerable<IFormFile> lstImg)
        {
            foreach (var item in lstImg)
            {
                var id = Guid.NewGuid();
                var url = Path.Combine(Helper.PathImage, Helper.PathProduct, id + Path.GetExtension(item.FileName));
                var path = Path.Combine(Startup.WWWROOTPATH, url);
                using var file = File.OpenWrite(path);
                item.CopyTo(file);
                yield return "/" + url.Replace("\\", "/");
            }
        }
    }
}
