# .shell -ci "!name2ee * System.Threading.Thread.Abort" powershell.exe -File C:\Scripts\YourScript.ps1

# Read the input from the pipeline
$inputText = $input | Out-String

# Split the input into lines
$lines = $inputText -split "`n"

# Loop through each line
for ($i = 0; $i -lt $lines.Length; $i++) {
    # Check if the line contains 'JITTED Code Address:' and it is not '(null)'
    if ($lines[$i] -match 'JITTED Code Address:' -and ($lines[$i] -split 'JITTED Code Address:')[1].Trim() -ne '(null)') {
        # Print the current line and the previous 5 lines
        for ($j = [Math]::Max(0, $i - 5); $j -le $i; $j++) {
            Write-Output $lines[$j]
        }
    }
}