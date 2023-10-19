using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// ī�޶��� ũ�⸦ �缳���մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// �浹 �� ī�޶� ����� ����� �ʿ䰡 �ִ� ������Ʈ
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// �浹ü�� player���� �˻��մϴ�.
/// 
/// -public void sizeChanging()
/// ī�޶� ����� ���� ���� ������ �����մϴ�.
/// 
/// </summary>
public class CameraSizeChange : MonoBehaviour
{
    public float cameraSize;

    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sizeChanging();
        }
    }


    public void sizeChanging()
    {
        mainCamera.orthographicSize = cameraSize;
    }
}
