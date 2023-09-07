using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;                  // 대사 속도
    public GameObject EndCursor;                // CurSor 오브젝트
    public bool isAnim;                        // 대화중인지 판별
    public Text msgText;                       // UI Text 오브젝트
    public AudioSource audioSource;            // Audio

    private string targetMsg;                   // Typing Message
    private int index;                          // Message Index
    private float interval;                     // 속도 계산 float
    
    /*
    메시지를 받아 처리하기위한 메소드입니다.
    SetMsg(string) 을 호출하면 말풍선에 메시지를 띄워줍니다.
     */
    public void SetMsg(string msg)              
    {
        if (isAnim)
        {
            msgText.text = targetMsg;           // 비활성시 Awake()미호출로 null error
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }

    /*
    말풍선에 문자열 입력을 시작하는 메소드입니다.
     */
    private void EffectStart()
    {
        msgText.text = "";
        index = 0;
        EndCursor.SetActive(false);
        interval = 1.0f / CharPerSeconds;
        isAnim = true;
        Invoke("Effecting", interval);
    }
    /*
    말풍선의 문자열을 한번에 출력하는 것이 아닌
    한 글자 한 글자 출력하기 위한 메소드입니다.
    Invoke를 통해서 정해진 시간마다 호출됩니다.
     */
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
    /*
    말풍선의 문자가 입력되는 것을 끝마치는 메소드입니다.
     */
    private void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }

}
