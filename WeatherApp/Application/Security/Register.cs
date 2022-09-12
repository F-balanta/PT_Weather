using Application.ErrorHandler;
using Application.Interfaces;
using Application.Validators;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Security
{
    public class Register
    {
        public class CommandRegister : IRequest<UserDto>
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string UserName { get; set; }
        }

        public class RunValidator : AbstractValidator<CommandRegister>
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public RunValidator(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
                RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage("El nombre de usuario es obligatorio");
                RuleFor(x => x.Email).NotEmpty().WithMessage("El email es obligatorio")
                    .EmailAddress().WithMessage("El formato de email es inválido");
                RuleFor(x => x.Password).Password();
                _userManager = userManager;
            }
        }

        public class Manejador : IRequestHandler<CommandRegister, UserDto>
        {
            private readonly DataContext _context;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly ITokenGenerator _jwtGenerador;

            public Manejador(DataContext context, UserManager<ApplicationUser> userManager, ITokenGenerator jwtGenerador)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
            }

            public async Task<UserDto> Handle(CommandRegister request, CancellationToken cancellationToken)
            {
                var exists = await _context.Users.Where(x => x.Email == request.Email).AnyAsync(cancellationToken: cancellationToken);
                if (exists)
                    throw new RestException(HttpStatusCode.BadRequest, new { mensaje = "El email ingresado ya existe" });

                var existeUserName = await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync(cancellationToken: cancellationToken);
                if (existeUserName)
                    throw new RestException(HttpStatusCode.BadRequest, new { mensaje = "El usuario ingresado ya existe" });

                var user = new ApplicationUser
                {
                    Email = request.Email,
                    UserName = request.UserName
                };

                var resultado = await _userManager.CreateAsync(user, request.Password);

                if (resultado.Succeeded)
                {
                    return new UserDto()
                    {
                        Token = _jwtGenerador.CreateToken(user),
                        Email = user.Email,
                        UserName = user.UserName
                    };
                }
                throw new Exception("No se pudo agregar al nuevo usuario");
            }
        }
    }
}
