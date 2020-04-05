# CheckWhenDoIt

Nothing special just replace this code

```csharp
public class User
{
    public User(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
    }

    public string Name { get; }
}
```

by this


```csharp
public class User
{
    public User(string name)
    {
        Name = Check.NotEmpty(name);
    }

    public string Name { get; }
}
```

### Installing

You can install with [NuGet](https://www.nuget.org/packages/CheckWhenDoIt):

    Install-Package CheckWhenDoIt
    
Or via the .NET Core command line interface:

    dotnet add package CheckWhenDoIt
