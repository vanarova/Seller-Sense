# To run, open powershell ISE > go to path of this script and run > .\version.ps1 '1.0.3.0' '1.0.4.0' 'GUID' 
# .\version.ps1 '1.0.3.0' '1.0.4.0' 'GUID'  --> current version , new version, current guid
# For example::
#  .\version.ps1 '1.0.5.0' '1.0.6.0' 'F5F14482-948B-4D5D-8945-13A57AD487FF'
 
$pv = $args[0]
$v = $args[1]
$g = $args[2] 

Write-Host updating version from $pv
Write-Host updating version to $v
$gid = [guid]::NewGuid().ToString()
Write-Host updating guid to $gid

(Get-Content Properties\AssemblyInfo.cs).Replace($pv, $v) | Set-Content Properties\AssemblyInfo.cs
(Get-Content ..\WIXEditProj\SS.wxs).Replace($pv, $v) | Set-Content ..\WIXEditProj\SS.wxs
(Get-Content ..\WIXEditProj\SS.wxs).Replace('Product Id="' + $g + '"', 'Product Id="' + $gid + '"') | Set-Content ..\WIXEditProj\SS.wxs


#Product Id="F5F14482-948B-4D5D-8945-13A57AD487FF"
#[guid]::NewGuid().ToString()