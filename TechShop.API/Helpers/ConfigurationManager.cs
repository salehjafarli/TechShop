using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TechShop.Helpers
{
    public class ConfigurationManager : IConfigurationManager
    {
        public async Task<dynamic> GetConfig(bool envSw = false)
        {
            string json;
            string configpath = "./appsettings" + (envSw ? ".Development" : "") + ".json";
            using (StreamReader reader = new StreamReader(configpath))
            {
                json = await reader.ReadToEndAsync();
            }
            dynamic res = JsonConvert.DeserializeObject(json);
            return res;
        }

    }

    public interface IConfigurationManager
    {
        Task<dynamic> GetConfig(bool envSw = false);
    }
}
