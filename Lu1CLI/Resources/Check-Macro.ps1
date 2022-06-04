[CmdletBinding()]
Param (
  [Parameter(Mandatory=$True)]
  [string]$vba
)
function Detection {

    $keywords = @{     
    "schtasks"="1";   # tac vu da len lich
    "Document_Open"="2";  # chay khi mo Document
    "(?i:auto_open)"="3"; # 
    #"(?:[A-Za-z0-9+/]{4}){1,}(?:[A-Za-z0-9+/]{2}[AEIMQUYcgkosw048]=|[A-Za-z0-9+/][AQgw]==)?"="6";
    #"WinHttp"="7";
    "(WinHttp|XMLHTTP)"="4";  # http request
    "https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)"="5";
    "Shell"="6";  # nhiu ham chia nho
    "chr\(" = "7";  # char encoding
    "(?:[A-Za-z0-9+/]{4}){1,}(?:[A-Za-z0-9+/]{2}[AEIMQUYcgkosw048]=|[A-Za-z0-9+/][AQgw]==)"="8"; 
    '("(\s)*&(\s)*")'="9";
    "(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])"="10"
    }
    
    $tabName = "SampleTable"

    #Create Table object
    $table = New-Object system.Data.DataTable “$tabName”

    #Define Columns
    $col1 = New-Object system.Data.DataColumn Checks_for,([string])
    $col2 = New-Object system.Data.DataColumn Count,([string])

    #Add the Columns
    $table.columns.add($col1)
    $table.columns.add($col2)
    #$table.columns.add($col3)
    foreach($keyword in $keywords.Keys){
        
        $value = $keywords[$keyword]
        $Matches = Select-String -InputObject $vba -Pattern $keyword -AllMatches

        #Create a row
        $row = $table.NewRow()

        #Enter data in the row
        $row.Checks_for = $value
        $row.Count =   $Matches.Matches.Count 
        #$row.Instances =   $Matches 

        #Add the row to the table
        $table.Rows.Add($row)

    }
    
    Write-Host "======== Suspecious Macro Code Patterns ============" -foregroundcolor "green"

    $table | format-table #-AutoSize  

}

Detection

#[void][System.Console]::ReadKey($True)