using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCA.Domain.Entities;
public class Student:BaseAuditableEntity
{
    public int studentID { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    
}
