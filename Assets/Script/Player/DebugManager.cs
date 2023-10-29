using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    [Header("���׹̳� ����")]
    [SerializeField]
    private bool statusBlock;           // ���׹̳� ���� ���� �����Դϴ�.

    private Transform myCamera;         // ī�޶� ��ǥ���� �����մϴ�.
    private bool debugUse;              // ���� ��� �Ǵ� �����Դϴ�.

    void Start()
    {
        myCamera = GameObject.Find("Main Camera").transform;
        debugUse = true;
        InvincibilityMode();
    }

    /*
     �÷��̾ �� ��ü������ �� �ݶ��̴��� ������ ���
     ī�޶��� ��ġ�� �ݶ��̴��� ��ġ�� �ٲߴϴ�.
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!debugUse)
            return;
        if (other.CompareTag("MapBoxCollider"))
        {
            if(myCamera == null)
                myCamera = GameObject.Find("Main Camera").transform;
            myCamera.position = other.transform.position;
        }
    }
    
    private void InvincibilityMode()
    {
        if (statusBlock)
            PlayerStatus.instance.testMode = true;
    }

}