using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// Light를 활성화 시킬지 말지 결정합니다.
/// Light가 필요한 3챕터 5챕터에서 일시적으로 사용하기 위함입니다.
/// 
/// #object used(부착 오브젝트)#
/// 씬이 넘어가는 로직을 처리하는 오브젝트
/// 
/// #Method#
/// -private void OnTriggerEnter2D(Collider2D)
/// 부딪히는 경우 내장된 bool 변수값에 의해
/// 활성 유무가 결정됩니다.
/// 
/// </summary>
public class SetLightComponent : MonoBehaviour
{
    public bool lightYN;
    private PlayerLight2DController lightObject;

    private void Start()
    {
        lightObject = PlayerLight2DController.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lightObject.LightSetActive(lightYN);
    }

}
