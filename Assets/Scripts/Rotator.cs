using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    bool isup = true;
    private Vector3 ychange;
    //ychange = new Vector3(0.0f, 0.05f, 0.0f);

    // Update is called once per frame
    void Update()
    {

        //rotation
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);

        /*
        //rotation
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        //vertical
        ychange = new Vector3(0.0f, 0.0007f, 0.0f);

        if (isup == true) //if it's going up
        {
            if (transform.position.y <= 0.7) //if it is below the highest point
            {
                //move up .05 units
                transform.position += ychange;
            } 
            else //if it is above the highest point
            {
                isup = false;
            }
        }
        else //if it's going down
        {
            if (transform.position.y >= 0.3) //if it is above the lowest point
            {
                //move down .05 units
                transform.position -= ychange;          
            }
            else //if it is below the lowest point
            {
                isup = true;
            }
        }
        */
    }
}
