using System;
using System.Collections.Generic;

namespace EFCORE_MVC.Models;

public partial class EfcoreEmployee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Department { get; set; }
}
