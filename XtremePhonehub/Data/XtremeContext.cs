using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using XtremePhonehub.Entity;
using System.Text;
using Microsoft.Data;

namespace XtremePhonehub.Data

{
    public class XtremeContext : DbContext
    {
        public XtremeContext(DbContextOptions<XtremeContext> options) : base(options)
        {
        }

        public DbSet<XtremeDetails> Details { get; set; }
        public DbSet<xtremeSales> Sales { get; set; }

    }
}