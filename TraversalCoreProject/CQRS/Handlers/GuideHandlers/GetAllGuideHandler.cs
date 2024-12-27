using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.CQRS.Queries.GuideQueries;
using TraversalCoreProject.CQRS.Results.GuideResults;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuideResult>>
    {
        private readonly Context _context;

        public GetAllGuideHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
           return await _context.Guides.Select(x=>new GetAllGuideResult
           {
               GuideId=x.GuideId,
               Description=x.Description,
               Image=x.Image,
               Name=x.Name,
           }).AsNoTracking().ToListAsync();
        }
    }
}