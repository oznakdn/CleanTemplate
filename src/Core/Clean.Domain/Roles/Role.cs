﻿using Clean.Domain.Contracts.Interfaces;
using Clean.Shared;

namespace Clean.Domain.Roles;

public class Role : IDocument
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement]
    public string Id { get; private set; }
    public string RoleTitle { get; private set; }
    public string Description { get; private set; }
    public bool IsDeleted { get; private set; }

    protected Role(string roleTitle, string description)
    {
        RoleTitle = roleTitle;
        Description = description;
    }
    private Role() { }

    public static IResult<Role> CreateRole(string roleTitle, string description)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(roleTitle)) errors.Add("Role title cannot be empty!");
        if (string.IsNullOrEmpty(description)) errors.Add("Description cannot be empty!");

        if (errors.Count > 0)
            return Result<Role>.Fail(errors:errors);

        Role? role = new Role(roleTitle, description);
        return Result<Role>.Success(value: role);
    }

    public bool Equals(IEntity<string>? other)
    {
        return Id.GetHashCode() == other.GetHashCode();
    }
}
