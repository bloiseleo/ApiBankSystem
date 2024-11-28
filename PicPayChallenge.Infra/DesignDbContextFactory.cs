using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra
{
    internal class DesignDbContextFactory : IDesignTimeDbContextFactory<PicPayContext>
    {
        public PicPayContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PicPayContext>();
            builder.UseNpgsql("User Id=root;Password=root;Host=localhost;Port=5432;Database=picpay");
            return new PicPayContext(builder.Options);
        }
    }
}
