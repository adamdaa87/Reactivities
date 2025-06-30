using Microsoft.EntityFrameworkCore;
using System;
using Domain;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<Domain.Activity> Activities { get; set; }
}
