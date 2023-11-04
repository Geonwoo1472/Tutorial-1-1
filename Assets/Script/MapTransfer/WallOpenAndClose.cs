using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOpenAndClose : MonoBehaviour
{
    public float speed;
    public Direction moveDirection;
    public Transform movePoint;
    public bool lightYN;

    [HideInInspector]
    public float irradiateSize = 2f;

    private Vector3 originPos;              // 물체가 움직이기 전 원점 위치

    private Camera mainCamera;
    private Transform cameraPos;
    private Vector3 cameraPastPos;          // 카메라 이동 전 위치
    private float cameraPastSize;

    private FadeEffect fadeEffect;
    private Rigidbody2D wallRigidbody;

    private AudioSource audioSource;
    private void Awake()
    {
        wallRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        originPos = transform.position;
    }

    private void Start()
    {
        GameObject obj = GameObject.Find("Main Camera");
        mainCamera = obj.GetComponent<Camera>();
        cameraPos = obj.transform;
        
        cameraPastSize = mainCamera.orthographicSize;

        fadeEffect = GameObject.Find("FadeImage").GetComponent<FadeEffect>();
    }

    public void Open()
    {
        fadeEffect.OnFade(FadeState.FadeIn);
        Player_Action.instance.PlayerCorouine(PlayerState.pauseMovement,5f);
        GameManager.instance.IsGameOver = true;

        if (lightYN)
        {
            PlayerLight2DController.instance.LightSetActive(false);
        }

        cameraPastPos = cameraPos.position;
        cameraPos.position = movePoint.position;
        mainCamera.orthographicSize = irradiateSize;

        wallRigidbody.velocity = SetVector(moveDirection);
        audioSource.Play();
        Invoke("OffActive", 3f);
    }

    public void Close()
    {
        fadeEffect.OnFade(FadeState.FadeIn);
        gameObject.SetActive(true);
        Player_Action.instance.PlayerCorouine(PlayerState.pauseMovement, 5f);
        GameManager.instance.IsGameOver = true;

        if (lightYN)
        {
            PlayerLight2DController.instance.LightSetActive(false);
        }

            cameraPastPos = cameraPos.position;
        cameraPos.position = movePoint.position;
        mainCamera.orthographicSize = irradiateSize;
        wallRigidbody.velocity = SetReverseVector(moveDirection);
        audioSource.Play();

        Invoke("OnActive", 3f);
    }

    private void OnActive()
    {
        fadeEffect.OnFade(FadeState.FadeIn);
        GameManager.instance.IsGameOver = false;
        wallRigidbody.velocity = Vector2.zero;

        if(lightYN)
        {
            PlayerLight2DController.instance.LightSetActive(true);
        }

        wallRigidbody.transform.position = originPos;
        cameraPos.position = cameraPastPos;
        mainCamera.orthographicSize = cameraPastSize;
    }

    private void OffActive()
    {
        fadeEffect.OnFade(FadeState.FadeIn);
        GameManager.instance.IsGameOver = false;
        wallRigidbody.velocity = Vector2.zero;

        if(lightYN)
        {
            PlayerLight2DController.instance.LightSetActive(true);
        }

        cameraPos.position = cameraPastPos;
        mainCamera.orthographicSize = cameraPastSize;
        gameObject.SetActive(false);
    }

    private Vector2 SetVector(Direction _dir)
    {
        Vector2 vec;

        switch (_dir)
        {
            case Direction.Left:
                vec = Vector2.left * speed;
                break;
            case Direction.Right:
                vec = Vector2.right * speed;
                break;
            case Direction.Up:
                vec = Vector2.up * speed;
                break;
            case Direction.Down:
                vec = Vector2.down * speed;
                break;
            default:
                vec = Vector2.zero;
                Debug.Log("WallOpen.cs Default");
                break;
        }

        return vec;
    }
    private Vector2 SetReverseVector(Direction _dir)
    {
        Vector2 vec;

        switch (_dir)
        {
            case Direction.Left:
                vec = Vector2.right * speed;
                break;
            case Direction.Right:
                vec = Vector2.left * speed;
                break;
            case Direction.Up:
                vec = Vector2.down * speed;
                break;
            case Direction.Down:
                vec = Vector2.up * speed;
                break;
            default:
                vec = Vector2.zero;
                Debug.Log("WallOpen.cs Default");
                break;
        }

        return vec;
    }

}
