# Carousel

Carousel.OrchardCore is an Orchard Core CMS Module that creates a Boostrap 4 Carousel Widget.

## Status

[![Build status](https://ci.appveyor.com/api/projects/status/37sx3os9h1x2vxuq?svg=true)](https://ci.appveyor.com/project/davidhayden/carousel) [![Status](https://img.shields.io/myget/davidhayden-ci/v/Carousel.OrchardCore.svg)](https://www.myget.org/feed/davidhayden-ci/package/nuget/Carousel.OrchardCore)

## Getting Started

The module expects Bootstrap 4 to be used by the Orchard Core CMS website. The module does not come with Bootstrap 4 CSS and JS. Make sure your theme includes the necessary assets for the Carousel to look and work properly.

Add the NuGet package, **Carousel.OrchardCore**, to the Orchard Core CMS Website. Launch the website and sign in as an administrator to enable the module from the dashboard under <i>Configuration</i> -> <i>Modules</i>.

![Carousel.OrchardCore](https://github.com/davidhayden/Carousel/blob/master/assets/module.png?raw=true)

Create a <em>Carousel Widget</em> in a Layer or as part of a Content Item that supports Flow. The editor provides access to all of the current Carousel settings as well as the ability to add slides.

![Carousel.OrchardCore Widget Editor](https://github.com/davidhayden/Carousel/blob/master/assets/carousel-orchardcore-widget.png?raw=true)

After choosing the desired settings and adding the slides, navigate to the appropriate area of your website to view the carousel.

![Bootstrap 4 Carousel](https://github.com/davidhayden/Carousel/blob/master/assets/bootstrap-4-carousel.png?raw=true)

For more information on Bootstrap 4's Carousel, visit the [Bootstrap 4 documentation](https://getbootstrap.com).

## Customization

The Carousel Widget produces the suggested HTML mentioned in the Bootstrap documentation and allows one to create a Carousel with no knowledge of HTML.

You can, however, customize the HTML by modifying the liquid template that comes with the module, <em>Widget-Carousel.liquid</em>. You can modify the file itself or add the file as a template from the dashboard under <i>Configuration</i> -> <i>Templates</i>.

See the Orchard Core Documentation for more information on [Templates](https://orchardcore.readthedocs.io/en/latest/OrchardCore.Modules/OrchardCore.Templates/README/).

## Road map

There are no plans to add any additional features at this time.

## Credits
Carousel.OrchardCore is created and maintained by David Hayden.

[Bootstrap](https://getbootstrap.com) is a popular front-end component library.