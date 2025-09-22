using System;
using System.Collections.Generic;

namespace FirstUchebka.Data;

public partial class User
{
    public int IdUsers { get; set; }

    public string? Name { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Description { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual Role? Role { get; set; }
}
