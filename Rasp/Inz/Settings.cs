using Inz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inz
{
    internal static class Settings
    {
        public static string GetPeriod()
        {
            using (var context = new AppDbContext())
            {
               return context.settings.Where(x => x.name == "PeriodInMinutes").First().value;
            }
        }
    }
}
