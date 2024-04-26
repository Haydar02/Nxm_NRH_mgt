﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nxm_NRH_mgt.Models;

[Table("ReceiverService")]
public partial class ReceiverService
{
    [Key]
    public int id { get; set; }

    public int? certificate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string contactName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string contactEmail { get; set; }

    public int? profilingId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string endpointReference { get; set; }

    [InverseProperty("ownercervise")]
    public virtual ICollection<ParticiPantBinding> ParticiPantBindings { get; set; } = new List<ParticiPantBinding>();

    [ForeignKey("profilingId")]
    [InverseProperty("ReceiverServices")]
    public virtual Profiling profiling { get; set; }
}