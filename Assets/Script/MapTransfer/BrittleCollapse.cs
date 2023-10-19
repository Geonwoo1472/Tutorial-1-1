using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �ر� ������� ����������Ʈ�� ��Ȱ�� ��ŵ�ϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// �ر� �� �ٸ� ������Ʈ�� ��Ȱ�� �Ǿ���ϴ� ���
/// 
/// #Method#
/// -protected override void Collapsing()
/// �ν����Ϳ��� �ʱ�ȭ�� ���ӿ�����Ʈ��
/// ��Ȱ���մϴ�.
/// 
/// </summary>
public class BrittleCollapse : Collapse
{
    public GameObject brittleWall;         // �ν����� ����

    /*
     ���� ��� Ȱ���� ������ ������ ��Ȱ��ȭ ��ŵ�ϴ�.
     */
    protected override void Collapsing()
    {
        base.Collapsing();
        brittleWall.SetActive(false);
    }

}
