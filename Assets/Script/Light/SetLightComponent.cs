using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// Light�� Ȱ��ȭ ��ų�� ���� �����մϴ�.
/// Light�� �ʿ��� 3é�� 5é�Ϳ��� �Ͻ������� ����ϱ� �����Դϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// ���� �Ѿ�� ������ ó���ϴ� ������Ʈ
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// �ε����� ��� ����� bool �������� ����
/// Ȱ�� ������ �����˴ϴ�.
/// 
/// </summary>
public class SetLightComponent : MonoBehaviour
{
    public bool lightYN;
    private PlayerLight2DController lightObject;

    private void Start()
    {
        lightObject = PlayerLight2DController.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lightObject.LightSetActive(lightYN);
    }

}
