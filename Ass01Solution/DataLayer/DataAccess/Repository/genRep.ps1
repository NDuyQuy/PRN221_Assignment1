param (
    [string]$EntityName
)

if (-not $EntityName) {
    Write-Host "Usage: .\create_repo.ps1 <EntityName>"
    exit
}

$CurrentDir = $PWD.Path
$EntityBoNamespace = "BussinessObject"

# Create the IRepo file (interface)
$IRepoFile = "$CurrentDir\I$EntityName`Repository.cs"
@"
using $EntityBoNamespace;

namespace DataAccess.Repository
{
    internal interface I$EntityName`Repository
    {
        public IEnumerable<$EntityName> Get$EntityName`s();
        public $EntityName ? Get$EntityName(int id);
        public void Delete$EntityName(int id);
        public void Add$EntityName($EntityName $($EntityName.ToLower()));
        public void Update$EntityName($EntityName $($EntityName.ToLower()));
    }
}
"@ > $IRepoFile

# Create the Repo file (class)
$RepoFile = "$CurrentDir\$EntityName`Repository.cs"
@"
using $EntityBoNamespace;

namespace DataAccess.Repository
{
    internal class $EntityName`Repository : I$EntityName`Repository
    {
  
    }
}
"@ > $RepoFile

Write-Host "Created files:"
Write-Host $IRepoFile
Write-Host $RepoFile
