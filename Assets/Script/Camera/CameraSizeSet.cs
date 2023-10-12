using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeSet : MonoBehaviour
{
    public float cameraSize;
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        if (mainCamera == null)
            Debug.Log("카메라 널!! :( ");

        mainCamera.orthographicSize = cameraSize;
    }

    
}
