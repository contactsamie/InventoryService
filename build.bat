@echo off
cls
.paket\paket.exe install
packages\FAKE\tools\Fake.exe build-server.fsx buildType=%1 nugetDeployPath=%2
packages\FAKE\tools\Fake.exe build-service.fsx buildType=%1 nugetDeployPath=%2
packages\FAKE\tools\Fake.exe build-server-ui.fsx buildType=%1 nugetDeployPath=%2
pause