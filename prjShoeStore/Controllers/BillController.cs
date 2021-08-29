using Microsoft.AspNetCore.Mvc;
using prjShoeStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Controllers
{
    public class BillController : ApiBaseController
    {
        private readonly AppDbContext _Context;
        public BillController(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }
        [HttpGet]
        public IActionResult GetBills()
        {
            var t = _Context.HoaDons.ToList();
            return Ok(t);
        }
    }
}
