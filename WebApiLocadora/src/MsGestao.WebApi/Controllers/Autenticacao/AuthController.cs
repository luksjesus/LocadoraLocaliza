//using Locadora.Application.ViewModels.Autenticacao;
//using Locadora.Domain.Interfaces.Notificador;
using Locadora.Domain.Notificador;
//using Locadora.Application.ViewModels.Autenticacao;
//using Locadora.Domain.Interfaces.Notificador;
using Locadora.Application.ViewModels.Autenticacao;
//using Locadora.Domain.Interfaces.Notificador;
using Locadora.WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.WebApi.Controllers.Autenticacao
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("Autorizacao/[controller]")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly AppSettings _appSettings;

        public AuthController(INotificador notificador,
                              SignInManager<IdentityUser> signManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSetings) : base(notificador)
        {
            _signManager = signManager;
            _userManager = userManager;
            _appSettings = appSetings.Value;
        }

        /*
        [HttpPost("AlterarSenha")]
        public async Task<ActionResult> AlterarSenha([FromBody] AlteraSenhaUsuarioViewModel usuario) 
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var findUser = await _userManager.FindByEmailAsync(usuario.Email);
            var result = await _userManager.ChangePasswordAsync(findUser, usuario.Password, usuario.NewPassword);

            if (result.Succeeded)
            {
                //var resultado = Login(new LoginUserViewModel() {
                //    Email = usuario.Email,
                //    Password = usuario.NewPassword
                //});

                return CustomResponse();
            } 
            else
            {
                foreach (var error in result.Errors)
                {
                    NotificarErro(error.Description);
                }

                return CustomResponse(usuario);
            }
        }
        */

        [HttpPost("GravarUsuario")]
        public async Task<ActionResult> GravarUsuario([FromBody]UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            IdentityResult result;
            var findUser = await _userManager.FindByEmailAsync(userViewModel.Email);

            if (findUser == null)
            {
                var user = new IdentityUser
                {
                    UserName = userViewModel.UserName,
                    Email = userViewModel.Email,
                    EmailConfirmed = true,
                };

                result = await _userManager.CreateAsync(user, userViewModel.Password);
            } else {
                findUser.UserName = userViewModel.UserName;
                findUser.Email = userViewModel.Email;
                findUser.EmailConfirmed = true;

                result = await _userManager.UpdateAsync(findUser);

                
            }

            if (result.Succeeded)
            {
                return CustomResponse(userViewModel);
            } 
            else 
            { 
                foreach (var error in result.Errors)
                {
                    NotificarErro(error.Description);
                }

                return CustomResponse(userViewModel);
            }
        }

        [HttpPost("GravarPermissoes")]
        public async Task<ActionResult> GravarPermissoes([FromBody] UserViewModelClaims userViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            IdentityResult result;
            var findUser = await _userManager.FindByEmailAsync(userViewModel.Email);

            if (findUser != null)
            {
                //---> pega as claims do usuario
                //
                var claims = await _userManager.GetClaimsAsync(findUser);

                foreach (var claim in claims)
                {
                    result = await _userManager.RemoveClaimAsync(findUser, new Claim(claim.Type, claim.Value));
                };

                foreach (var claim in userViewModel.Claims.Where(c => c.Type != null)) 
                {
                    //try
                    //{
                    result = await _userManager.AddClaimAsync(findUser, new Claim(claim.Type, claim.Value));
                    //}
                    //catch (Exception e)
                    //{
                    //    NotificarErro(e.Message);
                    //}
                    // await _userManager.RemoveClaimAsync(findUser, new Claim(claim.Type, claim.Value));


                    if (!result.Succeeded) 
                    {
                        foreach (var error in result.Errors)
                        {
                            NotificarErro(error.Description);
                        }
                    }
                };                   
            } 
            else 
            {
                NotificarErro("O usuário não encontrado!!");
            }

            return CustomResponse();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]LoginUserViewModel loginUserViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            IdentityUser findUser = await _userManager.FindByEmailAsync(loginUserViewModel.Email); ;

            if (findUser != null)
            {
                var result = await _signManager.PasswordSignInAsync(findUser.UserName, loginUserViewModel.Password, false, true);

                if (result.Succeeded)
                {
                    return CustomResponse(await GerarJWT(loginUserViewModel.Email));
                }

                if (result.IsLockedOut)
                {
                    NotificarErro("Este usuário está temporariamente bloqueado por tentativas inválidas.");
                    return CustomResponse(loginUserViewModel);
                }
            }

            NotificarErro("Usuário e/ou senha incorretos.");
            return CustomResponse(loginUserViewModel);
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return CustomResponse(Ok());
        }

        private async Task<LoginResponseViewModel> GerarJWT(string email)
        {
            //---> pega o usuario pelo email
            //
            var user = await _userManager.FindByEmailAsync(email);

            List<Claim> claimsGeneral = new List<Claim> { 
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64),
            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claimsGeneral);

            var tokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var dataExpire = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras);
            // var dataExpire = DateTime.Now.AddHours(_appSettings.ExpiracaoHoras);

            var token = tokenHandle.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                // Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                Expires = dataExpire,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandle.WriteToken(token);

            //---> pega as claims do usuario
            //
            var claims = await _userManager.GetClaimsAsync(user);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                // ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                // ExpiresIn = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                // ExpiresIn = dataExpire,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        [HttpGet("Get/{Id:Guid}")]
        public async Task<UserTokenViewModel> Get(Guid Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            var claims = await _userManager.GetClaimsAsync(user);

            var userAux = new UserTokenViewModel {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
            };

            return userAux;
        }

        [HttpGet("GetAll")]
        public async Task<List<UserTokenViewModel>> GetAll()
        {
            List<UserTokenViewModel> listUser = new List<UserTokenViewModel>();
            var _users = await _userManager.Users.ToListAsync();

            foreach (var user in _users) {
                var userAux = new UserTokenViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName
                };

                listUser.Add(userAux);
            }
            return listUser;
        }

        

    }
}