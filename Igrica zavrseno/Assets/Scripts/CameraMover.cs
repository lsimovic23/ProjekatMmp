using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    
    public void moveCamera()
    {
        Calculator cal = GameObject.Find("Calculator").GetComponent<Calculator>();
        cal.cameraMove();
    }

}
