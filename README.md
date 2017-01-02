# Moon Defender Sharp

This is an attempt at porting Moon Defender to C#. I've been creating this using MonoDevelop and the Winforms library. All of the drawing should be done with the `System.Drawing` API. This is very much a work in progress and hasn't ported the entirety.

# Major goals
- any visuals or sounds should be rolled into the binary as resources
- Entity calculations should be multi-threaded to allow better use of available system resources.
- Be able to run the same binary in both Windows and Linux or at least be able to easily recompile between the platforms

