using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.IBLL;
using Project.Model;
using Project.Model.Conditions;
using Project.Model.Dtos;
using Project.WebApi.Filters;

namespace Project.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        ///     添加产品
        /// </summary>
        /// <param name="productDto">实体</param>
        /// <returns></returns>
        [HttpPost("")]
        [Validate]
        public IActionResult Insert([FromBody] ProductDto productDto)
        {
            var product = Mapper.Map<Product>(productDto);
            return Ok(_productService.Insert(product));
        }

        /// <summary>
        ///     批量新增产品
        /// </summary>
        /// <param name="productDtos">实体集合</param>
        /// <returns></returns>
        [HttpPost("bulk_insert")]
        [Validate]
        public IActionResult Insert([FromBody] List<ProductDto> productDtos)
        {
            var products = Mapper.Map<List<Product>>(productDtos);
            var result = _productService.Insert(products);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        ///     更新产品
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="productDto">实体</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Validate]
        public IActionResult Update(int id, [FromBody] ProductDto productDto)
        {
            if (!_productService.Exists(id))
            {
                return NotFound();
            }
            var product = Mapper.Map<Product>(productDto);
            var result = _productService.Update(product);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        ///     逻辑删除产品
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.SoftDelete(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        ///     批量删除产品
        /// </summary>
        /// <param name="ids">主键集合</param>
        /// <returns></returns>
        [HttpPost("bulk_delete")]
        public IActionResult Delete([FromBody] List<int> ids)
        {
            var result = _productService.SoftDelete(ids);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        /// <summary>
        ///     根据主键Id获取实体
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetByPk(int id)
        {
            var product = _productService.GetByPk(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<ProductDto>(product));
        }

        /// <summary>
        ///     根据主键Id集合获取实体集合
        /// </summary>
        /// <param name="ids">主键Id集合</param>
        /// <returns></returns>
        [HttpGet("get_list")]
        public IActionResult GetList(List<int> ids)
        {
            var products = _productService.GetList(ids);
            if (products?.Count>0)
            {
                return Ok(Mapper.Map<List<ProductDto>>(products));
            }
            return NotFound();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sort"></param>
        /// <param name="condition"></param>
        [HttpGet("get_by_page")]
        public IActionResult GetByPage(int? page = null, int? size = null, string sort = "addTime desc", ProductCondition condition = null)
        {
            if (page.HasValue && size.HasValue && page > 0 && size > 0)
            {
                var result = _productService.GetByPage(page.Value, size.Value, sort, condition);
                return Ok(new PageModel<ProductDto>
                {
                    Total = result.Total,
                    Data = Mapper.Map<List<ProductDto>>(result.Data)
                });
            }
            return BadRequest();
        }
    }
}