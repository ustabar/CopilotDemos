# Define the URL of the page
$url = "http://localhost/buggybits/ExceptionSimulator.aspx"

# Define the number of requests to send
$numberOfRequests = 100

# Define the maximum number of threads
$maxThreads = 10

# Create a runspace pool with the maximum number of threads
$runspacePool = [RunspaceFactory]::CreateRunspacePool(1, $maxThreads)
$runspacePool.Open()

# Create an array to hold the PowerShell instances
$powerShellInstances = @()

# Send the requests in a loop
for ($i = 0; $i -lt $numberOfRequests; $i++) {
    # Create a new PowerShell instance and add it to the array
    $powerShell = [PowerShell]::Create()
    $powerShell.RunspacePool = $runspacePool
    $powerShell.AddScript({
        param($url)

        # Send a GET request to the page
        $response = Invoke-WebRequest -Uri $url -Method Get

        # Optional: Print the status code of the response
        "Response status code: $($response.StatusCode)"
    }).AddArgument($url)

    $powerShellInstances += New-Object PSObject -Property @{
        Instance = $powerShell
        Handle = $powerShell.BeginInvoke()
    }
}

# Wait for all PowerShell instances to complete
$powerShellInstances | ForEach-Object {
    $_.Instance.EndInvoke($_.Handle)
    $_.Instance.Dispose()
}

# Close the runspace pool
$runspacePool.Close()
$runspacePool.Dispose()