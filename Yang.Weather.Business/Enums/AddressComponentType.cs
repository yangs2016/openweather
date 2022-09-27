using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Weather.Business.Enums
{
    public enum AddressComponentType
    {
        Unknown=0,
        StreetNumber = 1,
        Route =2,
        Neighborhood=3,
        Political=4,
        Locality=5,
        AdministrativeAreaLevel1 = 5,
        AdministrativeAreaLevel2 =6,
        Country =7,
        PostalCode=8,
        PostalCodeSuffix=9
  }
}
