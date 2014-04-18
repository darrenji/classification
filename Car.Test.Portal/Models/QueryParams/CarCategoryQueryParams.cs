using System;
namespace Car.Test.Portal.Models.QueryParams
{
    public class CarCategoryQueryParams : QueryParamsBase
    {
        public string Name { get; set; } 
        public DateTime? JoinStartTime { get; set; }
        public DateTime? JoinEndTime { get; set; }
    }
}