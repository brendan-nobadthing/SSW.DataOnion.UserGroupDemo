The following code files:

Generated/Configurations/DbContextConfigurations.ttinclude
DbContext.cs
DbContextFactory.cs
DropCreateInitializer.cs

need to be updated for the project to compile

1. Generated/Configurations/DbContextConfigurations.ttinclude

Update this file to generate DbContext database sets based on your domain model. You will need to have a reference 
to domain model project (if using a separate project) and project should be built (to make sure dll is copied 
to the bin folder). Ideally you would have the following class library project structure in your solution

-YourSolution
--YourNamespace.DomainModel
--YourNamespace.Data (current project)
--YourNamespace.WebUI

2. DbContext.cs

Update all references to "YourDbContext" and "YourConnectionStringName"