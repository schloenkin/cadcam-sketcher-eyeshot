\# CAD/CAM Sketcher Prototype



This project is a C# WinForms prototype for creating custom 3D geometry based on 2D sketching workflows.



\## Features



\- Point creation and editing

\- Contour creation from points

\- Region creation from closed contours

\- Region boolean operations:

&#x20; - Union

&#x20; - Intersection

&#x20; - Difference

\- 3D geometry generation:

&#x20; - Extrusion

&#x20; - Revolve

&#x20; - Loft

\- STL export

\- Layer-based scene organization in Eyeshot



\## Technologies



\- C#

\- .NET Framework 4.8

\- Windows Forms

\- devDept Eyeshot

\- Visual Studio 2022



\## Architecture



The project separates geometry logic from scene and UI logic.



\- `SketcherHelper` stores and processes points, contours and regions.

\- `Form1` handles user interaction, Eyeshot viewport events, layer assignment, entity display and scene updates.



\## License Notice



This repository does not include commercial Eyeshot binaries, license files or license keys.  

A valid local Eyeshot installation/license is required to build and run the project.

