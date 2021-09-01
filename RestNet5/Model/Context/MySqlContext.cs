﻿using Microsoft.EntityFrameworkCore;

namespace RestNet5.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {

        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<BookVO> Books { get; set; }
    }
}