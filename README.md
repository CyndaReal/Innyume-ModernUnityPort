# Innyume-ModernUnityPort
 Decompilation and port of Innyume to modern Unity.
 Accurate in most ways (code is mostly untouched except for renaming some variables), but certain things that didn't work in modern Unity were changed (Player was changed from a Rigidbody to a CharacterController, etc), and optimizations like Occlusion Culling were added. Many movement and logic functions that weren't dependent on Innyume's bizarre frame-timing based programming were also moved from FixedUpdate to Update proper. The cursor is also now locked more properly.