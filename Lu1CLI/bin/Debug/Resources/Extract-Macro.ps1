[CmdletBinding()]
Param (
  [Parameter(Mandatory=$True)]
  [string]$file,

  [Parameter(Mandatory=$False)]
  [int]$fp=0
)

# Heavily edited from https://github.com/enigma0x3/Generate-Macro/blob/master/Generate-Macro.ps1

function Word {
    
    Try{
        
        #Create Word document
        $Word = New-Object -ComObject "Word.Application"
        $WordVersion = $Word.Version
		$Word.Visible = $False 
		$Word.DisplayAlerts = "wdAlertsNone"
		$word.AutomationSecurity = "msoAutomationSecurityForceDisable"
        
        #Disable Macro Security
        New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$WordVersion\Word\Security" -Name AccessVBOM -PropertyType DWORD -Value 1 -Force | Out-Null
        New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$WordVersion\Word\Security" -Name VBAWarnings -PropertyType DWORD -Value 1 -Force | Out-Null

        $Document = $Word.Documents.OpenNoRepairDialog($file,$False,$True,$null,"","",$false,"","","WdOpenFormat","",$false)
        $xlModule = $Document.VBProject.VBComponents

        foreach($module in $xlModule){
            $line = $module.CodeModule.CountOfLines
                if($line -gt 0){
                    $code = $module.CodeModule.Lines(1, $line)
                    Write-Host "======== Macro Code Start ============" -foregroundcolor "green"
                    $code 
                    Write-Host "======== Macro Code End ============" -foregroundcolor "green"
                }
        }  
        #Cleanup
        #$Word.Documents.Close()
        $Word.Quit()
        [System.Runtime.Interopservices.Marshal]::ReleaseComObject($Word) | out-null
        $Word = $Null
        if (Get-Process WINWORD){Stop-Process -name WINWORD}
    }
    Catch
    {
        $ErrorMessage = $_.Exception.Message
        $ErrorMessage
        $FailedItem = $_.Exception.ItemName
        $FailedItem
    }

    #Enable Macro Security
    New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$WordVersion\Word\Security" -Name AccessVBOM -PropertyType DWORD -Value 0 -Force | Out-Null
    New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$WordVersion\Word\Security" -Name VBAWarnings -PropertyType DWORD -Value 0 -Force | Out-Null
}

function Excel{

    Try{    

        #Create excel document
        $Excel = New-Object -ComObject "Excel.Application"
        $ExcelVersion = $Excel.Version
        $Excel.Visible = $False 
        $Excel.DisplayAlerts = "wdAlertsNone"

        #Disable Macro Security
        New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$ExcelVersion\Excel\Security" -Name AccessVBOM -PropertyType DWORD -Value 1 -Force | Out-Null
        New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$ExcelVersion\Excel\Security" -Name VBAWarnings -PropertyType DWORD -Value 1 -Force | Out-Null


        $Workbook = $Excel.Workbooks.open($file,$true)
        $xlModule = $Workbook.VBProject.VBComponents
        foreach($module in $xlModule){
            $line = $module.CodeModule.CountOfLines
                if($line -gt 0){
                    $code = $module.CodeModule.Lines(1, $line)
                    Write-Host "======== Macro Code Start ============" -foregroundcolor "green"
                    $code 
                    Write-Host "======== Macro Code End ============" -foregroundcolor "green"

                }
        }
    
        #Cleanup
        $Excel.Workbooks.Close()
        $Excel.Quit()
        [System.Runtime.Interopservices.Marshal]::ReleaseComObject($Excel) | out-null
        $Excel = $Null
        if (Get-Process excel){Stop-Process -name excel}
    }

    Catch
    {
        $ErrorMessage = $_.Exception.Message
        $ErrorMessage
        $FailedItem = $_.Exception.ItemName
        $FailedItem
    }

    #Enable Macro Security
    New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$ExcelVersion\Excel\Security" -Name AccessVBOM -PropertyType DWORD -Value 0 -Force | Out-Null
    New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$ExcelVersion\Excel\Security" -Name VBAWarnings -PropertyType DWORD -Value 0 -Force | Out-Null
}
function PowerPoint{

    Try{    
        $msoFalse  = [Microsoft.Office.Core.MsoTristate]::msoFalse
        #Create excel document
        $ppt = New-Object -ComObject "powerpoint.Application"
        $pptVersion = $ppt.Version
        #$ppt.Visible = $msoFalse
        #$ppt.DisplayAlerts = "wdAlertsNone"

        #Disable Macro Security
        New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$pptVersion\PowerPoint\Security" -Name AccessVBOM -PropertyType DWORD -Value 1 -Force | Out-Null
        New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$pptVersion\PowerPoint\Security" -Name VBAWarnings -PropertyType DWORD -Value 1 -Force | Out-Null


        $Workbook = $ppt.presentations.Open($file,$msoFalse, $msoFalse, $msoFalse)
        $xlModule = $Workbook.VBProject.VBComponents
        foreach($module in $xlModule){
            $line = $module.CodeModule.CountOfLines
                if($line -gt 0){
                    $code = $module.CodeModule.Lines(1, $line)
                    Write-Host "======== Macro Code Start ============" -foregroundcolor "green"
                    $code 
                    Write-Host "======== Macro Code End ============" -foregroundcolor "green"
                }
        }

        #Cleanup
        $Workbook.Close()
        $ppt.Quit()
        Write-Host "======== xxx ============" -foregroundcolor "green"
        [System.Runtime.Interopservices.Marshal]::ReleaseComObject($ppt) | out-null
        $ppt = $Null
        if (Get-Process POWERPNT){Stop-Process -name POWERPNT}
    }

    Catch
    {
        $ErrorMessage = $_.Exception.Message
        $ErrorMessage
        $FailedItem = $_.Exception.ItemName
        $FailedItem
    }

    #Enable Macro Security
    New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$pptVersion\PowerPoint\Security" -Name AccessVBOM -PropertyType DWORD -Value 0 -Force | Out-Null
    New-ItemProperty -Path "HKCU:\Software\Microsoft\Office\$pptVersion\PowerPoint\Security" -Name VBAWarnings -PropertyType DWORD -Value 0 -Force | Out-Null
}

$extn = [IO.Path]::GetExtension($file)
if (($extn -eq ".doc") -or ($extn -eq ".docm"))
{
    Word
}
elseif(($extn -eq ".docx"))
{
    DDECheck
}
elseif(($extn -eq ".xls") -or ($extn -eq ".xlsm"))
{
    Excel
}
elseif (($extn -eq ".ppt") -or ($extn -eq ".pptm")) {
    PowerPoint
}
else {
    Write-Host "Currently cannot check for this filetype..." -foregroundcolor "red"
    exit
}

