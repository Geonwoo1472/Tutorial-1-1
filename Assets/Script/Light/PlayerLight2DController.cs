using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //new version URP

/// <summary>
/// #Usage(�뵵)#
/// Light2D�� �������� �� �����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// Light2D ������Ʈ�� �ڽ����� ������ �ִ� ���ӿ�����Ʈ
/// 
/// #Method#
/// -public void brightnessChangeCorutin(float)
/// ���� �ڷ�ƾ�� ȣ���ŵ�ϴ� float �� ��ŭ ��Ⱑ ������ �����մϴ�.
/// 
/// 
/// -public void SetActive(bool)
/// ������ ���ӿ�����Ʈ�� Ȱ�������� bool ������ �����մϴ�.
/// 
/// 
/// -public void LightSetActive(bool)
/// �ڽĿ�����Ʈ Light2D�� Ȱ�������� bool ������ �����մϴ�.
/// 
/// 
/// -private IEnumerator changeBrightness(float)
/// �� ������ ���� ��� ������ float ����ŭ ������ ������ŵ�ϴ�.
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

    // �þ� ����
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
