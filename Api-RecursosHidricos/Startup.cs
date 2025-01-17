﻿using Api_RecursosHidricos.AppContext;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Api_RecursosHidricos
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Database connection with PostgreSQL
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

            // Other configurations
            services.AddControllers();
        }

        // Rest of the code
    }

}
