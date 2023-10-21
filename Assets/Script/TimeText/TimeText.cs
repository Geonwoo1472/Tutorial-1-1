using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// #Usage(용도)#
/// 타이머 기능이 구현되어 있습니다.
/// 시간이 0이 되면 GameOver됩니다.
/// 
/// #object used(부착 오브젝트)#
/// TimeText,
/// TextMeshPro UI 
/// 
/// #Method#
/// -public void OnActive(float)
/// 시간초를 셋팅하고 플레이어 머리위로 이동합니다.
/// 게임오브젝트를 활성화 시켜 시간이 줄게합니다.
/// 
/// 
/// -public void OffActive()
/// 게임오브젝트를 비활성시키고 기능을 정지시킵니다.
/// 
/// 
/// </summary>
public class TimeText : MonoBehaviour
{
    public float timeLimit;


    private TextMeshPro textMeshPro;            // textMeshPro
    private string ms;
    private string s;
    private Transform playerPos;
    private RectTransform rectTransform;

    private GameObject statusUI;
    private DalogManager dalogManager;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        rectTransform = GetComponent<RectTransform>();
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        statusUI = GameObject.Find("HungerFatigueUI");
        timeLimit = 1.0f;
    }

    private void Start()
    {
        dalogManager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
    }

    /*만약 Panel이 활성화 되어 있는 경우
     시간초가 움직이면 안되므로 return 합니다.*/
    private void FixedUpdate()
    {
        if (dalogManager.IsAction)
            return;

        if (timeLimit <= 0)
        {
            GameManager.instance.EndGame();
            OffActive();
        }
        else
        {
            timeLimit -= Time.fixedDeltaTime;
            s = timeLimit.ToString().Split('.')[0];
            ms = timeLimit.ToString().Split('.')[1].Substring(0, 1);

            textMeshPro.text = s + '.' + ms;
        }
    }

    public void OnActive(float mTime)
    {
        gameObject.SetActive(true);
        transform.SetParent(playerPos);
        rectTransform.anchoredPosition = new Vector3(0, 1, 0);
        timeLimit = mTime;
        statusUI.SetActive(false);
    }

    public void OffActive()
    {
        transform.SetParent(null);
        gameObject.SetActive(false);
        statusUI.SetActive(true);
    }


}
