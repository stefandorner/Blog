using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Swisscom.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        
        public static string GetMariaDBConnectionString(this IConfigurationRoot configuration, string name)
        {
            if (configuration == null)
            {
                return null;
            }
            string vcapsEnvVariables = configuration.GetValue<String>("VCAP_SERVICES");
            if (vcapsEnvVariables == null)
            {
                return null;
            }
            var servicesConfiguration = JsonConvert.DeserializeObject<VCAPServiceConfiguration>(vcapsEnvVariables);
            var databaseInfo = servicesConfiguration.mariadb.Where(db => db.credentials.Name == name).SingleOrDefault();
            if (databaseInfo == null)
            {
                throw new ArgumentException(String.Format("Could not found mariadb configuration for database name '{0}'.", name));
            }
            var credentials = databaseInfo.credentials;
            string connString = String.Format("server={0};database={1};userid={2};pwd={3};sslmode=none;port={4};", credentials.Host, credentials.Database, credentials.Username, credentials.Password, credentials.Port);
            return connString;
        }

    }
}
