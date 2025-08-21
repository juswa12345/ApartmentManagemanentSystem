﻿namespace ApartmentManagemanentSystem.API.Configuration
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public TimeSpan TokenLifeSpan { get; set; }
    }
}
