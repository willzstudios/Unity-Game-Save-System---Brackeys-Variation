using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject linePrefab;
    public Vector3[] outputV3;
    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer();
    }
    public void LoadPlayer()
    {
        //also need to reset scene here i think.

        //load the data
        PlayerData data = SaveSystem.LoadPlayer();
        Debug.Log("DATA LOADED!");
        //then do stuff with the data

        //ok how do we use
        //data.XYcoordinates and data.sizeoflines

        //just by using the XYcoordinates float[] and sizeoflines int[]

        //ok it works for 1 line now but how do we make it load for X lines? more than 1?
        //it seems like lines are separate but overlapping each other right now.
        int count = 0;
        for (int i = 0; i < data.sizeoflines.Length; i++) //for each line //once i goes to 1 what do we do
        {
            GameObject currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
            LineRenderer lineRenderer = currentLine.GetComponent<LineRenderer>();
            EdgeCollider2D edgeCollider = currentLine.GetComponent<EdgeCollider2D>();

            float[] tempFloatarray = new float[data.sizeoflines[i]*2]; //new float array will have twice the amount of elements from sizeoflines[i], 2 floats per Vector2 element

            int lastcount = count;
            for (int x = 0 + lastcount; x < data.sizeoflines[i]*2 + lastcount; x++) 
            {
                tempFloatarray[x-lastcount] = data.XYcoordinates[x];
                count += 1;
            }

            Vector2[] tempV2array = floatArraytoV2array(tempFloatarray); 
            Vector3[] tempv3array = V2ArraytoV3(tempV2array);
            lineRenderer.positionCount = tempv3array.Length; //this line is important haha.
            lineRenderer.SetPositions(tempv3array); 
            edgeCollider.points = tempV2array; //this works

            //foreach (var x in tempv3array) Debug.Log(x.ToString());
        }     
    }
    public Vector2[] floatArraytoV2array(float[] floatarrayinput) //function that changes a given float[] to a Vector2[] /this is working
    {
        Vector2[] output = new Vector2[floatarrayinput.Length/2];
        
        for (int i = 0; i < floatarrayinput.Length; i+=2) //then length has to multiplied if you're incrementing by 2.
        {
            output[i/2] = new Vector2(floatarrayinput[i], floatarrayinput[i+1]); //error here//index went out of bounds of array
        }

        return output;
    }
    public Vector3[] V2ArraytoV3(Vector2[] V2arrayInput) //function that changes a given Vector2[] to a Vector3[]
    {
        Vector3[] outputV3 = new Vector3[V2arrayInput.Length];
        
        for (int i = 0; i < V2arrayInput.Length; i++)
        {
            outputV3[i] = new Vector3 (V2arrayInput[i].x, V2arrayInput[i].y,0);
        }
        return outputV3;
    }
}
