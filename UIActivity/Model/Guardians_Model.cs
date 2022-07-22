using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIActivity.Model
{
    public class Guardians_Model
    {
        public int GuardianID { get; set; }
        public int StudentID { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Relationship { get; set; }
        public DateTime CreatedDateTime { get; set; }


    }
}
