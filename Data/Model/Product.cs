﻿namespace Data.Model
{
    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public virtual ICollection<Category>? Categories { get; set; }
    }
}
