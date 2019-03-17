using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMSApi.ModelMappers;

namespace TMSApi.ApiModels
{
    public class ApiTask: IApiModel
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime RequestByDate { get; set; }
        public List<User> AssignedTo { get; set; }
        public DateTime NextActionDate { get; set; }
    }
}
