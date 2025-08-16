using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using srv_products.Context;
using srv_products.DTOs;
using srv_products.Models;

namespace srv_products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.Include(p => p.Images).ToList();
            return Ok(_mapper.Map<List<ProductDto>>(products));
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductCreateDto dto)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _mapper.Map(dto, product);
            _context.SaveChanges();
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
