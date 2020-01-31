//using indirimxApi.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;

//namespace indirimxApi.Helpers
//{
//    public static class AppHelper
//    {
//        private readonly indirimxContext _context;

//        public AppHelper(indirimxContext context)
//        {
//            _context = context;
//        }
//        public async static Task<int> AddProduct(Products Product)
//        {
//            using (var dbContext = new indirimxContext())
//            {

//                if (Product == null)
//                    return 0;

//                Products productData = new Products
//                {
//                    Location = Product.Location,
//                    Description = Product.Description,
//                    Store = Product.Store,
//                    Name = Product.Name,
//                    Price = Product.Price,
//                    Like = Product.Like,
//                    IsConfirm = Product.IsConfirm,
//                    CreateDate = DateTime.Now,
//                    Order = Product.Order,
//                    Deleted = Product.Deleted
//                };


//                dbContext.Products.Add(productData);

//                return await dbContext.SaveChangesAsync();
//            }
//        }

//        public async static Task<int> AddComment(Comments Comment)
//        {
//            using (var dbContext = new indirimxContext())
//            {
//                if (Comment == null)
//                    return 0;

//                Comments commentData = new Comments
//                {
//                    Comment = Comment.Comment,
//                    UserId = Comment.UserId,
//                    ProductId = Comment.ProductId,
//                    CreateDate = DateTime.Now,
//                    Deleted = Comment.Deleted
//                };

//                dbContext.Comments.Add(commentData);

//                return await dbContext.SaveChangesAsync();
//            }
//        }

//        public async static Task<int> AddFavorite(Favorites Favorite)
//        {
//            using (var dbContext = new indirimxContext())
//            {

//                if (Favorite == null)
//                    return 0;

//                Favorites favoritesData = new Favorites
//                {
//                    ProductId = Favorite.ProductId,
//                    CreateDate = DateTime.Now,
//                    Deleted = Favorite.Deleted
//                };

//                dbContext.Favorites.Add(favoritesData);

//                return await dbContext.SaveChangesAsync();
//            }
//        }

//        public async static Task<CustomUsers> AddUser(CustomUsers User)
//        {
//            using (var dbContext = new indirimxContext())
//            {
//                if (User == null)
//                    return null;

//                CustomUsers userData = new CustomUsers
//                {
//                    Username = User.Username,
//                    Email = User.Email,
//                    Image = User.Image,
//                    Role = User.Role,
//                    UserSurName = User.UserSurName
//                };
//                userData.Deleted = userData.Deleted;
//                userData.CreateDate = DateTime.Now;

//                dbContext.CustomUsers.Add(userData);
//                dbContext.SaveChanges();

//                return userData;
//            }
//        }

//        public async static Task<IList<Products>> GetAllProducts()
//        {
//            using (var dbContext = new indirimxContext())
//            {

//                var products = dbContext.Products
//                .Where(x => x.Deleted != true)
//                .Where(x => x.IsConfirm == true).ToListAsync();

//                return await products;
//            }
//        }

//        public async static Task<Products> GetProduct(int id)
//        {
//            using (var dbContext = new indirimxContext())
//            {
//                var product = dbContext.Products
//                .Where(x => x.Deleted != true)
//                .Where(x => x.IsConfirm == true).FirstOrDefaultAsync();

//                return await product;
//            }
//        }

//        public async static Task<CustomUsers> GetUser(string email)
//        {
//            using (var dbContext = new indirimxContext())
//            {
//                var user = dbContext.CustomUsers
//                .Where(x => x.Deleted != true)
//                .Where(x => x.Email == email)
//                .FirstOrDefaultAsync();

//                return await user;
//            }
//        }
//    }
//}