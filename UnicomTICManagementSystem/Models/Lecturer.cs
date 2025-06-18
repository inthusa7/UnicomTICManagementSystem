using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Models
{
    internal class Lecturer
    {
        public int LecturerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CourseID { get; set; }      
        public int SubjectID { get; set; }
    }
}



