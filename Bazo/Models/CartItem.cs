﻿namespace Bazo.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
