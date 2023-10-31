public class Constants
{
    public const string ConfigName = "yarnlocalwatchdog.ini.flattened.ini";
    public const string ServiceName = "YarnLocalWatchdog";
    public const string AppConfigName = "Microsoft.Yarnpp.YarnLocalWatchdog.exe.config";

    // Config key for YarnLocalWatchdogConfig.
    public const string MachinePropertyLevelOnFailure = "MachinePropertyLevelOnFailure";
    public const string SleepIntervalInMs = "SleepIntervalInMs";
    public const string PidToProcNameDictRefreshRate = "PidToProcNameDictRefreshRate";
    public const string IfxSessionName = "IfxSessionName";
    public const string GenevaMetricsAccount = "GenevaMetricsAccount";
    public const string MetricsEmissionConfiguration = "MetricsEmissionConfiguration";

    // Configs for CosmosStoreUtils 
    public const string CosmosStoreUtilsSection = "Common";
    public const string MaximumRetryCount = "MaximumRetryCount";
    public const string DefaultMaximumRetryCount= "DefaultMaximumRetryCount";
    public const string MinimumBackOffTimeout= "MinimumBackOffTimeout";
    public const string DefaultMinimumBackOffTimeout= "DefaultMinimumBackOffTimeout";
    public const string MaximumBackOffTimeout= "MaximumBackOffTimeout";
    public const string DefaultMaximumBackOffTimeout= "DefaultMaximumBackOffTimeout";
    public const string DeltaBackOffTimeout= "DeltaBackOffTimeout";
    public const string DefaultDeltaBackOffTimeout= "DefaultDeltaBackOffTimeout";

    // Configs for CosmosExeUtils
    public const string CosmosExePowershellWrapperScript = "CosmosExeWrapperScript.ps1";

    // Configs for MultiUserLowPriv
    public const string LowPrivStateDirectory = "D:\\Data\\yarnlocalwatchdog\\LowPrivState";
    public const string LowPrivLocalStagingDirectory = "D:\\Data\\yarnlocalwatchdog\\stage";
    public const string LowPrivGroupName = "CosmosSandboxUserGroup";
    public const string LowPrivAccessRestrictionsStateFile = "LowPrivAccessRestrictionsState.txt";

    // Default value for input params
    public const uint DEFAULT_MEMORY_USAGE_LIMIT_THRESHOLD_MULTIPLIER = 3;
    public const uint DEFAULT_MONITORING_TEST_TIMEOUT_IN_MS = 600000;
    public const uint DEFAULT_MEMORY_PRESSURE_THRESHOLD_IN_GB = 5;
    public const uint DEFAULT_MAX_CPU_AFFINITY = 6;
    public const string DEFAULT_CONTAINER_CPU_AFFINITY_MASK_FILE_PATH = "ContainerCpuAffinityMaskFile.txt";
    public const int DEFAULT_MEMORY_PROBE_SLEEP_INTERVAL_IN_MS = 15000;

    // Constants for test specific
    public const string NM_PROCESS_NAME = "java.exe";
    public const string NM_PROCESS_USERNAME = "YarnppNMUser";
    public const string CONTAINER_ID = "CONTAINER_ID";
    public const string RM_STATE_XPATH = "clusterInfo/state";
    public const string RM_STATE_STARTED = "STARTED";
    // Constants for CosmosSandboxUser File Access Management
    public const string D_DATA_PATH = "D:\\Data";
    public const string COSMOS_SANDBOX_USER_GROUP = "CosmosSandboxUserGroup";
    public const string TASK_CONFIGURATION_DIRECTORY = "D:\\Data\\yarnlocalwatchdog\\AccessRestrictionBackgroundTaskConfiguration";
    public const string TASK_STATE_DIRECTORY = "D:\\Data\\yarnlocalwatchdog\\taskstate";
    public const string LOCAL_MACHINE = "WinNT://{0},Computer";
    public const string LOCAL_GROUP_CREATION_TIME = "LocalGroupCreationTimeinJSON.txt";
    public const string LOCAL_GROUP_CREATION_TIME_TASK_NAME = "LocalGroupCreationTimeinJSON";
    public const string RESTRICT_FSACCESS_CONFIG_FILE = "RestrictFSAccessConfig.txt";
    public const string RESTRICT_REGACCESS_CONFIG_FILE = "RestrictRegistryAccessConfig.txt";
    public const string BASIC_SETUP_DONE = "BasicSetupDone.Flag";
    public const uint FILE_READ_EA = 0x0008;
    public const uint FILE_FLAG_BACKUP_SEMANTICS = 0x2000000;
    public const string MDM_DIMENSIONS_KEY_PREFIX = "AdditionalMdmDimensions_";
    public const string GENEVA_METRIC_NAME = "RestrictFSAccess_TimeTaken";

    // Constants for dropped connections background task
    public const string DROPPED_CONNECTIONS_PROPERTY_NAME = "DroppedConnectionsByYarnLocalWatchDog";

    // Constants for YarnPP D Drive Analysis
    public const string YARNPP_D_DRIVE_USAGE = "YPP D:\\ Usage {folder:sizeInMB (% occupied on D Drive)}";

    // Constants for setup firewall for group background task
    public const string InfraAgentFilePath = "D:\\data\\YarnppInfraAgent\\GlobalYarnppMachineList.csv";

    // Constants for Platform Service List Watchdog property
    public const string PLATFORM_SERVICE_LIST_PROPERTY = "PlatformServiceList";
    public const string SERVICE_STATUS_FILE_PATH = "D:\\data\\servicemanager\\servicestatus.csv";
}
