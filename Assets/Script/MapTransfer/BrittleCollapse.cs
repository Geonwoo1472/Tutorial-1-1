using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
