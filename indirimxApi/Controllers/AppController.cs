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
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace indirimxApi.Controllers
{
    [Authorize]
    [Route("api/app")]
    public class AppController : ControllerBase
    {
        private readonly indirimxContext dbContext;
        private readonly IConfiguration _config;


        public AppController(indirimxContext context, IConfiguration config)
        {
            dbContext = context;
            _config = config;
        }

        [AllowAnonymous]
        [Route("token"), HttpPost]
        public IActionResult Post([FromBody]JObject request)
        {
            string email = request["email"].ToString();
            string password = request["password"].ToString();

            var user = dbContext.Users
           .Where(x => x.Deleted != true && x.Email == email && x.Password == password)
           .FirstOrDefault();

            if (user == null)
                return Unauthorized();

            //TODO: Check credentials from some user management system

            //So we checked, and let's create a valid token with some Claim
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Application:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "indirimxApp",
                Issuer = "indirimx.api.demo",
                Subject = new ClaimsIdentity(new Claim[]
                {
                   //Add any claim
                    new Claim(ClaimTypes.Name, user.Name)
                }),

                //Expire token after some time
                Expires = DateTime.UtcNow.AddDays(30),

                //Let's also sign token credentials for a security aspect, this is important!!!
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            //So see token info also please check token
            // return Ok(new { TokenInfo = token });

            //Return token in some way
            //to the clients so that they can use it
            //return it with header would be nice
            return Ok(new { Token = tokenString, User = user });
        }

        [AllowAnonymous]
        [Route("add_product"), HttpPost]
        public async Task<bool> AddProduct([FromBody]JObject Product)
        {
            if (Product == null)
                return false;

            Products productData = new Products
            {
                Location = (string)Product["location"],
                Description = (string)Product["description"],
                Store = (string)Product["store"],
                Name = (string)Product["name"],
                Price = (int)Product["price"],
                IsActive = true,
                CreatedAt = DateTime.Now,
                Order = 1,
                Deleted = false,
            };


            dbContext.Products.Add(productData);
            await dbContext.SaveChangesAsync();

            return true;
        }

        //[AllowAnonymous]
        //[Route("add_comments"), HttpPost]
        //public async Task<bool> AddComment([FromBody]JObject obj)
        //{

        //    if (obj == null)
        //        return false;


        //    Comments commentData = new Comments
        //    {
        //        Comment = (string)obj["name"],
        //        User = 1,
        //        ProductId = (int)obj["productId"],
        //        CreatedAt = DateTime.Now,
        //        Deleted = false
        //    };

        //    dbContext.Comments.Add(commentData);
        //    await dbContext.SaveChangesAsync();

        //    return true;
        //}

        [AllowAnonymous]
        [Route("add_favorite"), HttpPost]
        public async Task<bool> AddFavorite(Favorites Favorite)
        {
            if (Favorite == null)
                return false;

            Favorites favoritesData = new Favorites
            {
                Product = Favorite.Product,
                CreatedAt = DateTime.Now,
                Deleted = Favorite.Deleted
            };

            dbContext.Favorites.Add(favoritesData);
            await dbContext.SaveChangesAsync();

            return true;
        }

        [AllowAnonymous]
        [Route("add_user"), HttpPost]
        public async Task<Users> AddUser([FromBody]JObject User)
        {
            if (User == null)
                return null;

            Users userData = new Users
            {
                Name = (string)User["name"],
                Email = (string)User["email"],
                Password = (string)User["password"],
                Image = (string)User["image"],
                Role = (string)User["role"],
                SureName = (string)User["surename"],
            };
            userData.Deleted = userData.Deleted;
            userData.CreatedAt = DateTime.Now;

            dbContext.Users.Add(userData);
            await dbContext.SaveChangesAsync();

            return userData;
        }

        [AllowAnonymous]
        [Route("get_all_products"), HttpGet]
        public async Task<Products> GetAllProducts()
        {

            var products = dbContext.Products
            .Include(x => x.Images)
            .Include(x => x.Comments)
            .Include(x => x.Favorites)
            .Where(x => x.Deleted != true)
            .Where(x => x.IsActive == true).FirstOrDefault();

            return products;
        }

        [AllowAnonymous]
        [Route("get_product/{id:int}"), HttpGet]
        public async Task<Products> GetProduct(int id)
        {
            var product = dbContext.Products
                .Include(x => x.Images)
                .Include(x => x.Comments)
                .Where(x => x.Deleted != true)
                .Where(x => x.User.Id == id)
                .Where(x => x.IsActive == true).FirstOrDefault();

            return product;
        }

        [AllowAnonymous]
        [Route("get_user_products/{id:int}"), HttpGet]
        public async Task<ICollection<Products>> GetUserProducts(int id)
        {
            var products = dbContext.Products
                .Include(x => x.Images)
                .Include(x => x.Comments)
                .Where(x => x.Deleted != true)
                .Where(x => x.User.Id == id)
                .Where(x => x.IsActive == true).ToList();

            return products;
        }

        //[AllowAnonymous]
        //[Route("get_comments/{id:int}"), HttpGet]
        //public async Task<ICollection<Comments>> GetComments(int id)
        //{
        //    var comments = dbContext.Comments
        //        .Where(x => x.Deleted != true)
        //        .Where(x => x.ProductId == id)
        //        .Take(5)
        //        .ToList();

        //    return comments;

        //}

        //[AllowAnonymous]
        //[Route("get_all_comments/{id:int}"), HttpGet]
        //public async Task<ICollection<Comments>> GetAllComments(int id)
        //{
        //    var comments = dbContext.Comments
        //        .Where(x => x.Deleted != true)
        //        .Where(x => x.ProductId == id)
        //        .ToList();

        //    return comments;

        //}

        [AllowAnonymous]
        [Route("delete_comment/{id:int}"), HttpGet]
        public async Task<bool> DeleteComment(int id)
        {
            if (id == 0)
                return false;

            var obj = new Comments();
            obj.Id = id;
            obj.Deleted = true;

            dbContext.Comments.Update(obj);
            await dbContext.SaveChangesAsync();

            return true;
        }

        [AllowAnonymous]
        [Route("delete_product/{id:int}"), HttpGet]
        public async Task<bool> DeleteProduct(int id)
        {
            if (id == 0)
                return false;

            var obj = new Products();
            obj.Id = id;
            obj.Deleted = true;

            dbContext.Products.Update(obj);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
