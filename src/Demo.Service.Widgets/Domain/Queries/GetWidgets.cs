using Demo.Service.Widgets.Domain.DataContext;
using Demo.Service.Widgets.Domain.DataModel;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Demo.Service.Profiles.Domain.Queries
{
    public static class GetWidgets
    {
        public class Query : IRequest<IEnumerable<Widget>>
        {

        }

        public class Validator : AbstractValidator<Query>
        {

        }
        
        public class Handler : IRequestHandler<Query, IEnumerable<Widget>>
        {
            private readonly DbTenantContext _db;

            public Handler(DbTenantContext db)
            {
                _db = db;
            }

            public async Task<IEnumerable<Widget>> Handle(Query request, CancellationToken cancellationToken)
            {
                var widgets = await _db
                    .Widgets
                    .AsNoTracking()
                    .ToListAsync();

                return widgets;
            }
        }
    }
}
