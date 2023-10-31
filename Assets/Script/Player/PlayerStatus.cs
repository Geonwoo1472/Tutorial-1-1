using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �÷��̾� ���� Ŭ�����Դϴ�.
/// �ʿ����� ���� ���� �ܺ� ��ũ��Ʈ �������� Init�޼ҵ�� ���ɴϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// Player
/// 
/// #Method#
/// -public bool InitStatus(float _HungerMax, float _FatigueMax, float _Hunger, float _Fatigue)
/// �÷��̾��� ������ �Ű������� �ʱ�ȭ�մϴ�.
/// 
/// -public bool OnDamageHunger(float)
/// ������ �� ��ŭ ������� ���ҽ�ŵ�ϴ�.
/// 
/// -public bool OnHealHunger(float)
/// ������ �� ��ŭ ������� ȸ���մϴ�.
/// 
/// -public bool OnDamageFatigue(float)
/// ������ �� ��ŭ �Ƿε��� ���ҽ�ŵ�ϴ�.
/// 
/// -public bool OnHealFatigue(float)
/// ������ �� ��ŭ �Ƿε��� ȸ���մϴ�.
/// 
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    #region Singleton
    public static PlayerStatus instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    private MyStates states;           
    [HideInInspector]
    public bool testMode;



    /*Player�� ����ü ������Ƽ */
    public float Hunger
    {
        set => states.Hunger = Mathf.Clamp(value, 0, states.HungerMax);
        get => states.Hunger;
    }
    public float Fatigue
    {
        set => states.Fatigue = Mathf.Clamp(value, 0, states.FatigueMax);
        get => states.Fatigue;
    }
    public float HungerMax
    {
        set => states.HungerMax = value;
        get => states.HungerMax;
    }
    public float FatigueMax
    {
        set => states.FatigueMax = value;
        get => states.FatigueMax;
    }
    public bool HasBrightened
    {
        set => states.hasBrightened = value;
        get => states.hasBrightened;
    }
    /*Player�� ����ü ������Ƽ */

    /*Player�� ����ü �ʱ�ȭ/���� �Լ� */
    public bool InitStatus(float _HungerMax, float _FatigueMax, float _Hunger, float _Fatigue)
    {
        HungerMax = _HungerMax;
        FatigueMax = _FatigueMax;
        Hunger = _Hunger;
        Fatigue = _Fatigue;
        HasBrightened = false;

        return true;
    }
    public bool InitCurrentStatus(float _Hunger, float _Fatigue)
    {
        Hunger = _Hunger;
        Fatigue = _Fatigue;

        return true;
    }
    public bool InitHunger(float _Hunger)
    {
        Hunger = _Hunger;

        return true;
    }
    public bool InitHungerMax(float _HungerMax)
    {
        HungerMax = _HungerMax;

        return true;
    }
    public bool InitFatigue(float _Fatigue)
    {
        Fatigue = _Fatigue;

        return true;
    }
    public bool InitFatigueMax(float _FatigueMax)
    {
        FatigueMax = _FatigueMax;

        return true;
    }
    /*Player�� ����ü �ʱ�ȭ/���� �Լ� */



    public bool OnDamageHunger(float damage)
    {
        // �׽�Ʈ ����� ���� ����
        if (testMode)
        {
            Debug.Log("TestMode not decreasing");
            return true;
        }

        Hunger -= damage;
        StatusManager.instance.HungerDataReflection(damage,OPERATIONTYPE.MINUS);

        // �÷��̾� ����� 0�� �����Ѵٸ� GameOver ȭ������ ������
        if (Hunger <= 0)
        {
            GameManager.instance.EndGame();
        }

        return true;
    }

    public bool OnDamageFatigue(float damage)
    {
        // �׽�Ʈ ����� ���� ����
        if (testMode)
        {
            Debug.Log("TestMode not decreasing");
            return true;
        }


        Fatigue -= damage;
        StatusManager.instance.FatigueDataReflection(damage,OPERATIONTYPE.MINUS);

        // �÷��̾� �Ƿε� 0�� �����Ѵٸ�..
        if(Fatigue <= 0)
        {
            GameManager.instance.EndGame();
        }

        return true;
    }

    public bool OnHealHunger(float heal)
    {
        Hunger += heal;

        if(Hunger > HungerMax)
        {
            Debug.Log("������� �ʰ��Ͽ� heal �Ͽ���");
            Hunger = HungerMax;
        }

        return true;
    }

    public bool OnHealFatigue(float heal)
    {
        Fatigue += heal;

        if (Fatigue > FatigueMax)
        {
            Debug.Log("�Ƿε��� �ʰ��Ͽ� heal �Ͽ���");
            Fatigue = FatigueMax;
        }

        return true;
    }
}

[System.Serializable]
public struct MyStates
{
    [HideInInspector]
    public float Hunger;
    [HideInInspector]
    public float HungerMax;
    [HideInInspector]
    public float Fatigue;
    [HideInInspector]
    public float FatigueMax;
    [HideInInspector]
    public bool hasBrightened;
}