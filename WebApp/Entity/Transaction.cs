using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Entity
{
    public class Transaction
    {
        //[JsonProperty("id")]
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "Amount")]
        public string Amount { get; set; }

        [JsonProperty(PropertyName = "Bank")]
        public string Bank { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "Flag")]
        public string Flag { get; set; }


        //public override string ToString()
        //{
        //    return JsonConvert.SerializeObject(this);
        //}
    }
}