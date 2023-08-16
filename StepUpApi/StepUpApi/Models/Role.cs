﻿namespace StepUpApi.Models;

public class Role
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; } = new List<User>();
}