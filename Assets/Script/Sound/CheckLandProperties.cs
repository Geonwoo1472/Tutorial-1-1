using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
