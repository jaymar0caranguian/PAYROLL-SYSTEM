using System.ComponentModel.DataAnnotations;

namespace WebApplication4.DataDB
{
    public class payslipView
    {
        public Employee EmpID { get; set; }
        public Employee Fname { get; set; }
        public Employee Mname { get; set; }
        public Employee Lname { get; set; }
        public Employee rate { get; set; }
        public Attd Date { get; set; }
		public Attd nd { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1} {2}", Fname, Mname, Lname); }
        }

    }
}
