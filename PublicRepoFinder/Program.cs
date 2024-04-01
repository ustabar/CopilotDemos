using Octokit;
using System;

Console.WriteLine("Hello, World!");
 
var client = new GitHubClient(new ProductHeaderValue("PublicRepoFinder"))
{
    // replace "your_token" with your personal access token
    Credentials = new Credentials("") 
};

var publicRepositories = await client.Repository.GetAllPublic();
foreach (var repo in publicRepositories)
{
    Console.WriteLine(repo.FullName);
}
