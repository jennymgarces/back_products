using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using srv_products.Context;
using srv_products.DTOs;
using srv_products.Models;

namespace srv_products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImagesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductImagesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddImage(ProductImageCreateDto dto)
        {
            var product = _context.Products.Find(dto.ProductId);
            if (product == null) return BadRequest("Producto no existe");

            var image = _mapper.Map<ProductImage>(dto);
            _context.ProductImages.Add(image);
            _context.SaveChanges();
            return Ok(_mapper.Map<ProductImageDto>(image));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteImage(int id)
        {
            var image = _context.ProductImages.Find(id);
            if (image == null) return NotFound();

            _context.ProductImages.Remove(image);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
