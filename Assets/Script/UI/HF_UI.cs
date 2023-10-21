using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro

/// <summary>
/// #Usage(�뵵)#
/// �÷��̾��� ���� ���¸� UI�� �ݿ��մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// HungerFatigueUI
/// 
/// #Method#
/// [����� ������Ʈ ������ �ǽð� UI�� ȣ���ϰ� �ֽ��ϴ�]
/// 
/// /* ������ �� */
// UI Update������ ���� ���� �޼ҵ�� �����ų ��.
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
