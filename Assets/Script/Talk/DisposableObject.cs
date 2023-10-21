using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �÷��̾ ��ȣ�ۿ��Ͽ� ����Ǵ� ��ǳ�� ����� 1ȸ������ �����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// Position27 , switch��ɼ��� 1ȸ��
/// 
/// #Method#
/// X
/// 
/// </summary>
public class DisposableObject : MonoBehaviour
{
    private DalogManager dalogManager;
    // Start is called before the first frame update
    void Start()
    {
        dalogManager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
        dalogManager.lastDalog += DeleteObject;
    }

    private void DeleteObject()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        dalogManager.lastDalog -= DeleteObject;
    }
}
