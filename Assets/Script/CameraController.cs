using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera move info")]
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private float  speed ;
    [SerializeField] private float  distance ;

    [Header("Vector infos")]
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;


    private void Update()
    {
        if (Screen.width - Input.mousePosition.x <= distance && cameraPosition.position.x < maxPosition.x)
        {
            cameraPosition.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.mousePosition.x <= distance && cameraPosition.position.x > minPosition.x)
        {
            cameraPosition.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Screen.height - Input.mousePosition.y <= distance && cameraPosition.position.y < maxPosition.y)
        {
            cameraPosition.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.mousePosition.y <= distance && cameraPosition.position.y > minPosition.y)
        {
            cameraPosition.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }
}
