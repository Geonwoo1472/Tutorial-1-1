using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private MyStates states;            // 플레이어의 상태 정보 구조체.
    [HideInInspector]
    public bool testMode;

    /*Player의 구조체 프로퍼티 */
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
    /*Player의 구조체 프로퍼티 */

    /*Player의 구조체 초기화/접근 함수 */
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
    /*Player의 구조체 초기화/접근 함수 */



    public bool OnDamageHunger(float damage)
    {
        // 테스트 모드라면 감소 없음
        if (testMode)
        {
            Debug.Log("TestMode not decreasing");
            return true;
        }

        Hunger -= damage;
        StatusManager.instance.HungerDataReflection(damage,OPERATIONTYPE.MINUS);

        // 플레이어 배고픔 0에 도달한다면 GameOver 화면으로 가야함
        if (Hunger <= 0)
        {
            GameManager.instance.EndGame();
        }

        return true;
    }

    public bool OnDamageFatigue(float damage)
    {
        // 테스트 모드라면 감소 없음
        if (testMode)
        {
            Debug.Log("TestMode not decreasing");
            return true;
        }


        Fatigue -= damage;
        StatusManager.instance.FatigueDataReflection(damage,OPERATIONTYPE.MINUS);

        // 플레이어 피로도 0에 도달한다면..
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
            Debug.Log("배고픔을 초과하여 heal 하였음");
            Hunger = HungerMax;
        }

        return true;
    }

    public bool OnHealFatigue(float heal)
    {
        Fatigue += heal;

        if (Fatigue > FatigueMax)
        {
            Debug.Log("피로도를 초과하여 heal 하였음");
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