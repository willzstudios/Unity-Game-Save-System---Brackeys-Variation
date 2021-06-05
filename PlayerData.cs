using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //saveable in a file
public class PlayerData //not deriving from Monobehaviour
{
    //public int level;
    //public int health;
    public float[] position;

    //creating a constructor for our class? //act as a set of functions for our class PlayerData
    //this method below will automatically be invoked when an instance of this class is created.
    public PlayerData (Player player) //takes data from "UIScript"
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }
}
