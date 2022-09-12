using AutoMapper;
using MediatR;
using Persistence;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.ErrorHandler;

namespace Application.Weathers
{
    public class Edit
    {
        public class CommandId : IRequest
        {
            public int Id { get; set; }
            public string City { get; set; }
            public string CityImageUrl { get; set; }
            public int? Temperature { get; set; }
            public int? TempMin { get; set; }
            public int? TempMax { get; set; }
        }

        public class Handler : IRequestHandler<CommandId>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CommandId request, CancellationToken cancellationToken)
            {
                var weather = await _context.Weather.FindAsync(request.Id);
                if (weather == null)
                    throw new RestException(HttpStatusCode.NotFound, new { weather = "No se encontró el clima" });

                weather.City = request.City ?? weather.City;
                weather.Temperature = request.Temperature ?? weather.Temperature;
                weather.CityImageUrl = request.CityImageUrl ?? weather.CityImageUrl;
                weather.TempMax = request.TempMax ?? weather.TempMax;
                weather.TempMin= request.TempMin ?? weather.TempMin;
                var value = await _context.SaveChangesAsync(cancellationToken);
                if (value > 0) return Unit.Value;

                throw new Exception("No se pudo modificar el clima");
            }
        }
    }
}
