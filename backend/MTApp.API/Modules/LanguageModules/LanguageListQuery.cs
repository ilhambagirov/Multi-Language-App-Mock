using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MTApp.API.Models.Data;
using MTApp.API.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace MTApp.API.Modules.LanguageModules
{
    public class LanguageListQuery : IRequest<List<LanguageDto>>
    {
    }
    public class LanguageListQueryHandler : IRequestHandler<LanguageListQuery, List<LanguageDto>>
    {
        private readonly IMapper mapper;
        private readonly AppDbContext db;

        public LanguageListQueryHandler(IMapper mapper, AppDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        public async Task<List<LanguageDto>> Handle(LanguageListQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<LanguageDto>>(await db.Languages.ToListAsync());
        }
    }
}
