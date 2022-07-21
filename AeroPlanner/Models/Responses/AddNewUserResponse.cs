using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroPlanner.Models.Requests
{
    public class AddNewUserResponse
    {
        public Guid Id { get; set; }

        public AddNewUserResponse() { }

        public AddNewUserResponse(Guid id)
        {
            Id = id;
        }
    }
}
