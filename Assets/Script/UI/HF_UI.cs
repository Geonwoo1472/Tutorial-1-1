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

    private void Start()
    {
        StatusManager.instance.onChangeStatusUI += ChangeStatusUI;
    }

    private void ChangeStatusUI()
    {
        sliderHunger.value = Utils.Percent(PlayerStatus.instance.Hunger, PlayerStatus.instance.HungerMax);
        textHunger.text = PlayerStatus.instance.Hunger + "/" + PlayerStatus.instance.HungerMax;
        sliderFatigue.value = Utils.Percent(PlayerStatus.instance.Fatigue, PlayerStatus.instance.FatigueMax);
        textFatigue.text = PlayerStatus.instance.Fatigue + "/" + PlayerStatus.instance.FatigueMax;
    }

    private void OnDisable()
    {
        StatusManager.instance.onChangeStatusUI -= ChangeStatusUI;
    }
}
