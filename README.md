# Welcome GenericLoggingSystem!

Generic logging system is a C# .NET Core library that provides you with pre-written functionality to

 1. Log to the Console
 2. Log to a file in a specified directory
 3. Create and customize new or already existing log formats

You can download and install the lastest stable version of this library on [NuGet](https://www.nuget.org/packages/GenericLoggingSystem_unsigned-ru) or in the NuGet Package Manager in Visual Studio.


# Getting Started
First, include the before you log anything, include the "GenericLoggingSystem" namespace and Initialize the LogStream.

```csharp
// Will set the logfile directory to the assembly directory/Logs/{date}.log
LogStream.Initialize();
```

OR
```csharp
//if you want to specify a directory for the logfile yourself
LogStream.Initialize("C:/AllOfMyLogfiles/MyTestApp");
```

After initializing you can either:

1. Use an existing Log class:

```csharp
public static void Main()
{
    LogStream.Initialize();

    try
    {
        throw new Exception("This code totally just broke! Let's log it to both the console, " +
            "and a file for later inspection.");
    }
    catch (Exception e)
    {
        //no need to store this, it will do what it is made to do, Log to both the file and the console.
        new SeverityLog("Startup", e.Message, Severity.Error, e);
    }
}
```
Console and log file output:
```
[ERROR   ] 18:29:31 Startup      This code totally just broke! Let's log it to both the console, and a     file for later inspection.
    System.Exception: This code totally just broke! Let's log it to both the console, and a file for later inspection.
    at HaikhuuStockDisplayBot.Program.Main() in H:\BotProjects\HaikhuuStockDisplayBot\Program.cs:line 25
```

2. Create your own
You can create your own or override existing LogClasses by creating a new class that Inherits the `GenericLogSystem.Log` class.
The Log class contains virtual functions you can override:
```csharp
// ! YOU NEED TO OVERRIDE THIS ONE !
// This function returns the string that will get logged to both the console and the file
public override string Serialize()
    => $"Formatted logging string here {MyVariable1} is doing amazing!"; 

// This one is optional, the base function will write the serialized string into the
// console and the logfile, but if you want to make it do something extra,
// you can do so here!
public override void Execute()
{
    base.Execute();
    //something extra here!
}
```
A full example of a logging class can be found [here](https://github.com/unsigned-ru/GenericLoggingSystem/blob/main/SeverityLog.cs)

# Feature requests & Issues 

Feel free to open Issues on the [github page](https://github.com/unsigned-ru/GenericLoggingSystem) for feature requests, or any issues that might occur with the library.

# Versioning
This library generally abides by  [Semantic Versioning](https://semver.org/). Packages are published in MAJOR.MINOR.PATCH version format.

An increment of the PATCH component always indicates that an internal-only change was made, generally a bugfix. These changes will not affect the public-facing API in any way, and are always guaranteed to be forward- and backwards-compatible with your codebase, any pre-compiled dependencies of your codebase.

An increment of the MINOR component indicates that some addition was made to the library. All previously written code will keep working.

An increment of the MAJOR component indicates that there are breaking changes which will break previously written code, These changes will be listed in release descriptions.
