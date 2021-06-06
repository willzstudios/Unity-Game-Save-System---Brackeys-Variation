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
        //load the data
        PlayerData data = SaveSystem.LoadPlayer();
        //then do stuff with the data


        Vector2[][] arrayofLinesV2 = data.arrayofLinesV2;
        for (int i = 0; i < arrayofLinesV2.Length; i++)
        {
            GameObject currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
            LineRenderer lineRenderer = currentLine.GetComponent<LineRenderer>();
            EdgeCollider2D edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
            lineRenderer.SetPositions(V2ArraytoV3(arrayofLinesV2[i])); //why can't i convert V2array to V3 array implicitly
            edgeCollider.points = arrayofLinesV2[i];
        }
       
    }

    public Vector3[] V2ArraytoV3(Vector2[] V2arrayInput)
    {
        for (int i = 0; i < V2arrayInput.Length; i++)
        {
            outputV3[i] = new Vector3(V2arrayInput[i].x, V2arrayInput[i].y);
        }
        return outputV3;
    }


}
