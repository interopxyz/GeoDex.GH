# GeoDex.GH
A Grasshopper 3d implementation of the GeoDex plotting library and plugin for Robert McNeel and Associate's Grasshopper 3d.

Grasshopper users can download the plugin at: https://www.food4rhino.com/app/geodex

## README
GeoDex GH is the [Grasshopper 3D](https://www.grasshopper3d.com/) implementation of the [GeoDex Library](https://github.com/interopxyz/GeoDex) a collection of around 150 curve, surface, and volume equations.  These equations consist of a mix of Polar, Cartesian, and Parameteric equations depending on which was either available for the given type or produced the most controllable results when plotted in Rhino. The components are added to the Vectors tab in the Grasshopper ribbon under the Plots category.

![Components](https://github.com/interopxyz/GeoDex.GH/blob/master/Assets/Geodex-Ribbon.jpg)

Each component has right-click option to select curve or surface equations in the given categories. Depending on the equation selected, the component inputs may reconfigure to provide additional parameters. This may sometimes result in the removal of a previous input if the subsequent curve has fewer parameters.

![Dropdown](https://github.com/interopxyz/GeoDex.GH/blob/master/Assets/Geodex-Components.jpg)

Each component takes a consistent unitized input of a numeric T value for curves and point based UV value for surfaces and volumes returning the plotted point of the selected equation at the given parameter. 

This is the third public and first stable release of Geodex, a project started a decade ago. The [GeoDex Library](https://github.com/interopxyz/GeoDex) has no dependencies on Rhinoceros 3d or Grasshopper 3d and can be used in any compatible .net application.

### NOTE
*GeoDex is currently an alpha project and open source. Please report any issues or innacuracies and feel free to contribute to the project*



## Installation & Prerequisites
To use GeoDex GH you will need 
 - https://www.rhino3d.com/
 - https://www.grasshopper3d.com/   (now comes with Rhinoceros 6)


## References
Equations were sourced from

 - http://mathworld.wolfram.com/
 - https://www.mathcurve.com/
 - http://paulbourke.net/

