using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CardDraggable : MonoBehaviour
{
    private void Update()
    {
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        Debug.Log(Input.mousePosition);

    }

    private void OnMouseUp()
    {
        Debug.Log(Input.mousePosition);


    }
}
