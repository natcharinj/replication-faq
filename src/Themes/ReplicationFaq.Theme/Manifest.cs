using OrchardCore.DisplayManagement.Manifest;

[assembly: Theme(
    Name = "ReplicationFaq.Theme",
    Author = "The Orchard Core Team",
    Website = "https://orchardcore.net",
    Version = "0.0.1",
    Description = "ReplicationFaq.Theme",
    Dependencies = new[]{
        // Required features 
        "OrchardCore.Media.Azure.Storage",
        "Codesanook.OrganizationProfile"
    }
)]
