﻿namespace laptopMarket.model_dto
{
    public class PutcoponDto
    {
        public string? CoponName { get; set; }
        public string? CoponEvent { get; set; }
        public string? CoponDescription { get; set; }
        public string? Coponvalue { get; set; }
        public int UsageLimit { get; set; }
        public DateTime Expired { get; set; }
    }
}
