using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorronSub : MonoBehaviour
{
    private void OnMouseDown()
    {
        Calculator temp = GameObject.Find("Calculator").GetComponent<Calculator>();
        temp.functionSub();
    }
}
