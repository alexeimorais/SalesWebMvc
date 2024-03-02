namespace SalesWebMvc.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<Seller> sellers { get; set; } = new List<Seller>();

        public Department() { }

        public Department(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public void AddSller(Seller seller) 
        {
            sellers.Add(seller);
        }

        public double TotalSales(DateTime Initial, DateTime Final)
        {
            return sellers.Sum(s => s.TotalSales(Initial, Final));
        }
    }
}
