# Walkin
Walkin (read Walk in) is a 3D visualization tool that helps the user in visualizing the shortest path he/she needs to walk through to reach from one point in a building to the other. The tool works perfectly for any 3D model of a building imported with a few well defined tweaking. It has been developed using Unity Game Engine.

The Project Folder is present in the repository and all the basic files can be checked here for reference. Unitypackage for the project can be used to extend the work.

## Uploading a building's model
Walkin needs the 3D objects to be uploaded to be in the form of AssetBundles. Import the unitypackage and have a look at the example building used (IFMR Building). You can develop the building's model using Unity as well as the traditional 3D modelling engines. Import it to Unity and add dummy gameobjects (with colliders but mesh renderers turned off) at all those places that can be used as "Points of Interests" and "Hidden Interests". 'Points of Interests' are the doors of rooms in the building that a user can go to and 'Hidden interests' are locations where a diversion can be taken in the building but user isn't likely to go there. Add tag "PI" to it if it is a point of interest and "HI" if it is a hidden interest. Make an AssetBundle of it and you can use it now!

## Demonstration
Check demonstration.mp4 to watch the demo.