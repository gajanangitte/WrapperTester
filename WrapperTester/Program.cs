using Microsoft.PowerShell.Commands;
using System.Management.Automation;

public class Program {
    public static void Main(string[] args) {
        CosmosExeUtils.UploadFile("D:\\Data\\yarnlocalwatchdog\\AccessRestrictionBackgroundTaskConfiguration\\LocalGroupCreationTimeinJSON.txt", "cosmos://cosmossextans-dev-cy2/vol1/gajanangitte/exp1.txt");
        CosmosExeUtils.DownloadFile("cosmos://cosmossextans-dev-cy2/vol1/gajanangitte/exp1.txt", "D:\\gajanangitte\\exp1_local.txt");
    }
}