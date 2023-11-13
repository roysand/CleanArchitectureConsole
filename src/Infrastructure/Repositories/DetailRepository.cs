using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class DetailRepository : GenericRepository<Detail>, IDetailRepository<Detail>
{
    public DetailRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
    }
}