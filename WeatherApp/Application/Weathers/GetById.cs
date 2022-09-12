using Application.Data;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Weathers
{
    public class GetById
    {
        public class Query : IRequest<WeatherDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, WeatherDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<WeatherDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var weather = await _context.Weather.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
                var weatherDto = _mapper.Map<Weather, WeatherDto>(weather);
                return weatherDto;
            }
        }
    }
}
