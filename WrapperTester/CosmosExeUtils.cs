using System.Collections.ObjectModel;
using System.Reflection;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Diagnostics;
public static class CosmosExeUtils {
	/*
		* The static class shall act as a c# wrapper over the csm/adl tool cosmos.exe
		* [path: cosmos.exe -> D/Data/ADLTools ]
		*/
	private static string cosmosExeWrapperScriptPath = Path.Combine(Directory.GetCurrentDirectory(), Constants.CosmosExePowershellWrapperScript);

	private static PowerShell GetPowerShellInstance() {
		return PowerShell.Create().AddScript(File.ReadAllText(cosmosExeWrapperScriptPath));
	}

	public static bool UploadFile(string taskStateDiskFilePath, string storeStreamPath) {
		System.Management.Automation.PowerShell cosmosExePSWrapperInstance = GetPowerShellInstance();
		cosmosExePSWrapperInstance.AddParameter("op", "copy");
		cosmosExePSWrapperInstance.AddParameter("sourceFilePath", taskStateDiskFilePath);
		cosmosExePSWrapperInstance.AddParameter("destinationFilePath", storeStreamPath);
		cosmosExePSWrapperInstance.AddParameter("maxRetries", 3);
		
		string funcName = MethodBase.GetCurrentMethod() is not null ? MethodBase.GetCurrentMethod().Name : "UploadFile";
		
        bool result = InvokePowerShellInstance(cosmosExePSWrapperInstance, funcName);
		return result;
	}

	public static bool DownloadFile(string storeStreamPath, string taskStateDiskFilePath) {
		System.Management.Automation.PowerShell cosmosExePSWrapperInstance = GetPowerShellInstance();
		cosmosExePSWrapperInstance.AddParameter("op", "copy");
		cosmosExePSWrapperInstance.AddParameter("sourceFilePath", storeStreamPath);
		cosmosExePSWrapperInstance.AddParameter("destinationFilePath", taskStateDiskFilePath);
        cosmosExePSWrapperInstance.AddParameter("maxRetries", 3);

        string funcName = MethodBase.GetCurrentMethod() is not null ? MethodBase.GetCurrentMethod().Name : "UploadFile";

        bool result = InvokePowerShellInstance(cosmosExePSWrapperInstance, funcName);
        return result;
    }

	private static bool InvokePowerShellInstance(System.Management.Automation.PowerShell cosmosExePSWrapperInstance, string utilityOperation) {
		try {
			Collection<PSObject> results = cosmosExePSWrapperInstance.Invoke();

            // Capture errors, if any
            if (cosmosExePSWrapperInstance.Streams.Error.Count > 0)
			{
				Console.WriteLine(cosmosExePSWrapperInstance.Streams.Error.Count);
                foreach (ErrorRecord error in cosmosExePSWrapperInstance.Streams.Error)
				{
					Console.WriteLine($"[CosmosExeUtils] Automation.PowerShell Script Error: ({error.ToString()}");
				}
				return false;
			}

            // Display the output from the Automation.PowerShell script
            Console.WriteLine("\nPowerShell Script Output:");
			foreach (PSObject result in results)
			{
				
				string lastexitcode = result.BaseObject.ToString();
				if (lastexitcode.Contains("LASTEXITCODE: 0"))
				{
                    Console.WriteLine($"[CosmosExeUtils] {utilityOperation} operation was successfully executed.");
					return true;
				}
			}
			// Clear the PowerShell instance.
			cosmosExePSWrapperInstance.Commands.Clear();
		}
		catch (FileNotFoundException ex) {
            // Handle file not found exception
            Console.WriteLine($"[CosmosExeUtils] Automation.PowerShell File not found Error: {ex.Message}");
		}
		catch (PSNotSupportedException ex) {
			// Handle Automation.PowerShell not supported exception
			Console.WriteLine($"[CosmosExeUtils] Automation.PowerShell Instance Creation Erro: {ex.Message}");
		}
		catch (CmdletInvocationException ex) {
			// Handle command invocation exception
			Console.WriteLine($"[CosmosExeUtils] Automation.PowerShell Command Invocation Error: {ex.Message}");
		}
		catch (RuntimeException ex) {
			// Handle runtime exception
			Console.WriteLine($"[CosmosExeUtils] Automation.PowerShell Runtime Exception Error: {ex.Message}");
		}
		catch (Exception ex) {

			Console.WriteLine($"[CosmosExeUtils] Automation.PowerShell Unhandled Exception Error: {ex.Message}");
		}
		Console.WriteLine($"[CosmosExeUtils]  {utilityOperation} operation has failed");
		return false;
	}
}