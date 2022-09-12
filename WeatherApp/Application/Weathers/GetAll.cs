using Application.Data;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Weathers
{
    public class GetAll
    {
        public class Query : IRequest<List<WeatherDto>>
        {

        }

        public class Handler : IRequestHandler<Query, List<WeatherDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<WeatherDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var weather = await _context.Weather.ToListAsync(cancellationToken);
                var weatherDto = _mapper.Map<List<Weather>, List<WeatherDto>>(weather);
                return weatherDto;
            }
        }
    }
}
