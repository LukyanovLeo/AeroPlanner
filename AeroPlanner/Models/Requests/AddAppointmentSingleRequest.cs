using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroPlanner.Models.Requests
{
    public class AddAppointmentSingleRequest
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}
