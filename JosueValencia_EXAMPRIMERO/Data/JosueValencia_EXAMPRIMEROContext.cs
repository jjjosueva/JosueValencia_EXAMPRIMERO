using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JosueValencia_EXAMPRIMERO.Models;

namespace JosueValencia_EXAMPRIMERO.Data
{
    public class JosueValencia_EXAMPRIMEROContext : DbContext
    {
        public JosueValencia_EXAMPRIMEROContext (DbContextOptions<JosueValencia_EXAMPRIMEROContext> options)
            : base(options)
        {
        }

        public DbSet<JosueValencia_EXAMPRIMERO.Models.Celulares> Celulares { get; set; } = default!;
        public DbSet<JosueValencia_EXAMPRIMERO.Models.JValencia> JValencia { get; set; } = default!;
    }
}
