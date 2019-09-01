using Demo.Service.Widgets.Domain.DataContext;
using Demo.Service.Widgets.Domain.DataModel;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Service.Widgets.Domain.Commands
{
    public static class CreateWidget
    {
        public class Command : IRequest
        {
            public Command(Guid id, string name)
            {
                Id = id;
                Name = name;
            }

            public Guid Id { get; }

            public string Name { get; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Name).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DbTenantContext _db;

            public Handler(DbTenantContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var id = request.Id;
                var name = request.Name;

                var widget = new Widget { Id = id, Name = name };

                await _db.Widgets.AddAsync(widget);
                await _db.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
