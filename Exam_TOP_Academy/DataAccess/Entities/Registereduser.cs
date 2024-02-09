using System;
using System.Collections.Generic;

namespace Exam_TOP_Academy.DataAccess.Entities;

public partial class Registereduser
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
}
