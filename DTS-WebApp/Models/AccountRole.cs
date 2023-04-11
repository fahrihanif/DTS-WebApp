using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTS_WebApp.Models;

[Table("tb_m_account_roles")]
public class AccountRole
{
    [Key, Column("id")]
    public int Id { get; set; }
    [Column("employee_nik", TypeName = "char(5)")]
    public string EmployeeNIK { get; set; }
    [Column("role_id")]
    public int RoleId { get; set; }

    // Cardinality
    public Account? Account { get; set; }
    public Role? Role { get; set; }
}
