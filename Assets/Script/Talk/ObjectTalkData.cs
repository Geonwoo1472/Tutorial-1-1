using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTalkData : MonoBehaviour
{
    public int ID;              //말풍선을 불러올 지정 ID
    public bool isNpc;          //Npc 여부

    [HideInInspector]
    public bool autoTalkUse;     // AutoTalk 사용여부

}
