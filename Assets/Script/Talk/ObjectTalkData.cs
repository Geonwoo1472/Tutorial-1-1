using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 말풍선 오브젝트가 가져야할 기본 정보를 가지고 있습니다.
/// 
/// #object used(부착 오브젝트)#
/// 말풍선의 기능을 할 게임오브젝트
/// 
/// #Method#
/// X
/// 
/// </summary>
public class ObjectTalkData : MonoBehaviour
{
    public int ID;              //말풍선을 불러올 지정 ID
    public bool isNpc;          //Npc 여부

    [HideInInspector]
    public bool autoTalkUse;     // AutoTalk 사용여부

}
