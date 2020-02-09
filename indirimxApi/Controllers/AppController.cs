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
using Microsoft.EntityFrameworkCore;

namespace indirimxApi.Controllers
{
    [Route("api/app")]
    public class AppController : ControllerBase
    {
        private readonly indirimxContext dbContext;

        public AppController(indirimxContext context)
        {
            dbContext = context;
        }

        [Route("add_product"), HttpPost]
        public async Task<bool> AddProduct(Products Product)
        {
            if (Product == null)
                return false;

            Products productData = new Products
            {
                location = Product.location,
                description = Product.description,
                store = Product.store,
                name = Product.name,
                price = Product.price,
                likes_count = Product.likes_count,
                comments_count = Product.comments_count,
                is_active = Product.is_active,
                create_date = DateTime.Now,
                order = Product.order,
                deleted = Product.deleted
            };


            dbContext.Products.Add(productData);
            await dbContext.SaveChangesAsync();

            return true;
        }

        [Route("add_comments"), HttpPost]
        public async Task<bool> AddComment([FromBody]JObject obj)
        {

            if (obj == null)
                return false;
          

            Comments commentData = new Comments
            {
                comment = "atakan",
                user_id = 1,
                create_date = DateTime.Now,
                deleted = false
            };

            dbContext.Comments.Add(commentData);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddFavorite(Favorites Favorite)
        {
            if (Favorite == null)
                return false;

            Favorites favoritesData = new Favorites
            {
                product = Favorite.product,
                create_date = DateTime.Now,
                deleted = Favorite.deleted
            };

            dbContext.Favorites.Add(favoritesData);
            await dbContext.SaveChangesAsync();

            return true;
        }

        [Route("add_user"), HttpPost]
        public async Task<Users> AddUser([FromBody]Users User)
        {
            if (User == null)
                return null;

            Users userData = new Users
            {
                name = User.name,
                email = User.email,
                image = User.image,
                role = User.role,
                sure_name = User.sure_name
            };
            userData.deleted = userData.deleted;
            userData.create_date = DateTime.Now;

            dbContext.Users.Add(userData);
            await dbContext.SaveChangesAsync();

            return userData;
        }

        [Route("get_all_products"), HttpGet]
        public async Task<ICollection<Products>> GetAllProducts()
        {

            var products = dbContext.Products
            .Include(x => x.image)
            .Include(x => x.comment)
            .Where(x => x.deleted != true)
            .Where(x => x.is_active == true).ToList();

            return products;
        }

        [Route("get_product/{id:int}"), HttpGet]
        public async Task<Products> GetProduct(int id)
        {
            var product = dbContext.Products
                .Include(x => x.image)
                .Include(x => x.comment)
                .Where(x => x.deleted != true)
                .Where(x => x.id == id)
                .Where(x => x.is_active == true).FirstOrDefault();

            return product;
        }

        [Route("get_user_products/{id:int}"), HttpGet]
        public async Task<ICollection<Products>> GetUserProducts(int id)
        {
            var products = dbContext.Products
                .Include(x => x.image)
                .Include(x => x.comment)
                .Where(x => x.deleted != true)
                .Where(x => x.user.id == id)
                .Where(x => x.is_active == true).ToList();

            return products;
        }

        [Route("get_comment/{id:int}"), HttpGet]
        public async Task<ICollection<Comments>> GetComment(int id)
        {
            var comments = dbContext.Comments
                .Where(x => x.deleted != true)
                .Where(x => x.product_id == id)
                .ToList();         
    
            return comments;

        }

        [Route("get_user"), HttpGet]
        public async Task<Users> GetUser(string email)
        {
            var user = dbContext.Users
                .Where(x => x.deleted != true)
                .FirstOrDefault();

            return user;
        }
    }
}
