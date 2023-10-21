using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 해당 발판의 종류를 정의합니다.
/// 
/// #object used(부착 오브젝트)#
/// 발판으로 사용되는 오브젝트
/// 
/// #Method#
/// -int GetterLandValue()
/// 발판의 종류 값을 리턴합니다.
/// 
/// </summary>
public class SetLandValue : MonoBehaviour
{
    [SerializeField]
    private int landValueNumber;
    public int LandValueNumber
    {
        get { return landValueNumber; }
    }
}
