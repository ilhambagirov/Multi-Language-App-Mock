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
    public class NewsListQuery : IRequest<List<NewsRequest>>
    {
        public string Language { get; set; }
    } 
    public class NewsListQueryHandler : IRequestHandler<NewsListQuery, List<NewsRequest>>
    {
        private readonly IMapper mapper;
        private readonly AppDbContext db;

        public NewsListQueryHandler(IMapper mapper, AppDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        public async Task<List<NewsRequest>> Handle(NewsListQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<NewsRequest>>(await db.News.Include(x => x.NewsLanguages.Where(l => l.Language.Label == request.Language)).ThenInclude(a=>a.Language).ToListAsync());
        }
    }
}
