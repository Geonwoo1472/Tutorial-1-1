using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 발판을 새롭게 밟은 경우 플레이어 발소리를 출력하는
/// AudioSource의 Clip을 상황에 맞는 소리로 변경합니다.
/// 
/// #object used(부착 오브젝트)#
/// FootholdCheck
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// 밟은 땅의 사운드 값을 가져와
/// 상황에 맞는 사운드로 다시 변경합니다.
/// 
/// </summary>
public class CheckLandProperties : MonoBehaviour
{
    public AudioSource playerAudio;

    public AudioClip[] footAudio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Foothold"))
        {
            SetLandValue landValue = collision.GetComponent<SetLandValue>();
            if(landValue != null)
            {
                switch(landValue.LandValueNumber)
                {
                    case 1:
                        playerAudio.clip = footAudio[0];
                        break;
                    case 2:
                        playerAudio.clip = footAudio[1];
                        break;
                    case 3:
                        playerAudio.clip = footAudio[2];
                        break;
                    case 4:
                        playerAudio.clip = footAudio[3];
                        break;
                    case 5:
                        playerAudio.clip = footAudio[4];
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
