﻿using System.ComponentModel.DataAnnotations;

namespace DigitalElections.Core.DTOs;

public class LoginDTO
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}