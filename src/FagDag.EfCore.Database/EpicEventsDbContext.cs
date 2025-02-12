using Microsoft.EntityFrameworkCore;

namespace FagDag.EfCore.Database;

public class EpicEventsDbContext(DbContextOptions<EpicEventsDbContext> options) : DbContext(options);
