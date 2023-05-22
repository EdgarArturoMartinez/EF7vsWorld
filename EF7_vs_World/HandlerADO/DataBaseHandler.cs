using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF7_vs_World.HandlerADO
{
    public abstract class DataBaseHandler
    {
        public const string ConnectionString =
            "Server=WINDEV2303EVAL;Database=AdventureWorks2019; Trusted_Connection=True; TrustServerCertificate=True; Connection Timeout=9000";
    }
}
