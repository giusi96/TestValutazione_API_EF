using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Esercizio.Helpers
{
    public class Config
    {
        private static IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build(); 

        public static string GetConnectionString(string connStringName)
        {
            return config.GetConnectionString(connStringName);
            //oppure
            //string connString = config.GetSection("ConnectionStrings")["TicketDb"];
        }

        public static IConfigurationSection GetSection(string sectionName)
        {
            return config.GetSection(sectionName);
        }

    }
}
