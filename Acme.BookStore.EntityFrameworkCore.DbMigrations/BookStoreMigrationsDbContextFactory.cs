using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.EntityFrameworkCore.DbMigrations
{
    public class BookStoreMigrationsDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
    {
        public BookStoreDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            //博主用的MSSQL
            //这边使用的是Mysql
            //Add-Migration "Created_Book_Entity"
            //Update-Database
            //官方Bookstroe的教程是有EFCore完成实体创建 这边使用DbContextFactory在DbMigrations项目中创建
            var builder = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"),
                MySqlServerVersion.LatestSupportedServerVersion,
                optionsBuilder => optionsBuilder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName));
            return new BookStoreDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            return builder.Build();
        }
    }
}
