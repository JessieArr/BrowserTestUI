$dir = $PSScriptRoot

dotnet publish -c Release -f netcoreapp3.0 --runtime osx.10.11-x64 --self-contained true
dotnet publish -c Release -f netcoreapp3.0 --runtime win-x64 --self-contained true
dotnet publish -c Release -f netcoreapp3.0 --runtime linux-x64 --self-contained true

$osxPublishDirectory = $dir + "\BrowserTestUI\bin\Release\netcoreapp3.0\osx.10.11-x64\publish\"
$osxOutputFile = $dir + "\BrowserTestUI\bin\osx.10.11-x64.zip"
$windowsPublishDirectory = $dir + "\BrowserTestUI\bin\Release\netcoreapp3.0\win-x64\publish\"
$windowsOutputFile = $dir + "\BrowserTestUI\bin\win-x64.zip"
$linuxPublishDirectory = $dir + "\BrowserTestUI\bin\Release\netcoreapp3.0\linux-x64\publish\"
$linuxOutputFile = $dir + "\BrowserTestUI\bin\linux-x64.zip"

if (Test-Path $osxOutputFile) 
{
  Remove-Item $osxOutputFile
}
if (Test-Path $windowsOutputFile) 
{
  Remove-Item $windowsOutputFile
}
if (Test-Path $linuxOutputFile) 
{
  Remove-Item $linuxOutputFile
}

Add-Type -AssemblyName System.IO.Compression.FileSystem 
$compressionLevel = [System.IO.Compression.CompressionLevel]::Optimal;
[System.IO.Compression.ZipFile]::CreateFromDirectory($osxPublishDirectory, $osxOutputFile, $compressionLevel, $false)
[System.IO.Compression.ZipFile]::CreateFromDirectory($windowsPublishDirectory, $windowsOutputFile, $compressionLevel, $false)
[System.IO.Compression.ZipFile]::CreateFromDirectory($linuxPublishDirectory, $linuxOutputFile, $compressionLevel, $false)