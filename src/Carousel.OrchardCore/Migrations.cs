using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.Flows.Models;
using OrchardCore.Media.Settings;

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
                        .WithEditor("Wysiwyg"))
                .WithField("DisplayCaption",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Display Caption"))
                .WithField("Image",
                    fieldBuilder => fieldBuilder
                        .OfType("MediaField")
                        .WithDisplayName("Image")
                        .WithSettings(new MediaFieldSettings { Required = true, Multiple = false}))
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
                        .WithSettings(new NumericFieldSettings { Required = true, DefaultValue = "5000", Hint = "Delay between slides (ms)" }))
                .WithField("IncludeControls",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Include Controls"))
                .WithField("IncludeIndicators",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Include Indicators"))
                .WithField("Ride",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Autoplay"))
                .WithField("Wrap",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Continuous"))
                .WithField("Keyboard",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("React to keyboard"))
                .WithField("Pause",
                    fieldBuilder => fieldBuilder
                        .OfType("BooleanField")
                        .WithDisplayName("Pause on hover/touch"))
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