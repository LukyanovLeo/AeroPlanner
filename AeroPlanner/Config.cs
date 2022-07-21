using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroPlanner
{
    public class Config
    {
        public static string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    }
}
