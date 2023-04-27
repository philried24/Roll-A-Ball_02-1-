using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMovement2 : MonoBehaviour
{
    //Variables
    bool isup = true;           //true if the obj is supposed to be moving up. false if moving down
    private Vector3 ychange;    //amount the obj moves each update
    private bool isMoving;      //true if the obj is in the middle of moving


    void Update()
    {
        if (isMoving == false)
        {
            StartCoroutine(upNDown());  //call function below
        }
        
    }


    private IEnumerator upNDown()
    {
        isMoving = true;
        ychange = new Vector3(0.0f, 0.05f, 0.0f);  //make a new vector3 that is up 0.005 units

        if (isup == true) //if it's going up
        {
            if (transform.position.y >= -8) //if it is above the highest point
            {
                yield return new WaitForSeconds(1); //wait for 1 second
                isup = false;                       //start moving down
                
            }
            else //if it is below the highest point
            {
                //move up .05 units
                transform.position += ychange;
            }
        }
        else //if it's going down
        {
            if (transform.position.y <= -19) //if it is below the lowest point
            {
                yield return new WaitForSeconds(3); //wait for 3 seconds
                isup = true;                        //start moving up
                
            }
            else //if it is below the lowest point
            {
                //move down .05 units
                transform.position -= ychange;
            }
        }
        isMoving = false;
    }
}
