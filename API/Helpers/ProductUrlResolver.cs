using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entitiies;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _confiq;
        public ProductUrlResolver(IConfiguration confiq)
        {
            _confiq = confiq;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
             if (!string.IsNullOrEmpty(source.PictureUrl)) 
            {
                return _confiq["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}