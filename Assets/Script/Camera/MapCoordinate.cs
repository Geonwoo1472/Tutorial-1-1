using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #�뵵#
/// CameraController�� �����Ͽ� ���˴ϴ�.
/// ī�޶� �̵� ������ �� ������ ���ѵ˴ϴ�.
/// �ٸ� ������ �Ѿ�� ī�޶� �������� ���ϴ� ��찡 �߻��ϱ⿡
/// ���ѹ����� �ε����� �����Ͽ� ���� �����ؾ��ϴ� ������ �缳���մϴ�.
/// 
/// #���� ������Ʈ#
/// �� ��ü�� �ڵ���, BoxCollider2D�� �����Ǹ�, isTriiger�� üũ�Ǿ� �ִ� ������Ʈ.
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// ī�޶� ��Ʈ�ѷ� ��ũ��Ʈ�� �����Ͽ� �ε��� ������ �����մϴ�.
/// </summary>
public class MapCoordinate : MonoBehaviour
{
    [SerializeField]
    private int mapIndexNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CameraController cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
            if (cameraController != null)
            {
                cameraController.MapIndex = mapIndexNumber;
            }
        }
    }
}
