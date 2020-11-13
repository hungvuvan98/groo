using DAL.Entities;
using DAL.Infrastructures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web.Infrastructures.Services;

namespace web.Controllers
{
    public class ProductController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        public ProductController(IUnitOfWork unitOfWork,ICurrentUserService currentUserService )
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
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

    }
}
