#nullable enable

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using OpenAI.TestFramework.Recording;
using OpenAI.TestFramework.Utils;

namespace OpenAI.Tests.Utility;

/// <summary>
/// Test environment configuration for running the OpenAI tests
/// </summary>
public class TestEnvironment
{
    /// <summary>
    /// Creates a new instance.
    /// </summary>
    public TestEnvironment()
    {
        RepoRoot = FindRepoRoot();
        DotNetExe = AssemblyHelper.GetDotnetExecutable()
            ?? throw new InvalidOperationException(
                "Could not determine the dotnet executable to use. Do you have .Net installed or have your paths correctly configured?");
        TestProxyDll = new FileInfo(
            AssemblyHelper.GetAssemblyMetadata<TestRecording>("TestProxyPath")
            ?? throw new InvalidOperationException("Could not determine the path to the recording test proxy DLL"));
        TestProxyHttpsCertPassword = "password";
        TestProxyHttpsCert = new FileInfo(Path.Combine(
            RepoRoot.FullName,
            "external",
            "testproxy",
            "dotnet-devcert.pfx"));
        RecordedAssetsConfig = new FileInfo(Path.Combine(RepoRoot.FullName, "assets.json"));
    }

    /// <summary>
    /// Gets the root Git folder.
    /// </summary>
    public DirectoryInfo RepoRoot { get; }

    /// <summary>
    /// Gets the path to the dotnet executable. This will be used in combination with <see cref="TestProxyDll"/> to start the
    /// recording test proxy service.
    /// </summary>
    public FileInfo DotNetExe { get; }

    /// <summary>
    /// The path to test proxy DLL that will be used when starting the recording test proxy service.
    /// </summary>
    public FileInfo TestProxyDll { get; }

    /// <summary>
    /// Gets the HTTPS certificate file to use as the signing certificate for HTTPS connections to the test proxy.
    /// </summary>
    public FileInfo TestProxyHttpsCert { get; }

    /// <summary>
    /// Gets the password for <see cref="TestProxyHttpsCert"/>.
    /// </summary>
    public string TestProxyHttpsCertPassword { get; }

    /// <summary>
    /// The file that controls where the test recordings are saved to and restored from.
    /// </summary>
    public FileInfo RecordedAssetsConfig { get; }

    /// <summary>
    /// Finds the root directory of the Git repository.
    /// </summary>
    /// <returns>The root directory of the Git repository.</returns>
    private static DirectoryInfo FindRepoRoot()
    {
         // We want to find the folder that is the Git repository root folder. We do this by searching for a directory that contains
         // a .git subfolder starting from the currently executing folder path.

        DirectoryInfo?[] startingPoints =
        [
            new FileInfo(Assembly.GetExecutingAssembly().Location).Directory,
        ];

        foreach (DirectoryInfo? dir in startingPoints)
        {
            if (dir?.Exists != true)
            {
                continue;
            }

            for (var d = dir; d != null; d = d.Parent)
            {
                if (d.EnumerateDirectories(".git").Any())
                {
                    return d;
                }
            }
        }

        throw new InvalidOperationException("Could not determine the root folder for this repository");
    }
}
