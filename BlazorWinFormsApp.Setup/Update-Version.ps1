$msixPackages = Get-ChildItem -Path "*\*.msix"
$maxCreationTime = $null
$maxVersion = $null
$maxVersionPath = $null
foreach ($item in $msixPackages){
	$item.Name -match "\d+.\d+.\d+.\d+"
 	Write-Output $Matches[0] $item.CreationTime $item.FullName
	if($item.CreationTime -gt $maxCreationTime){
		$maxCreationTime=$item.CreationTime
		$maxVersion=$Matches[0]
		$maxVersionPath=$item.FullName.Replace("\","/")
	}
}

Write-Output $maxVersionPath

$appInstaller = Get-Item -Path "*.appinstaller"
[xml]$appInstallerContent=Get-Content $appInstaller[0]

$appInstallerContent.AppInstaller.Version=$maxVersion
$appInstallerContent.AppInstaller.MainPackage.Version=$maxVersion
$appInstallerContent.AppInstaller.MainPackage.Uri="file:///$maxVersionPath" 
$appInstallerContent.Save($appInstaller[0].FullName)