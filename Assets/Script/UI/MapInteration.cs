using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// #Usage(용도)#
/// Map Imgae UI에 알맞은 지도 이미지 데이터를 셋팅하고
/// 플레이어가 조작키로 해당 이미지UI를 활성/비활성할 수 있게 합니다.
/// 
/// #object used(부착 오브젝트)#
/// Map Item Image UI
/// 
/// #Method#
/// -private void MapPanelActive()
/// 게임매니저의 M호출시 델리게이트로 호출됨.
/// 판넬을 활성/비활성합니다.
/// 
/// </summary>
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
