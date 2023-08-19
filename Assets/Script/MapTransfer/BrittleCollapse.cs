using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
