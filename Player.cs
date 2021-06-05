using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //LOAD SAVE
    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this); //what's the point of passing "this" through to SavePlayer - it's used later to find this.transform.position
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
    
}
