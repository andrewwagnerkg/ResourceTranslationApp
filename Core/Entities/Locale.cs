﻿namespace Core.Entities
{
    public class Locale : BaseEntity<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
