using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.ErrorHandler;
using MediatR;
using Persistence;

namespace Application.Weathers
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var weather = await _context.Weather.FindAsync(request.Id);
                if (weather == null)
                    throw new RestException(HttpStatusCode.NotFound, new { weather = "No se encontró el clima" });

                _context.Remove(weather);
                var value = await _context.SaveChangesAsync(cancellationToken);
                if(value > 0) return Unit.Value;

                throw new Exception("No se pudo eliminar el clima");
            }
        }
    }
}
