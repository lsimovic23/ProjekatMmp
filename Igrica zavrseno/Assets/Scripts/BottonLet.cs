using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonLet : MonoBehaviour
{
    private void OnMouseDown()
    {
        Calculator temp = GameObject.Find("Calculator").GetComponent<Calculator>();
        temp.functionLet();
    }
}
