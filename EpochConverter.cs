using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingApi
{
    public class EpochConverter
    {
        public DateTime Epoch2UTCNow(int epoch)
        {
            var result = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
            return result;
        }
    }
}
