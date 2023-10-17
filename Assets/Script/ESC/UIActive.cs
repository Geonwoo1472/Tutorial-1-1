using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #용도#
/// OnActive()를 사용하기 위한 추상클래스
/// UI를 ESC로 닫기 위한 Stack에서 관리되는 데이터 단위
/// 
/// 
/// #부착 오브젝트#
/// ESC로 닫고자 하는 오브젝트.
/// 
/// #Method#
/// -public abstract void OnActive()
/// override 전용
/// 
/// </summary>
public abstract class UIActive : MonoBehaviour
{
    public abstract void OnActive();
}
