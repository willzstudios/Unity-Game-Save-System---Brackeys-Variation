# Brackey's Game Save System

**Description:**
https://www.youtube.com/watch?v=XOjd_qU2Ido&t=270s
- it's a simple save/load system for Unity using System.IO.FileStream and System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
- you can save class data types such as string, bool, float, int
- and you can load and set these

**Setup:**
- we've got 3 .cs script files
- SaveSystem, Player, and PlayerData
- SaveSystem.cs and PlayerData.cs are static classes and don't derive from Monobehaviour so they don't need to be attached to gameobject, just need to be within Assets folder
- Player.cs - has to be attached to a gameobject - you can attach it to a 3d cube, or square sprite for testing
- Create 2 UI buttons, one for Save, one for Load, and connect the OnClick() to your gameobject, referencing Player.SavePlayer(), and Player.LoadPlayer()

**Running:**
- hit play in Unity
- move your gameobject around somewhere through the editor's Scene window
- click save button (the transform.position of the gameobject is now saved)
- move your gameobject somewhere else through the editor
- click load button (your gameobject returns to the position from where it was saved)

**How does it work**?
- when you click the save button, the ui button calls Player.SavePlayer()
  -  SaveSystem.SavePlayer(this); //this is passed through as this script will be used as reference to find this.transform.position
- SavePlayer(Player player)
  -  creates an instance of BinaryFormatter
  -  we setup the string filepath for the save path including the save file name "saves"
  -  we use System.IO.FileStream to FileMode.Create the file according to the path (path contains path with filename)
    - PlayerData data = new PlayerData(player), creates a new copy of our serializable class PlayerData, passing through "player" our Player.cs monobehaviour class attached to the gameobject
      - when PlayerData is instantiated, since it has a "constructor"  (a method that is automatically invoked on class instantiation)
      - the constructor PlayerData(player player), creates a float array of size 3, and fills it with the Player.transform.position
      - the PlayerData data, now holds the public float[] position, with transform.position info
    - we then use BinaryFormatter.Serialize(stream, data), to serialize our "data (float array of size:3)" into the "stream" of bytes into the file "saves"

When Loading the data with SaveSystem.LoadPlayer()
- use FileStream to open the binary file as a "stream" of bytes from its path
  - once open, PlayerData data = BinaryFormatter.Deserialize(stream) as PlayerData; //deserializing the stream of bytes back into the format of PlayerData.cs
  - //basically the binary file "stream" of bytes is converted back to PlayerData.cs?
  - return data;



**Variations made from Brackeys video**
But the code has been fixed according to some of the commenters
- we're using: using(FielStream stream = new FileStream(path, FileMode.Open){}
- we using Path.Combine to combine paths safely for different Operating Systems
- don't know how to make helper method to convert from Vector3 to float array, or own struct
- didn't implement but you can use OnApplicationPause instead of OnApplicationQuit for mobile
- apparently there are safety issues if you're using BinaryFormatter to deserialize packs from online/somewhere else

