using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //saveable in a file
//this is the thing that will be serialized and saved into a binary file
public class PlayerData //not deriving from Monobehaviour
{//I think you can't change Vector2[][] tp binary lol not sure.

    //how do i create an array of Vector2 arrays
    public Vector2[][] arrayofLinesV2; //you have to initialise it somehow to show number of arrays?
    
    //this is a constructor class and will automatically be invoked when an instance of this class is created
    //automatically invoked because our class has the same name as the method (PlayerData)
    public PlayerData () //why don't i need a "void" here
    {
        GameObject[] lines = ReturnLineinfo(); //so this line works fine.
        arrayofLinesV2 = new Vector2[lines.Length][]; //that's how you initialise the number of vector2 arrays in our array of vector2 arrays.
        Debug.Log($"arrayofLinesV2.length = {arrayofLinesV2.Length}");
        for (int i = 0; i < lines.Length; i++)
        {
            //Debug.Log($"{lines[i].GetComponent<EdgeCollider2D>().points.Length}"); so that works which means i can't fill it? oHH NEW
            //arrayofLinesV2[i] = lines[i].GetComponent<EdgeCollider2D>().points; //error: Object Reference not set to an instance of an object?

            arrayofLinesV2[i] = new Vector2[lines[i].GetComponent<EdgeCollider2D>().points.Length]; //sweet this code now works!
            Debug.Log($"arrayofLinesV2[{i}].length = {arrayofLinesV2[i].Length}");

        }
    }
    public GameObject[] ReturnLineinfo()
    {
        //feel like i need a if, else here, in case we can't find lineArray?
        GameObject[] lineArray = GameObject.FindGameObjectsWithTag("line"); //will this work if this is not in scene?

        if (lineArray != null)
        {
            return lineArray;
        }
        else
            return null;
    }
}
