using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D catRigidbody;
    private SpriteRenderer image;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        catRigidbody = GetComponent<Rigidbody2D>();
        image = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Invoke("OnMoveTrigger", 2f);   
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    private void OnMoveTrigger()
    {
        anim.SetTrigger("moveTrigger");
        catRigidbody.velocity = Vector2.right;
        StartCoroutine(DecreaseImageAlpha());
    }

    IEnumerator DecreaseImageAlpha()
    {
        float accumulateTime = 0f;
        while (image.color.a > 0)
        {
            accumulateTime += Time.deltaTime;
            Color color = image.color;
            color.a = Mathf.Lerp(1, 0, accumulateTime);

            image.color = color;
            yield return null;
        }
        gameObject.SetActive(false);   
    }
}
