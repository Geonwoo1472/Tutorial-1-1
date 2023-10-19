using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //new version URP

/// <summary>
/// #Usage(용도)#
/// Light2D의 밝기범위의 를 관리합니다.
/// 
/// #object used(부착 오브젝트)#
/// Light2D 오브젝트를 자식으로 가지고 있는 게임오브젝트
/// 
/// #Method#
/// -public void brightnessChangeCorutin(float)
/// 내부 코루틴을 호출시킵니다 float 값 만큼 밝기가 서서히 증가합니다.
/// 
/// 
/// -public void SetActive(bool)
/// 부착된 게임오브젝트의 활성유무를 bool 값으로 변경합니다.
/// 
/// 
/// -public void LightSetActive(bool)
/// 자식오브젝트 Light2D의 활성유무를 bool 값으로 변경합니다.
/// 
/// 
/// -private IEnumerator changeBrightness(float)
/// 매 프레임 마다 밝기 범위를 float 값만큼 서서히 증가시킵니다.
/// 
/// </summary>
public class PlayerLight2DController : MonoBehaviour
{
    #region Singleton
    public static PlayerLight2DController instance;
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

    private GameObject lightObject;
    private Light2D playerLight2D;
    private float currentLightValue;
    private int expansionSpeed;

    private void Start()
    {
        lightObject = transform.GetChild(0).gameObject;
        playerLight2D = transform.GetChild(0).GetComponent<Light2D>();

        if (playerLight2D == null)
            Debug.Log("playerLight2D Null , 2DController.cs ");

        currentLightValue = playerLight2D.pointLightOuterRadius;
        expansionSpeed = 5;
    }

    public void brightnessChangeCorutin(float eyeSightValue)
    {
        StartCoroutine(changeBrightness(eyeSightValue));
    }


    public void SetActive(bool mValue)
    {
        gameObject.SetActive(mValue);
    }

    public void LightSetActive(bool value)
    {
        lightObject.SetActive(value);
    }

    // 시야 증가
    private IEnumerator changeBrightness(float eyeSightValue)
    {
        while (currentLightValue >= eyeSightValue)
        {
            currentLightValue += Time.deltaTime;
            currentLightValue -= Time.deltaTime * expansionSpeed;
            playerLight2D.pointLightOuterRadius = currentLightValue;

            yield return null;
        }

        while (currentLightValue <= eyeSightValue)
        {
            currentLightValue += Time.deltaTime * expansionSpeed;
            playerLight2D.pointLightOuterRadius = currentLightValue;

            yield return null;
        }
    }
}
