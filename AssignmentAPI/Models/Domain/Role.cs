﻿using AssignmentAPI.Models.Domain;

public class Role
{
    public string roleId { get; set; }
    public string roleName { get; set; }
    public ICollection<User>? Users;
}