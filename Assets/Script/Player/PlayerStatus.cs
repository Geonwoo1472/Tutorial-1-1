using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 1. 맵 들어올 때 스텟 셋팅
 2. 박스 밀 때 스텟 감소, UI 메소드 실행
 */


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

    void Start()
    {
        FatigueMax = 10f;
        HungerMax = 10f;
        Hunger = 10f;
        Fatigue = 10f;

    }

    public bool InitStatus(float _HungerMax, float _FatigueMax, float _Hunger, float _Fatigue)
    {
        return true;
    }

    public bool InitCurrentStatus(float _Hunger, float _Fatigue)
    {
        return true;
    }

    public bool InitHunger(float _Hunger)
    {
        return true;
    }

    public bool InitFatigue(float _Fatigue)
    {
        return true;
    }

    public bool OnDamageHunger(float _Damage)
    {
        return true;
    }

    public bool OnDamageFatigue(float _Damage)
    {
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
}