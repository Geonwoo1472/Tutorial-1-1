using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTalk : MonoBehaviour
{
    private Player_Action action;
    private GameObject scanObject;
    private Rigidbody2D rigid;
    private DalogManager dalogManager;
    private void Start()
    {
        action = GetComponent<Player_Action>();
        rigid = GetComponent<Rigidbody2D>();
        dalogManager = GameObject.Find("DalogManager").GetComponent<DalogManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (scanObject != null)
            {
                dalogManager.Action(scanObject);
            }
        }
    }
    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, action.get_v_dir() * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, action.get_v_dir(), 0.7f, LayerMask.GetMask("TalkObject"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }

    public GameObject getScanObject()
    {
        return scanObject;
    }
}
