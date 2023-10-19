using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// #Usage(용도)#
/// 키 변경창의 UI Rendering작업을 합니다.
/// 
/// #object used(부착 오브젝트)#
/// Empty Object
/// 
/// #Method#
/// -public void keyRendering()
/// UI txt를 KeyManager의 정보를 받아와
/// 다시 랜더링합니다.
/// 
/// </summary>
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
