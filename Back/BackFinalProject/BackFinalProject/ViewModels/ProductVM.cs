using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class ProductVM
    {
        private readonly Product product;

        public ProductVM(Product product)
        {
            this.product = product;
        }
        public decimal DiscountedPrice
        {
            get
            {
                if (product.Discount > 0)
                {
                    return product.RealPrice * (100 - product.Discount) / 100;
                }
                else
                {
                    return 0;
                }

            }
        }
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Comment> Comments { get; set; }
        public int WishListCount { get; set; }
        public List<WishListVM> WishListVM { get; set; }
    }
}
