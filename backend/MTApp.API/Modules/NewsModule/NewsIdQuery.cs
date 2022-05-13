using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MTApp.API.Models.Data;
using MTApp.API.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MTApp.API.Modules.NewsModule
{
    public class NewsIdQuery : IRequest<NewsRequest>
    {
        public string Language { get; set; }
        public int Id { get; set; }
    }
    public class NewsIdQueryHandler : IRequestHandler<NewsIdQuery, NewsRequest>
    {
        private readonly IMapper mapper;
        private readonly AppDbContext db;

        public NewsIdQueryHandler(IMapper mapper, AppDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        public async Task<NewsRequest> Handle(NewsIdQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<NewsRequest>(await db.News
                .Include(x => x.NewsLanguages.Where(l => l.Language.Label == request.Language))
                .ThenInclude(a => a.Language).FirstOrDefaultAsync(x => x.Id == request.Id));
        }
    }

}
