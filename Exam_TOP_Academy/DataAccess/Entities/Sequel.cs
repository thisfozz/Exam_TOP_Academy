using System;
using System.Collections.Generic;

namespace Exam_TOP_Academy.DataAccess.Entities;

public partial class Sequel
{
    public int SequelId { get; set; }

    public int? OriginalBookId { get; set; }

    public string ContinuationTitle { get; set; } = null!;

    public virtual Book? OriginalBook { get; set; }
}
