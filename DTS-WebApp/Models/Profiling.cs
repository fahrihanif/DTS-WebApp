using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTS_WebApp.Models;

[Table("tb_m_profilings")]
public class Profiling
{
    [Key, Column("id", TypeName = "char(5)")]
    public string EmployeeNIK { get; set; }
    [Column("education_id")]
    public int EducationId { get; set; }

    // Cardinality
    public Employee? Employee { get; set; }
    public Education? Education { get; set; }
}
