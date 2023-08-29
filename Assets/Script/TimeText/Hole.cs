using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //new version URP

public class Hole : MonoBehaviour
{
    public float initTime;

    private TimeText timeText;
    private Light2D globalLight2D;
    private PlayerLight2DController playerLight2DController;

    private void Start()
    {
        timeText = GameObject.Find("TimeTextParent").transform.Find("TimeText").GetComponent<TimeText>();
        globalLight2D = GameObject.Find("BackGroundLight2D").GetComponent<Light2D>();
        playerLight2DController = PlayerLight2DController.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timeText.OnActive(initTime);
            globalLight2D.color = Color.black;
            playerLight2DController.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            timeText.OffActive();
            globalLight2D.color = Color.white;
            playerLight2DController.SetActive(false);
        }
    }
}
