using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapItem : MonoBehaviour
{
    public MapInteration mapInteration;
    public Sprite sourceImage;
    public Image mapImageComponet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mapInteration.Panel_YN = true;
            mapImageComponet.sprite = sourceImage;
            gameObject.SetActive(false);
        }
    }
}
