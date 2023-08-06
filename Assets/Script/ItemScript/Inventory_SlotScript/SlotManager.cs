using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�׽�Ʈ�� ��ũ��Ʈ
//���� �κ��丮 ������ �ν����Ϳ��� ���� ���ϰ� �ϱ� ����.
public class SlotManager : MonoBehaviour
{
    [SerializeField]
    public bool[] isSlot;

    [SerializeField]
    private int childCount;


    void Start()
    {
        childCount = transform.childCount; // �ڽ� �� 
        isSlot = new bool[childCount];
    }

    void Update()
    {
        //Debug.Log("�ڽ� �� " + childCount);
        //Debug.Log("�迭 ��" + isSlot.Length);
        for (int i = 0; i < childCount; i++)
        {
            // �ڽ��� ���� ��ũ��Ʈ�� isFull������ ���� �� ����
            if (transform.GetChild(i).GetComponent<DroppableUI>().isFull)
                isSlot[i] = true;
            else
                isSlot[i] = false;
        }
    }
}
