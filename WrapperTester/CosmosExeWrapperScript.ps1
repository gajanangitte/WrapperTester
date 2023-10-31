# This is a wrapper script over cosmos.exe, 
# which can be automated using a c# file
# We can add more params in the future for newer ops
param (
	[Parameter(Mandatory)]
	[string]$op,
	[string]$sourceFilePath,
	[string]$destinationFilePath,
	[int]$maxRetries
)

Write-Output "[Operation]=$op"

########################################
# Define the powershell variables here #
########################################
$LASTEXITCODE = 0



########################################
# Define the cosmos.exe functions here #
########################################
function CosmosCopy {
	param (
		[string]$sourceFilePath,
		[string]$destinationFilePath,
		[int]$maxRetries
	)

	# Check that the params are not empty or null
	if (
		[string]::IsNullOrEmpty($sourceFilePath) -or
		[string]::IsNullOrEmpty($destinationFilePath)
	) {
		throw "For Copy Operation: One or more null or empty arguments passed. Path param cannot be null"
	}

	if (
		($maxRetries) -eq $null 
	) {
		$maxRetries = 3
	}
	
	Write-Host "CosmosCopy", $sourceFilePath, $destinationFilePath 
	&'.\cosmos.exe' 'copy' "--overwrite" "--retries" $maxRetries $sourceFilePath $destinationFilePath

	$LASTEXITCODE = 0
	Write-Output "LASTEXITCODE: $LASTEXITCODE"
	exit 0
}


# Check for the operation asked for and use a corresponding function
Switch ($op) {
	"copy" { 
		CosmosCopy -sourceFilePath $sourceFilePath -destinationFilePath $destinationFilePath -maxRetries $maxRetries
	}
	Default {
		throw "Invalid specified operation!"
	}
}