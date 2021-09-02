using Microsoft.AspNetCore.Mvc;
using prjShoeStore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjShoeStore.Controllers
{
	//[AuthorizeJWT]
	[Route("api/[controller]/[action]")]
	public class ApiBaseController : ControllerBase
	{
	}
}
