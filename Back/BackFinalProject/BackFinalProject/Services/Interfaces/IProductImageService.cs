using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<ProductImage> ProductImageWithIdAsync(int id);
    }
}
