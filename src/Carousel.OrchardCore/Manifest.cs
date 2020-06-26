using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Carousel Widget",
    Author = "David Hayden",
    Website = "https://www.davidhayden.me",
    Version = "1.0.0-rc2",
    Description = "Adds a Bootstrap 4 Carousel Widget.",
    Dependencies = new[] {"OrchardCore.ContentFields", "OrchardCore.Flows", "OrchardCore.Widgets"},
    Category = "Content"
)]