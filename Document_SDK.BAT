@echo off
set "target=DocumentSDK"

if not exist "%target%" (
    mkdir "%target%"
)

xcopy "common" "%target%\common\" /s /e /y
xcopy "docio" "%target%\docio\" /s /e /y
xcopy "pdf" "%target%\pdf\" /s /e /y
xcopy "presentation" "%target%\presentation\" /s /e /y
xcopy "resources" "%target%\resources\" /s /e /y
xcopy "samplebrowser" "%target%\samplebrowser\" /s /e /y
xcopy "showcase\Invoice" "%target%\showcase\Invoice\" /s /e /y
xcopy "showcase\PowerPoint Viewer" "%target%\showcase\PowerPoint Viewer\" /s /e /y
xcopy "targets" "%target%\targets\" /s /e /y
xcopy "xlsio" "%target%\xlsio\" /s /e /y

copy "Assemblies.xml" "%target%\" /y
copy "Directory.Build.props" "%target%\" /y
copy "Document_SDK.BAT" "%target%\" /y
copy "SyncfusionLicense.txt" "%target%\" /y

echo All folders and files copied to "%target%" successfully.

set "base=DocumentSDK"

del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf.sln"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_47.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_47.sln"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_excelsdk.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_excelsdk.sln"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_fileformat_47.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_fileformat_47.sln"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_pdfviewersdk.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_pdfviewersdk.sln"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_pdfviewersdk_47.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_pdfviewersdk_47.sln"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_docxeditorsdk.sln"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_docxeditorsdk.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_store_47.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_test.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_test.sln"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_wordeditorsdk.csproj"
del /q "%base%\samplebrowser\syncfusion.samplebrowser.wpf_wordeditorsdk.sln"
del /q "%base%\samplebrowser\wpf-excel-sdk-splash-screen.png"
del /q "%base%\samplebrowser\wpf-wordeditor-sdk-splash-screen.png"
del /q "%base%\samplebrowser\PDFViewerSDK-splash-screen.png"
del /q "%base%\samplebrowser\wpf-docxeditor-sdk-splash-screen.png"
del /q "%base%\targets\Pdfviewersdk.targets"
del /q "%base%\targets\Wordeditorsdk.targets"

rmdir /s /q "%base%/common\Assets\Gadgets"
rmdir /s /q "%base%/common\Assets\Movie"
echo Folder deleted successfully.
echo Folder cleanup inside "%base%" completed.
