using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "Carousel Widget",
    Author = "David Hayden",
    Website = "http://www.davidhayden.me",
    Version = "2.0.0",
    Description = "Adds a Bootstrap 4 Carousel Widget.",
    Dependencies = new[] {"OrchardCore.ContentFields", "OrchardCore.Widgets"},
    Category = "Content"
)]