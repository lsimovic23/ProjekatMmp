using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonDiv : MonoBehaviour
{
    private void OnMouseDown()
    {
        Calculator temp = GameObject.Find("Calculator").GetComponent<Calculator>();
        temp.functionDiv();
    }
}
