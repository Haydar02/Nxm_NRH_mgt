﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nxm_NRH_mgt.Models;

[Keyless]
[Table("ProfileRole")]
public partial class ProfileRole
{
    public int profilingId { get; set; }

    public int? profilId { get; set; }

    public int? roleId { get; set; }

    public int? documentStandardId { get; set; }

    [ForeignKey("profilingId")]
    public virtual Profiling profiling { get; set; }
}