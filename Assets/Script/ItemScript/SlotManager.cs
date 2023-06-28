using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//테스트용 스크립트
//현재 인벤토리 정보를 인스펙터에서 보기 편하게 하기 위함.
public class SlotManager : MonoBehaviour
{
    [SerializeField]
    public bool[] isSlot;

    [SerializeField]
    private int childCount;


    void Start()
    {
        childCount = transform.childCount; // 자식 수 
        isSlot = new bool[childCount];
    }

    void Update()
    {
        //Debug.Log("자식 수 " + childCount);
        //Debug.Log("배열 수" + isSlot.Length);
        for (int i = 0; i < childCount; i++)
        {
            // 자식의 슬롯 스크립트의 isFull유무에 따라 값 대입
            if (transform.GetChild(i).GetComponent<DroppableUI>().isFull)
                isSlot[i] = true;
            else
                isSlot[i] = false;
        }
    }
}
