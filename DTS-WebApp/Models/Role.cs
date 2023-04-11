using System.ComponentModel.DataAnnotations.Schema;

namespace DTS_WebApp.Models;

[Table("tb_m_roles")]
public class Role
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name", TypeName = "varchar(50)")]
    public string Name { get; set; }

    // Cardinality
    public ICollection<AccountRole>? AccountRoles { get; set; }
}
