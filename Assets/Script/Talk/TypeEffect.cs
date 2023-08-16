using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;                  // 대사 속도
    public GameObject EndCursor;                // CurSor 오브젝트
    public bool isAnim;                        // 대화중인지 판별

    private string targetMsg;                   // Typing Message
    private Text msgText;                       // UI Text 오브젝트
    private int index;                          // Message Index
    private float interval;                     // 속도 계산 float
    private AudioSource audioSource;            // Audio
    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        msgText = GetComponent<Text>();
    }

    /*
     
     */
    public void SetMsg(string msg)              
    {
        if (isAnim)
        {
            msgText.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    private void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);
        interval = 1.0f / CharPerSeconds;
        isAnim = true;
        Invoke("Effecting", interval);
    }
    private void Effecting()
    {
        if(msgText.text == targetMsg)
        {
            EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        
        if(targetMsg[index] != ' ' || targetMsg[index] != '.')
            audioSource.Play();

        index++;

        Invoke("Effecting", interval);
    }
    private void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }

}
