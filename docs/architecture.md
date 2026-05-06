\# Architecture



\## Overview



This project is a C# WinForms CAD/CAM sketcher prototype built with devDept Eyeshot.



The application supports a 2D sketching workflow for creating points, contours and regions. These 2D elements can then be used to generate 3D geometry such as extrusions, revolved bodies, lofted surfaces and swept geometry.



The architecture follows a practical separation between:



\- UI and scene-management logic

\- geometry and sketch-processing logic



\## Main Components



\### Form1



`Form1` is the central WinForms class and acts as the coordination layer between the user interface, the Eyeshot viewport and the geometry logic.



Main responsibilities:



\- handle button click events

\- manage the current operation mode

\- process mouse interaction in the viewport

\- convert screen coordinates into 3D points

\- add and remove Eyeshot entities from the model

\- assign colors, line weights and layers

\- update labels and auxiliary visual elements

\- refresh the scene after geometry changes



\### SketcherHelper



`SketcherHelper` contains the sketch-related geometry logic.



Main responsibilities:



\- store points in `List<Point3D>`

\- store contours in `List<ICurve>`

\- store regions in `List<Region>`

\- create auxiliary lines between points

\- create point labels

\- close open contours

\- create regions from contours

\- detect regions from multiple contours

\- perform boolean region operations:

&#x20; - union

&#x20; - intersection

&#x20; - difference



\## Scene Structure



The Eyeshot `Model` control is used as the main 3D scene.



The scene contains:



\- layers

\- entities

\- labels

\- viewport and camera settings



Entities are assigned to layers such as:



\- `AuxiliaryLayer`

\- `ContourLayer`

\- `RegionLayer`

\- `DimLayer`

\- `MeshLayer`

\- `SplineLayer`



This makes it easier to organize, style, hide, remove or export specific types of objects.



\## Geometry Workflow



A typical workflow is:



1\. Create points in the viewport.

2\. Connect points with auxiliary lines.

3\. Build and close a contour.

4\. Save the contour as an Eyeshot curve.

5\. Convert closed contours into regions.

6\. Apply boolean operations to regions if needed.

7\. Generate 3D geometry:

&#x20;  - extrusion

&#x20;  - revolve

&#x20;  - loft

&#x20;  - sweep prototype

8\. Add the resulting geometry to the Eyeshot model.

9\. Export generated geometry as STL.



\## Notes



The project does not include commercial Eyeshot binaries, license files or license keys.



A valid local Eyeshot installation and license are required to build and run the project.

