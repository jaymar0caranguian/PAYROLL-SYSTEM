using System.ComponentModel.DataAnnotations;

namespace WebApplication4.DataDB
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        public string Fname { get; set; } = null!;

        public string? Mname { get; set; }

        public string Lname { get; set; } = null!;

        public string Position { get; set; } = null!;

        public int Rate { get; set; }

        public int SssNo { get; set; }

        public int PagibigNo { get; set; }
    }
}
