using BackFinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Datas
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Brend> Brends { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogSpesification> BlogSpesifications { get; set; }
        public DbSet<PolicySection> Policies { get; set; }
        public DbSet<DiscountCategroy> DiscountCategroies { get; set; }
        public DbSet<BestOffer> BestOffers { get; set; }
        public DbSet<BestOfferImages> BestOfferImages { get; set; }
        public DbSet<GiftCard> GiftCards { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}
