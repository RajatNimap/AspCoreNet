namespace CodeFirstApi.Models
{
    public class UpdateEmp
    {
        public required string Name { get; set; }
        public required string email { get; set; }
        public string phone { get; set; }
        public double salary { get; set; }

    }
}
