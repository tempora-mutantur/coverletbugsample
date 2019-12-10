//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectories("./**/bin");
    CleanDirectories("./**/obj");
    CleanDirectories("./Logs");
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{

    var settings = new MSBuildSettings
    {
        Configuration = "Debug",
        MaxCpuCount = 0,
        Restore = true,
        MSBuildPlatform = MSBuildPlatform.x86
    };

    MSBuild("./src/ClassLibrary/ClassLibrary.sln", settings);
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    string logsDirectory = "./Logs";
    DirectoryPath logsDirectoryPath = MakeAbsolute(Directory(logsDirectory));
    EnsureDirectoryExists(logsDirectoryPath);
    StartProcess("dotnet", new ProcessSettings
        {
            Arguments = $"test ./src/ClassLibrary/ClassLibrary.sln --no-build --logger:\"nunit;LogFilePath={logsDirectoryPath}\\nunit.{{assembly}}.xml\" /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura"
        }
    );
    ReportGenerator($"{logsDirectoryPath}/CodeCoverage/Cobertura/UnitTests/*.results.xml", $"{logsDirectoryPath}/CoverageHTML");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);