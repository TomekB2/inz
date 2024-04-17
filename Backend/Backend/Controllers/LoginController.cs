using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Backend.DTO;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private const int saltSize = 128 / 8;
        private const int keysize = 256 / 8;
        private const int iterations = 10000;
        private const char delimiter = ';';
        private IConfiguration _configuration;
        private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost(Name = "Login")]
        public IActionResult Post(UserLoginDTO user)
        {
            User userDB = new User();
            try
            {
                using (var context = new TempContext())
                {
                    userDB = context.Users.Where(x => x.Name == user.UserName).First();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            if (userDB.Name != null)
            {
                var elements = userDB.Password.Split(delimiter);
                var salt = Convert.FromBase64String(elements[0]);
                var hash = Convert.FromBase64String(elements[1]);

                var hashInput = Rfc2898DeriveBytes.Pbkdf2(user.Password, salt, iterations, hashAlgorithm, keysize);
                var result = CryptographicOperations.FixedTimeEquals(hash, hashInput);
                if (result == true)
                {
                    Token tk = new Token();
                    var jwtOptions = _configuration.GetSection("JwtOptions").Get<JwtOptions>();
                    tk.token = "Bearer " + Token.CreateAccessToken(jwtOptions, user.UserName, new TimeSpan(1111111111111));
                    return Ok(tk);
                }
                else return BadRequest();
            }
            else return BadRequest();
            
        }
    }
}
