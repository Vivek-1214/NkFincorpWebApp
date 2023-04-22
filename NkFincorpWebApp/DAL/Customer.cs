using System;
using System.Collections.Generic;

namespace NkFincorpWebApp.DAL;

public partial class Customer
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? PositionId { get; set; }

    public string? MobileNumber { get; set; }

    public string? Password { get; set; }

    public string? AadharCard { get; set; }

    public string? City { get; set; }

    public virtual Position? Position { get; set; }
}
