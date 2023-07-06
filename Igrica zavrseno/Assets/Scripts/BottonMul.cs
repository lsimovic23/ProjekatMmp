using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonMul : MonoBehaviour
{
    private void OnMouseDown()
    {
        Calculator temp = GameObject.Find("Calculator").GetComponent<Calculator>();
        temp.functionMul();
    }
}
