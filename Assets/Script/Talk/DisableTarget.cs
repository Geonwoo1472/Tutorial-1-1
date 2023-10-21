using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �Ҹ��Ҷ� ���� �Ҹ��� ���ӿ�����Ʈ�� ���մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// KeyTextTrigger
/// Position 15
/// Position 4
/// 
/// #Method#
/// -void OnDisable()
/// ������ ���ӿ�����Ʈ�� ��Ȱ���մϴ�.
/// 
/// </summary>
public class DisableTarget : MonoBehaviour
{
    public GameObject target;
    public bool targetIsActive;

    /*
    �Ҹ��Ҷ� ���� �Ҹ��� ���ӿ�����Ʈ�� ���մϴ�.
     */
    private void OnDisable()
    {
        Debug.Log("OnDisable ȣ��");
        if(target != null)
            target.SetActive(targetIsActive);
    }
}
