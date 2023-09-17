using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
