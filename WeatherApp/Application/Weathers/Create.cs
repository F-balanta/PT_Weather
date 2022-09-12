using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Weathers
{
    public class Create
    {
        public class Command : IRequest
        {
            public string City { get; set; }
            public string CityImageUrl { get; set; }
            public int Temperature { get; set; }
            public int TempMin { get; set; }
            public int TempMax { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public class RunValidation : AbstractValidator<Command>
            {
                public RunValidation()
                {
                    RuleFor(x => x.City).NotEmpty().WithMessage("Ingresa la ciudad");
                    RuleFor(x => x.Temperature).NotEmpty().WithMessage("La temperatura es obligatoria");
                    RuleFor(x => x.TempMin).NotEmpty().WithMessage("La temperatura minima es requerida");
                    RuleFor(x => x.TempMax).NotEmpty().WithMessage("La temperatura máxima es requerida");
                    RuleFor(x => x.CityImageUrl).NotEmpty().WithMessage("Ingresa la URL de la imagen");
                }
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var weather = new Weather
                {
                    City = request.City, 
                    Temperature = request.Temperature,
                    CityImageUrl = request.CityImageUrl,
                    TempMax = request.TempMax,
                    TempMin = request.TempMin
                };
                _context.Weather.Add(weather);
                var value = await _context.SaveChangesAsync(cancellationToken);
                if(value > 0) return Unit.Value;

                throw new Exception("No se pudo registrar el clima");
            }
        }
    }
}
