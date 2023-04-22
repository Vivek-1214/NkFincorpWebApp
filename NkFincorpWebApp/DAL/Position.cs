using System;
using System.Collections.Generic;

namespace NkFincorpWebApp.DAL;

public partial class Position
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
