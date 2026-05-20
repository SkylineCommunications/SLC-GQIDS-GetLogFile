using Skyline.AppInstaller;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.AppPackages;
using Skyline.DataMiner.Utils.SecureCoding.SecureSerialization;
using Skyline.DataMiner.Utils.SecureCoding.SecureIO;
using System;

/// <summary>
/// DataMiner Script Class.
/// </summary>
internal class Script
{
    /// <summary>
    /// The script entry point.
    /// </summary>
    /// <param name="engine">Provides access to the Automation engine.</param>
    /// <param name="context">Provides access to the installation context.</param>
    [AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
    public void Install(IEngine engine, AppInstallContext context)
    {
        try
        {
            engine.Timeout = new TimeSpan(0, 10, 0);
            engine.GenerateInformation("Starting installation");
            var installer = new AppInstaller(Engine.SLNetRaw, context);
            installer.InstallDefaultContent();

            string setupContentPath = installer.GetSetupContentDirectory();

            string destinationFolder = SecurePath.CreateSecurePath(@"C:\ProgramData\Skyline Communications\DataMiner Assistant\Synced Documents\Context\Custom\adhoc");
            if (!System.IO.Directory.Exists(destinationFolder))
            {
                System.IO.Directory.CreateDirectory(destinationFolder);
            }

            string sourceFile = SecurePath.ConstructSecurePath(setupContentPath, "Get Log File.md");
            string destinationFile = SecurePath.ConstructSecurePath(destinationFolder, "Get Log File.md");
            System.IO.File.Copy(sourceFile, destinationFile, true);
        }
        catch (Exception e)
        {
            engine.ExitFail($"Exception encountered during installation: {e}");
        }
    }
}