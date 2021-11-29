namespace BecnhProject.Models
{
    public class BenchCharacteristics
    {
        public decimal V { get; set; }
        public decimal S { get; set; }
        public decimal T { get; set; }

        public decimal GetValue() => S * V * T;
    }
}