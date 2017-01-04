
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Swisscom.Extensions.Configuration
{
    public class VCAPServiceConfiguration
    {
        [JsonProperty(PropertyName = "mariadb")]
        public List<VCAPServiceTypeMariaDB> mariadb { get; set; }
    }

    public class VCAPServiceTypeMariaDB
    {
        [JsonProperty(PropertyName = "credentials")]
        public VCAPServiceTypeMariaDBCredentials credentials { get; set; }
    }

    public class VCAPServiceTypeMariaDBCredentials
    {
        [JsonProperty(PropertyName = "host")]
        public string Host { get; set; }
        [JsonProperty(PropertyName = "database")]
        public string Database { get; set; }
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "port")]
        public string Port { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
