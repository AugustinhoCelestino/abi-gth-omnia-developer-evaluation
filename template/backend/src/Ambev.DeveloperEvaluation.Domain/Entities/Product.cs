﻿using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
