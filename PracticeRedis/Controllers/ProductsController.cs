using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;

namespace PracticeRedis.Controllers
{
    public class ProductsController : Controller
    {
        private IDistributedCache _distributeCache;
        public ProductsController(IDistributedCache distributedCache)
        {
            _distributeCache = distributedCache;
        }

        public IActionResult Index()
        {
            DistributedCacheEntryOptions cacheOptions = new DistributedCacheEntryOptions();
            cacheOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(1);
            _distributeCache.Remove("name");
            _distributeCache.SetString("name", "Berk");
            string name = _distributeCache.GetString("name");

            return View();
        }
    }
}
