using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// #�뵵#
/// ����Ű�� ���� ������ UI�� ����� �� �ֵ��� �ϴ�
/// MapInterationŬ������ �����մϴ�.
/// 
/// #���� ������Ʈ#
/// Map �������� FileItem��ũ��Ʈ�� Item ����
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// Map�� �����ϴ� MapInteration Ŭ������ ���� �������
/// ��ũ��Ʈ�� ���� �� �ֵ����մϴ�.
/// 
/// </summary>
public class MapItem : MonoBehaviour
{
    public MapInteration mapInteration;
    public Sprite sourceImage;
    public Image mapImageComponet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mapInteration.Panel_YN = true;
            mapImageComponet.sprite = sourceImage;
            gameObject.SetActive(false);
        }
    }
}
