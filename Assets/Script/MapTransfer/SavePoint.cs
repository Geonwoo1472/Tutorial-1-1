using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public string regionName;

    private Transform playerTransform;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        gameManager = GameManager.instance;

        positionSetting();
    }

    
    private void positionSetting()
    {
        if(regionName == gameManager.currentMapName)
        {
            playerTransform.position = transform.position;
        }
    }

}
