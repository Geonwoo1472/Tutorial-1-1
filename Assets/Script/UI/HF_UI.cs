using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro

/// <summary>
/// #Usage(용도)#
/// 플레이어의 스텟 상태를 UI에 반영합니다.
/// 
/// #object used(부착 오브젝트)#
/// HungerFatigueUI
/// 
/// #Method#
/// [현재는 업데이트 문으로 실시간 UI를 호출하고 있습니다]
/// 
/// /* 수정할 것 */
// UI Update문에서 하지 말고 메소드로 실행시킬 것.
/// 
/// </summary>

public class HF_UI : MonoBehaviour
{
    [SerializeField]
    private Slider sliderHunger;
    [SerializeField]
    private Text textHunger;
    [SerializeField]
    private Slider sliderFatigue;
    [SerializeField]
    private Text textFatigue;

    void Update()
    {
        if (sliderHunger != null)
        {
            sliderHunger.value = Utils.Percent(PlayerStatus.instance.Hunger, PlayerStatus.instance.HungerMax);
        }
        if (textHunger != null)
        {
            textHunger.text = PlayerStatus.instance.Hunger + "/" + PlayerStatus.instance.HungerMax;
        }

        if(sliderFatigue != null)
        {
            sliderFatigue.value = Utils.Percent(PlayerStatus.instance.Fatigue, PlayerStatus.instance.FatigueMax);
        }

        if(textFatigue != null)
        {
            textFatigue.text = PlayerStatus.instance.Fatigue + "/" + PlayerStatus.instance.FatigueMax;
        }

    }
}
