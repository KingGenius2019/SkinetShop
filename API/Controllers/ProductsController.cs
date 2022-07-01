
using API.DTOs;
using AutoMapper;
using Core.Entitiies;
using Core.Interfaces;
using Core.Specifications;

using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<Product> _productsRepo;
        
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductType> productTypeRepo, IGenericRepository<ProductBrand> productBrandRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productsRepo = productsRepo;
        }

        // [HttpGet]
        // public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        // {
        //     var spec = new ProductsWithTypesAndBrandsSpecification();
        //     var products = await _productsRepo.ListAsync(spec);
        //     return _mapper.Map<IReadOnlyList<Product, ProductToReturnDto>>(products);
        // }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

         [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}