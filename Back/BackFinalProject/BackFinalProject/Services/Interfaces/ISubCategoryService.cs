﻿using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task<List<SubCategory>> GetSubCategoriesAsync();
        Task<SubCategory> GetSubCategoriesWithIdAsync(int subCategoryID);
        
    }
}
