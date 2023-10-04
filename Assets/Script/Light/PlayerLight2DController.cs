using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; //new version URP

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

    public void playerLight2DCoroutine(float eyeSightValue)
    {
        StartCoroutine(AddEyesight(eyeSightValue));
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
    private IEnumerator AddEyesight(float eyeSightValue)
    {
        while(true)
        {
            yield return StartCoroutine(OnEyesight(eyeSightValue));
            yield return StartCoroutine(OffEyesight());

            break;
        }
    }

    private IEnumerator OnEyesight(float eyeSightValue)
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

        yield return null;
    }
    private IEnumerator OffEyesight()
    {
        yield return null;
    }
}
