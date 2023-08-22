using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionPopupManager : MonoBehaviour
{
    public Text[] txt;

    private KeyManager keyManager;

    private void Start()
    {
        keyManager = GetComponent<KeyManager>();
        keyManager.onKeyChange += keyRendering;
        keyRendering();
    }

    public void keyRendering()
    {
        for (int i = 0; i < txt.Length; i++)
        {
            txt[i].text = KeySetting.keys[(KeyAction)i].ToString();
        }
    }

}
