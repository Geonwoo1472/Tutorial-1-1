using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// CameraController와 연계하여 사용됩니다.
/// 카메라 이동 범위가 블럭 단위로 제한됩니다.
/// 다른 맵으로 넘어감에 카메라가 움직이지 못하는 경우가 발생하기에
/// 제한범위의 인덱스를 변경하여 현재 제한해야하는 범위를 재설정합니다.
/// 
/// #부착 오브젝트#
/// 맵 전체를 뒤덮는, BoxCollider2D가 부착되며, isTriiger가 체크되어 있는 오브젝트.
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// 카메라 컨트롤러 스크립트를 참조하여 인덱스 변수를 변경합니다.
/// </summary>
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
