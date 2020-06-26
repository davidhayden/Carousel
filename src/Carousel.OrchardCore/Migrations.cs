#pragma warning disable 612, 618

using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Flows.Models;

namespace Carousel.OrchardCore {
    public class Migrations : DataMigration {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager) {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create() {
            _contentDefinitionManager.AlterPartDefinition("Slide", cfg => cfg
                .WithDescription("Contains the fields for the current type")
                .WithField("Caption",
                    fieldBuilder => fieldBuilder
                        .OfType("HtmlField")
                        .WithDisplayName("Caption")
                        .WithSetting("Editor", "Wysiwyg"))
                .WithField("DisplayCaption",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Display Caption")
                        .WithSetting("Label", "Display Caption")
                        .WithSetting("Editor", "Switch"))
                .WithField("Image",
                    fieldBuilder => fieldBuilder
                        .OfType("MediaField")
                        .WithDisplayName("Image")
                        .WithSetting("Required", "true")
                        .WithSetting("Multiple", "false"))
                .WithField("ImageClass",
                    fieldBuilder => fieldBuilder
                        .OfType("TextField")
                        .WithDisplayName("Image Class"))
                .WithField("ImageAltText",
                    fieldBuilder => fieldBuilder
                        .OfType("TextField")
                        .WithDisplayName("Image Alt Text"))
            );

            _contentDefinitionManager.AlterTypeDefinition("Slide", type => type
                .WithPart("Slide"));

            _contentDefinitionManager.AlterPartDefinition("Carousel", cfg => cfg
                .WithDescription("Contains the fields for the current type")
                .WithField("Interval",
                    fieldBuilder => fieldBuilder
                        .OfType("NumericField")
                        .WithDisplayName("Interval")
                        .WithSetting("Required", "true")
                        .WithSetting("DefaultValue", "5000")
                        .WithSetting("Hint", "Delay between slides (ms)"))
                .WithField("IncludeControls",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Include Controls")
                        .WithSetting("Label", "Include Controls")
                        .WithSetting("Editor", "Switch"))
                .WithField("IncludeIndicators",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Include Indicators")
                        .WithSetting("Label", "Include Indicators")
                        .WithSetting("Editor", "Switch"))
                .WithField("Ride",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Ride")
                        .WithSetting("Label", "Autoplay")
                        .WithSetting("Editor", "Switch"))
                .WithField("Wrap",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Wrap")
                        .WithSetting("Label", "Continuous")
                        .WithSetting("Editor", "Switch"))
                .WithField("Keyboard",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Keyboard")
                        .WithSetting("Label", "React to keyboard")
                        .WithSetting("Editor", "Switch"))
                .WithField("Pause",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Pause")
                        .WithSetting("Label", "Pause on hover/touch")
                        .WithSetting("Editor", "Switch"))
            );

            _contentDefinitionManager.AlterTypeDefinition("Carousel", type => type
                .WithPart("Carousel")
                .WithPart("Slides", "BagPart", cfg => cfg
                    .WithDisplayName("Slides")
                    .WithDescription("Slides to display in the carousel.")
                    .WithSettings(new BagPartSettings { ContainedContentTypes = new[] { "Slide" }, DisplayType = "Detail" }))
                .Stereotype("Widget"));

            return 1;
        }
    }
}