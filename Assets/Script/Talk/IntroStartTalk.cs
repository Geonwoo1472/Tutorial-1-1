using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroStartTalk : MonoBehaviour
{
    private IntroDialogManager manager;                   // DalogManger.cs
    
    void Start()
    {
        manager = GameObject.Find("IntroDalogManager").GetComponent<IntroDialogManager>();
        manager.endCommunication += NextScene;
        manager.Action(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeySetting.keys[KeyAction.INTERACTION]))
        {
            manager.Action(gameObject);
        }
        
    }

    /*
     ��ǳ�� ���� �� ȣ��
     */
    private void NextScene()
    {
        SceneManager.LoadScene(SceneConstIndex.CHAPTER1);
    }

}
