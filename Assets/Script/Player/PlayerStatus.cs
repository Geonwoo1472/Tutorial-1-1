using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ����� ������ �ֱ� �ߴµ� ���⼭ ó���ϴ°� �´°� �𸣰���.
/*
 1. �� ���� �� ���� ����
 2. �ڽ� �� �� ���� ����, UI �޼ҵ� ����
 */

static class HF_Constance
{
    public const float BOXMOVE = 1;
    public const float SWAMPTILE = 1;
    public const float TREETILE = 1;
}


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
    // player states
    private MyStates states;

    //�׽�Ʈ ��� ON/OFF , ON�ΰ�쿡�� �Ƿε� ����� ���� ����.
    [Header("�׽�Ʈ ��� [����ȿ�� ����]")]
    public bool testMode = false;

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
    public short KeyValue
    {
        set => states.keyValue = value;
        get => states.keyValue;
    }
    public bool HasBrightened
    {
        set => states.hasBrightened = value;
        get => states.hasBrightened;
    }


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

    public bool OnDamageHunger(float damage)
    {
        // �׽�Ʈ ����� ���� ����
        if (testMode)
        {
            Debug.Log("TestMode not decreasing");
            return true;
        }

        Hunger -= damage;

        // �÷��̾� ����� 0�� �����Ѵٸ� GameOver ȭ������ ������
        if(Hunger <= 0)
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
        StatusManager.instance.FDChange(HF_Constance.BOXMOVE);

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

    public bool OnKeyValue(short value)
    {
        KeyValue = value;

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
    public short keyValue;
    [HideInInspector]
    public bool hasBrightened;
}