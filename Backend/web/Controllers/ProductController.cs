using AutoMapper;
using DAL.Entities;
using DAL.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Infrastructures.Services;
using web.Model.products;

namespace web.Controllers
{
    public class ProductController:ApiControllerBase
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public ProductController(IUnitOfWork unitOfWork, ICurrentUserService currentUserService,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<int>> Create(Product product)
        {
            _unitOfWork.Product.Add(product);
            await _unitOfWork.SaveChanges();
            return 1;
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult<int>> Update(Product product)
        {
            _unitOfWork.Product.Update(product);
            await _unitOfWork.SaveChanges();
            return 1;
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult<int>> Delete(Product product)
        {
            _unitOfWork.Product.Remove(product);
            await _unitOfWork.SaveChanges();
            return 1;
        }

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<List<ProductResponseModel>> GetAll()
        {
            var listProductResponse = new List<ProductResponseModel>();

            var listProduct = _unitOfWork.Product.GetAll().ToList();

            foreach (var item in listProduct)
            {
               var productRes = _mapper.Map<ProductResponseModel>(item);

                productRes.ProductCategoryName = _unitOfWork.ProductCategory
                                                            .Find(x => x.Id == item.ProductCategoryId)
                                                            .First().Name;
                productRes.ProviderName = _unitOfWork.Provider
                                                            .Find(x => x.Id == item.ProviderId)
                                                            .First().Name;
                productRes.Quantity = _unitOfWork.Warehouse
                                          .Find(x => x.ProductId == item.Id && x.ProviderId == item.ProviderId)
                                          .First().Quantity;

                listProductResponse.Add(productRes);
            }
            return listProductResponse;
        }
    }
}