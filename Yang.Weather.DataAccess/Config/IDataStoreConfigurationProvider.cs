using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Weather.DataAccess.Config
{
    public interface IDataStoreConfigurationProvider
    {
        string ConnectionString { get; }
    }
}
