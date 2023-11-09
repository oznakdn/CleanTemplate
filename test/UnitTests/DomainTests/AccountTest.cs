using Clean.Domain.Roles;
using Clean.Domain.Users;

namespace DomainTests;

public class AccountTest
{
    [Fact]
    public void CreateUserWithoutRole_When_PropertiesAreValid_Should_Return_Successed()
    {
        var result = User.CreateUser("Jonh","Doe","john_doe","john@mail.com","Test123");
        Assert.True(result.IsSuccessed);
    }

    [Fact]
    public void CreateUserWithoutRole_When_PropertiesAreNotValid_Should_Return_IsFailed()
    {
        var result = User.CreateUser("Jonh","Doe","john_doe","","Test123");
        Assert.True(result.IsFailed);
        Assert.Equal<string>(result.Errors.Single(),"Email cannot be empty!");
    }

    [Fact]
    public void CreateUserWithRole_When_PropertiesAreValid_Should_Return_Successed()
    {
        string roleId = "1552df121dfs31fd214sdf";
        var result = User.CreateUser("Jonh","Doe","john_doe","john@mail.com","Test123",roleId);
        Assert.True(result.IsSuccessed);
    }

    [Fact]
    public void CreateRole_When_PropertiesAreValid_Should_Return_Successed()
    {
        var result = Role.CreateRole("TestRole","This is testrole's description");
        Assert.True(result.IsSuccessed);
    }

    [Fact]
    public void CreateRole_When_PropertiesAreValid_Should_Return_Failed()
    {
        var result = Role.CreateRole("","This is testrole's description");
        Assert.True(result.IsFailed);
        Assert.Equal<string>(result.Errors.First(),"Role title cannot be empty!");
    }
}
