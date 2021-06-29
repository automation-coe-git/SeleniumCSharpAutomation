using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramwork.Utilities
{
    public class JsonUtil
    {
        public List<T> GetJsonDataAsList<T>(string jsonRootPath, string jsonString)
        {
            JObject jsonParseObject = JObject.Parse(jsonString);
            var jsonFiledata = jsonParseObject.SelectToken(jsonRootPath).ToString();
            return JsonConvert.DeserializeObject<List<T>>(jsonFiledata);
        }
        public T GetJsonDataAsObject<T>(string jsonRootPath, string jsonString)
        {
            JObject jsonParseObject = JObject.Parse(jsonString);
            var jsonFiledata = jsonParseObject.SelectToken(jsonRootPath).ToString();
            return JsonConvert.DeserializeObject<T>(jsonFiledata);
        }
    }
}
