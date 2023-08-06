using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStage : MonoBehaviour
{
    [Header("출입구 KeyValue 설정")]
    public short MapChangeKeyValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(PlayerStatus.instance.KeyValue == MapChangeKeyValue)
            {
                SceneManager.LoadScene(SceneConstIndex.CHAPTERSAVE);
            }
        }
    }
}
