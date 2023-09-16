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
     말풍선 끝날 때 호출
     */
    private void NextScene()
    {
        SceneManager.LoadScene(SceneConstIndex.CHAPTER1);
    }

}
