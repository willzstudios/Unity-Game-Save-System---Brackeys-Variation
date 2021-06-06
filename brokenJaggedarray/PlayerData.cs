using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //saveable in a file
//this is the thing that will be serialized and saved into a binary file
public class PlayerData //not deriving from Monobehaviour
{//I think you can't change Vector2[][] tp binary lol not sure.

    //how do i create an array of Vector2 arrays
    public float[] XYcoordinates;
    public int[] sizeoflines; //size of this array = number of lines, values in this array = size of each line
    
    //this is a constructor class and will automatically be invoked when an instance of this class is created
    //automatically invoked because our class has the same name as the method (PlayerData)
    public PlayerData () //why don't i need a "void" here
    {
        GameObject[] lines = ReturnLineinfo(); //so this line works fine.
        sizeoflines = new int[lines.Length];

        Vector2[][] arrayofLinesV2 = new Vector2[lines.Length][]; //that's how you initialise the number of vector2 arrays in our array of vector2 arrays.

        int coordinatesize = 0;

        Debug.Log($"arrayofLinesV2.length = {arrayofLinesV2.Length}");
        for (int i = 0; i < lines.Length; i++)
        {
            //Debug.Log($"{lines[i].GetComponent<EdgeCollider2D>().points.Length}"); so that works which means i can't fill it? oHH NEW
            //arrayofLinesV2[i] = lines[i].GetComponent<EdgeCollider2D>().points; //error: Object Reference not set to an instance of an object?

            arrayofLinesV2[i] = new Vector2[lines[i].GetComponent<EdgeCollider2D>().points.Length]; //sweet this code now works!
            Debug.Log($"arrayofLinesV2[{i}].length = {arrayofLinesV2[i].Length}");
            sizeoflines[i] = arrayofLinesV2[i].Length;
            
            arrayofLinesV2[i] = lines[i].GetComponent<EdgeCollider2D>().points;

            coordinatesize += arrayofLinesV2[i].Length;
        }
        Debug.Log($"coordinatesize = {coordinatesize}");
        int count = 0;
        XYcoordinates = new float[coordinatesize*2]; //*2 because one Vector2 element = 2 float elements.
        for (int i = 0; i < sizeoflines.Length; i++) //for each line
        {
            //each line
            for (int x = 0; x < sizeoflines[i]*2; x += 2) //for each coordinate within the line //outside the bounds of teh array?
            {
                XYcoordinates[count] = arrayofLinesV2[i][x/2].x;
                Debug.Log($"XYcoordinates[{count}] = {arrayofLinesV2[i][x / 2]}");
                count += 1;
                XYcoordinates[count] = arrayofLinesV2[i][x/2].y;   //if you increment by 2 you have to divide by two as well dumbass
                //Debug.Log($"XYcoordinates[{count}] = {arrayofLinesV2[i][x / 2]}");
                count += 1;
            }
        }
        //foreach (var x in XYcoordinates) Debug.Log(x.ToString()); //ok from this we figured out the float array is working as intended.

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
