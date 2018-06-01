using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.IBLL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/picture")]
    public class PictureController : Controller
    {
        private readonly IPictureService _pictureService;
        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }
        /// <summary>
        /// 获取单个图片信息
        /// </summary>
        /// <param name="id">图片ID</param>
        /// <param name="isValid">是否有效  默认为不筛选 </param>
        /// <returns></returns>
        [Route("{id}"),HttpGet]
        public IActionResult Get(int id, bool? isValid = null)
        {
            return Ok();
        }
        /// <summary>
        /// 获取一批图片
        /// </summary>
        /// <param name="ids">图片ID集合，使用英文逗号隔开</param>
        /// <param name="isValid">是否有效  默认为不筛选 </param>
        /// <returns></returns>
        [Route("")]
        public IActionResult Get(string ids, bool? isValid = null)
        {
            return Ok();
        }


    }
}
