using Application.ErrorHandler;
using Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Security
{
    public class Login
    {
        public class CommandLogin : IRequest<UserDto>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class RunValidation : AbstractValidator<CommandLogin>
        {
            public RunValidation()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<CommandLogin, UserDto>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly ITokenGenerator _jwtGenerador;

            public Handler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ITokenGenerator jwtGenerador)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerador = jwtGenerador;
            }

            public async Task<UserDto> Handle(CommandLogin request, CancellationToken cancellationToken)
            {
                var applicationUser = await _userManager.FindByEmailAsync(request.Email);
                if (applicationUser == null)
                {
                    throw new RestException(HttpStatusCode.Unauthorized, new { Usuario = "Usuario inexsitente. Intente nuevamente" });
                }

                var resultado = await _signInManager.CheckPasswordSignInAsync(applicationUser, request.Password, false);

                if (resultado.Succeeded)
                {
                    return new UserDto
                    {
                        Email = applicationUser.Email,
                        UserName = applicationUser.UserName,
                        Token = _jwtGenerador.CreateToken(applicationUser)
                    };
                }
                throw new RestException(HttpStatusCode.Unauthorized);
            }
        }
    }
}
