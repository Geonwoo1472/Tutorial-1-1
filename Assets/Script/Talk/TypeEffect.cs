using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public int CharPerSeconds;                  // ��� �ӵ�
    public GameObject EndCursor;                // CurSor ������Ʈ
    public bool isAnim;                        // ��ȭ������ �Ǻ�
    public Text msgText;                       // UI Text ������Ʈ
    public AudioSource audioSource;            // Audio

    private string targetMsg;                   // Typing Message
    private int index;                          // Message Index
    private float interval;                     // �ӵ� ��� float
    
    /*
    �޽����� �޾� ó���ϱ����� �޼ҵ��Դϴ�.
    SetMsg(string) �� ȣ���ϸ� ��ǳ���� �޽����� ����ݴϴ�.
     */
    public void SetMsg(string msg)              
    {
        if (isAnim)
        {
            msgText.text = targetMsg;           // ��Ȱ���� Awake()��ȣ��� null error
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
    ��ǳ���� ���ڿ� �Է��� �����ϴ� �޼ҵ��Դϴ�.
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
    ��ǳ���� ���ڿ��� �ѹ��� ����ϴ� ���� �ƴ�
    �� ���� �� ���� ����ϱ� ���� �޼ҵ��Դϴ�.
    Invoke�� ���ؼ� ������ �ð����� ȣ��˴ϴ�.
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
    ��ǳ���� ���ڰ� �ԷµǴ� ���� ����ġ�� �޼ҵ��Դϴ�.
     */
    private void EffectEnd()
    {
        isAnim = false;
        EndCursor.SetActive(true);
    }

}
