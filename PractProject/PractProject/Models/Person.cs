using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractProject.Models
{
    public class Person
    {
        public int Person_Id { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string Marital_Status { get; set; }
        public string Gender { get; set; }
        public string Created_By { get; set; }
        public string Modified_By { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime Modified_Date { get; set; }
    }
}
