using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 붕괴 기능이후 지정오브젝트를 비활성 시킵니다.
/// 
/// #object used(부착 오브젝트)#
/// 붕괴 후 다른 오브젝트가 비활성 되어야하는 경우
/// 
/// #Method#
/// -protected override void Collapsing()
/// 인스펙터에서 초기화한 게임오브젝트를
/// 비활성합니다.
/// 
/// </summary>
public class BrittleCollapse : Collapse
{
    public GameObject brittleWall;         // 부숴지는 가벽

    /*
     동굴 기능 활성시 지정된 가벽을 비활성화 시킵니다.
     */
    protected override void Collapsing()
    {
        base.Collapsing();
        brittleWall.SetActive(false);
    }

}
