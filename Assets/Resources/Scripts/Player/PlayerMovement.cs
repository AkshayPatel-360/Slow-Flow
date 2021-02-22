using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("on");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Off");
        }



        
    }

}
