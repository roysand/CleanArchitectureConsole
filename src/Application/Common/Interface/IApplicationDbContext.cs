using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Application.Common.Interface;

public interface IApplicationDbContext
{
    DbSet<Detail> DetailSet { get; set; }
}