using System;
using System.Data.SqlTypes;

namespace CulturApp.DAL
{
    public class DbTypeValues
    {
        DataProvider providerType { get; set; }

        public DbTypeValues(DataProvider mProviderType)
        {
            providerType = mProviderType;
        }

        public object GetValue(string dataType, object dataVale)
        {
            object returnValue = dataVale;
            switch (providerType)
            {
                case DataProvider.SqlServer:
                    switch (dataType)
                    {
                        case "Int32":
                            returnValue = (Convert.ToInt32(dataVale) == 0 ? SqlInt32.Null : dataVale);
                            break;
                        case "Int64":
                            returnValue = (Convert.ToInt64(dataVale) == 0 ? SqlInt32.Null : dataVale);
                            break;
                        case "String":
                            string sVale = Convert.ToString(dataVale).Trim();
                            returnValue = (string.IsNullOrEmpty(sVale) ? SqlString.Null : dataVale);
                            break;
                        case "DateTime":
                            DateTime _DateTime = new DateTime();
                            returnValue = (Convert.ToDateTime(dataVale) == _DateTime ? SqlDateTime.Null : dataVale);
                            break;
                        case "Boolean":
                            returnValue = (dataVale == null ? SqlBoolean.Null : Convert.ToBoolean(dataVale));
                            break;
                    }
                    break;
                default:
                    return returnValue;
            }
            return returnValue;
        }

    }
}
