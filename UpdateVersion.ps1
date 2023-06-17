
$pre_version = "1.0.2.0"
$new_version = "1.0.3.0"
$p = "Version " + $pre_version
$n = "Version " + $new_version

(Get-Content './SetupProjectInvUpdater/Product.wxs') -replace $pre_version,$new_version | Set-Content -Path './SetupProjectInvUpdater/Product.wxs'

(Get-Content './InventoryUpdater/Welcome.Designer.cs') -replace $p,$n | Set-Content -Path './InventoryUpdater/Welcome.Designer.cs'
