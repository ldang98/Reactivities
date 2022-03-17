using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query :IRequest<List<Activity>>{}

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            //readonly can only be assigned in declaration or constructor
            
            public Handler(DataContext context){
           
                _context = context;
            }

            //put logic here and controller will get the activities from this query
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                return await _context.Activities.ToListAsync();
            }
        }
    }
}