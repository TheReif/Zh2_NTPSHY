﻿using System;
using System.Collections.Generic;

namespace Zh2_NTPSHY.Models;

public partial class Day
{
    public byte DayId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; } = new List<Lesson>();
}
