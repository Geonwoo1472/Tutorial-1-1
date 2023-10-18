using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// #용도#
/// 단축키로 맵의 지도가 UI에 노출될 수 있도록 하는
/// MapInteration클래스를 조작합니다.
/// 
/// #부착 오브젝트#
/// Map 아이템의 FileItem스크립트의 Item 변수
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// Map을 관리하는 MapInteration 클래스의 값을 변경시켜
/// 스크립트가 사용될 수 있도록합니다.
/// 
/// </summary>
public class MapItem : MonoBehaviour
{
    public MapInteration mapInteration;
    public Sprite sourceImage;
    public Image mapImageComponet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mapInteration.Panel_YN = true;
            mapImageComponet.sprite = sourceImage;
            gameObject.SetActive(false);
        }
    }
}
