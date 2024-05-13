## This is a demo script for Azure PowerShell
## Run the comments in the inline chat

# this code gets a list of all the files in the current directory
# and then uploads them to an azure storage
# into a container called "myfiles"

# Import the Azure PowerShell module
Import-Module Az.Storage

# Set the storage account name and key
$storageAccountName = "your_storage_account_name"
$storageAccountKey = "your_storage_account_key"

# Set the container name
$containerName = "myfiles"

# Get the list of files in the current directory
$files = Get-ChildItem -File

# Create a new storage context
$context = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey $storageAccountKey

# Upload each file to the storage container
foreach ($file in $files) {
    $blobName = $file.Name
    $filePath = $file.FullName
    Set-AzStorageBlobContent -Context $context -Container $containerName -File $filePath -Blob $blobName
}