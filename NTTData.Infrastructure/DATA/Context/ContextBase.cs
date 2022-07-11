using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTData.Core.Entities;
namespace NTTData.Infrastructure.DATA.Context
{
    public partial class BaseDataContext
    {
        public DbSet<MovimientoResult> movimientoConsulta { get; set; }
        public DbSet<MovimientoRealizaResult> movimientoRealiza { get; set; }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimientoResult>(builder =>
            {
                builder.HasNoKey();
                builder.ToView(null);
            });

            modelBuilder.Entity<MovimientoRealizaResult>(builder =>
            {
                builder.HasNoKey();
                builder.ToView(null);
            });
        }



    }
}
