using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;


namespace Student_API2.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public string Avatar { get; set; }
    }
}
