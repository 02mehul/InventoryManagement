using AutoMapper;
using InventoryManagement.Common.DTOs.Master;
using InventoryManagement.Entity.Master;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace InventoryManagement.Service
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Guid, ProductEntity> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Guid, ProductEntity> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDTO> GetProductId(string role)
        {
            var productId = await _productRepository.Where(r => r.ProductName == Convert.ToString(role)).SingleOrDefaultAsync();
            return _mapper.Map<ProductDTO>(productId);
        }

        public IQueryable<ProductDTO> GetAll()
        {
            return _productRepository.GetAll().OrderBy(k => k.ProductName).Select(k => _mapper.Map<ProductDTO>(k));
        }
    }
}
