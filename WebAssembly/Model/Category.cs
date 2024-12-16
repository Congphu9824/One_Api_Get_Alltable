namespace WebAssembly.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CateGoryName { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}
