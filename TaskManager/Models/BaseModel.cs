﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public abstract class BaseModel
{
    [Key]
    public int Id { get; set; }
}
