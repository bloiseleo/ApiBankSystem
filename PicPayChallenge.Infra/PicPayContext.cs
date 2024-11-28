using Microsoft.EntityFrameworkCore;
using PicPayChallenge.Infra.Entities;

namespace PicPayChallenge.Infra;

public class PicPayContext(DbContextOptions<PicPayContext> context): DbContext(context)
{
    public DbSet<UserEntitiy> Users { get; set; }
    public DbSet<WalletEntity> Wallets { get; set; }
    public DbSet<TransactionEntity> Transactions { get; set; }
}
