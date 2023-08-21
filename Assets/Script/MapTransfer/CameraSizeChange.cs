using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeChange : MonoBehaviour
{
    public float cameraSize;

    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sizeChanging();
        }
    }


    public void sizeChanging()
    {
        camera.orthographicSize = cameraSize;
    }
}
