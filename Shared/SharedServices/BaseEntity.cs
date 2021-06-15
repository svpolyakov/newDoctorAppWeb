
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class BaseEntity 
{
    [Key]
    public int ID { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public int Counter { get; set; }
    public string Hash { get; set; }
    public string Code { get; set; }
}
