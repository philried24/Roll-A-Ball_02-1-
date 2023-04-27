using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMovement : MonoBehaviour
{

    bool isup = true;
    private Vector3 ychange;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(upNDown());
    }

    // Update is called once per frame
    IEnumerator upNDown()
    {
        
        ychange = new Vector3(0.0f, 0.005f, 0.0f);

        if (isup == true) //if it's going up
        {
            if (transform.position.y <= 0.8) //if it is below the highest point
            {
                //move up .05 units
                transform.position += ychange;
            }
            else //if it is above the highest point
            {
                yield return new WaitForSeconds(1);
                isup = false;
            }
        }
        else //if it's going down
        {
            if (transform.position.y >= -1.1) //if it is above the lowest point
            {
                //move down .05 units
                transform.position -= ychange;
            }
            else //if it is below the lowest point
            {
                yield return new WaitForSeconds(3);
                isup = true;
            }
        }
    }
}
