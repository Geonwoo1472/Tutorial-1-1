using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �� ���� �� �÷��̾� ��ġ�� �缳���մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// Empty Object
/// 
/// #Method#
/// -private void positionSetting()
/// GameManager�� �������ִ� ���� �� �̸���
/// ���� ���ڿ� ������ ���� ���ٸ�
/// �÷��̾��� ��ġ�� SavePoint�� ������ ���ӿ�����Ʈ ��ġ�� �̵���ŵ�ϴ�.
/// 
/// </summary>
public class SavePoint : MonoBehaviour
{
    public string regionName;

    private Transform playerTransform;
    private GameManager gameManager;
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        gameManager = GameManager.instance;

        positionSetting();
    }
    
    private void positionSetting()
    {
        if(regionName == gameManager.currentMapName)
        {
            playerTransform.position = transform.position;
        }
    }

}
