using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using indirimxApi.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace indirimxApi.Controllers
{
    //[Authorize]
    [Route("api/app")]
    public class AppController : ControllerBase
    {
        private readonly indirimxContext dbContext;

        public AppController(indirimxContext context)
        {
            dbContext = context;
        }

        [AllowAnonymous]
        [Route("add_product"), HttpPost]
        public async Task<bool> AddProduct(Products Product)
        {
            if (Product == null)
                return false;

            Products productData = new Products
            {
                Location = Product.Location,
                Description = Product.Description,
                Store = Product.Store,
                Name = Product.Name,
                Price = Product.Price,
                Like = Product.Like,
                IsConfirm = Product.IsConfirm,
                CreateDate = DateTime.Now,
                Order = Product.Order,
                Deleted = Product.Deleted
            };


            dbContext.Products.Add(productData);
            await dbContext.SaveChangesAsync();

            return true;
        }

        [Route("add_comments"), HttpPost]
        public async Task<bool> AddComment(Comments Comment)
        {

            if (Comment == null)
                return false;

            Comments commentData = new Comments
            {
                Comment = Comment.Comment,
                UserId = Comment.UserId,
                ProductId = Comment.ProductId,
                CreateDate = DateTime.Now,
                Deleted = Comment.Deleted
            };

            dbContext.Comments.Add(commentData);
            await dbContext.SaveChangesAsync();

            return true;
        }

        [Route("add_favorites"), HttpPost]
        public async Task<bool> AddFavorite(Favorites Favorite)
        {
            if (Favorite == null)
                return false;

            Favorites favoritesData = new Favorites
            {
                ProductId = Favorite.ProductId,
                CreateDate = DateTime.Now,
                Deleted = Favorite.Deleted
            };

            dbContext.Favorites.Add(favoritesData);
            await dbContext.SaveChangesAsync();

            return true;
        }

        [AllowAnonymous]
        [Route("add_user"), HttpPost]
        public async Task<CustomUsers> AddUser([FromBody]CustomUsers User)
        {
            if (User == null)
                return null;

            CustomUsers userData = new CustomUsers
            {
                Username = User.Username,
                Email = User.Email,
                Image = User.Image,
                Role = User.Role,
                UserSurName = User.UserSurName
            };
            userData.Deleted = userData.Deleted;
            userData.CreateDate = DateTime.Now;

            dbContext.CustomUsers.Add(userData);
            await dbContext.SaveChangesAsync();

            return userData;
        }

        [AllowAnonymous]
        [Route("get_all_products"), HttpGet]
        public async Task<ICollection<Products>> GetAllProducts()
        {

            var products = dbContext.Products
            .Where(x => x.Deleted != true)
            .Where(x => x.IsConfirm == true).ToList();

            return products;
        }

        [AllowAnonymous]
        [Route("get_product/{id:int}"), HttpGet]
        public async Task<Products> GetProduct(int id)
        {
            var product = dbContext.Products
                .Where(x => x.Deleted != true)
                .Where(x => x.IsConfirm == true).FirstOrDefault();

            return product;
        }

        [AllowAnonymous]
        [Route("get_user"), HttpGet]
        public async Task<CustomUsers> GetUser(string email)
        {
            var user = dbContext.CustomUsers
                .Where(x => x.Deleted != true)
                .Where(x => x.Email == email)
                .FirstOrDefault();

            return user;
        }
    }
}
