using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMSApi.ApiModels
{
    public class ApiTaskType: IApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
