﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nxm_NRH_mgt.Models;

[Table("ParticiPantBinding")]
public partial class ParticiPantBinding
{
    [Key]
    public int id { get; set; }

    public int? networkTypeId { get; set; }

    public DateOnly? activationDate { get; set; }

    public DateOnly? expirationDate { get; set; }

    public int? ownerparticipantId { get; set; }

    public int? ownercerviseId { get; set; }

    [ForeignKey("ownercerviseId")]
    [InverseProperty("ParticiPantBindings")]
    public virtual ReceiverService ownercervise { get; set; }

    [ForeignKey("ownerparticipantId")]
    [InverseProperty("ParticiPantBindings")]
    public virtual Participant ownerparticipant { get; set; }
}