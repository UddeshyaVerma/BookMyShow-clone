using BookMyShowApi.Models;
using BookMyShowApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookMyShowApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IAppRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        public AppController(IAppRepository repo, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
           
        }

        [HttpPost]
        [Route("Register")]

        //public ActionResult Post(UserModel user)
        //{
        //    _repo.Register(user);
        //    return Ok(user);
        //}
        public async Task<Object> Register(UserModel user)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.Phone,
                City = user.City,

            };
            try
            {
                var res=await _userManager.CreateAsync(applicationUser,user.Password);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login(LoginModel login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user,login.Password))
            {
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567891234567")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDesc);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest("Invalid Credentials");
            }
        }
        




        [HttpGet]
        [Route("GetAll")]

        public IEnumerable<UserModel> Get()
        {
            
            return _repo.Get();
        }

        [HttpDelete]
        [Route("/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok("deleted Successfully");
        }

        [HttpGet]
        [Route("/getOne/{id}")]
        public UserModel Getone(int id)
        {
            
            return _repo.GetOne(id); 
        }
    }


}
