using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTarget : MonoBehaviour
{
    public GameObject target;

    /*
    �Ҹ��Ҷ� ���� �Ҹ��� ���ӿ�����Ʈ�� ���մϴ�.
     */
    private void OnDisable()
    {
        Debug.Log("OnDisable ȣ��");
        target.SetActive(false);
    }
}
