using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCompulsionMove : MonoBehaviour
{
    public float stopTime;
    
    private Rigidbody2D rigidbody;
    private void Start()
    {
        stopTime = 0;
        rigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        StartCoroutine(CompulsionMove());
        
    }

    IEnumerator CompulsionMove()
    {
        GameManager.instance.moveStatus = true;
        while (stopTime < 5.0f)
        {
            stopTime += Time.deltaTime;
            Debug.Log("내부 호출 중 stopTime :" + stopTime);
            rigidbody.velocity = new Vector2(1, 0) * 5;
               
            yield return new WaitForFixedUpdate();
            //yield return null;
        }
        GameManager.instance.moveStatus = false;
    }
}
