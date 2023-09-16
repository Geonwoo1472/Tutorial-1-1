using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCoordinate : MonoBehaviour
{
    [SerializeField]
    private int mapIndexNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CameraController cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
            if (cameraController != null)
            {
                cameraController.MapIndex = mapIndexNumber;
            }
        }
    }
}
