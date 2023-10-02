using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapInteration : MonoBehaviour
{

    private Image mapImage;
    private GameManager gameManager;
    private bool panel_YN;
    private bool isActive;

    public bool Panel_YN
    {
        get { return panel_YN; }
        set { panel_YN = value; }
    }

    private void Awake()
    {
        mapImage = GetComponent<Image>();
        isActive = false;
    }

    void Start()
    {
        gameManager = GameManager.instance;
        gameManager.onInterationMap += MapPanelActive;

        NullChecking();
    }

    private void MapPanelActive()
    {
        if (!panel_YN)
            return;
        SoundManager.instance.SoundPlaying(SoundType.mapSound);
        isActive = !isActive;
        mapImage.enabled = isActive;
    }

    private void NullChecking()
    {
        if (gameManager == null)
            Debug.Log("MapInteration.cs , MapImage1 gameObject ");
    }
    
}
