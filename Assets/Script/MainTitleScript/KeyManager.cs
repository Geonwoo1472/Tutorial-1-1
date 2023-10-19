using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
/// 입력키를 원하는 키로 변경할 수 있는 기능입니다.
/// 
/// #object used(부착 오브젝트)#
/// Empty Object
/// 
/// 
/// #Method#
/// -public void ChangeKey(int)
/// Button의 OnClick()에 등록하여 사용합니다.
/// 입력받은 int 값으로 어떤 키를 받을 지 확인받고
/// 이후 눌린 키로 해당 키를 교체합니다.
///
/// </summary>

public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>();
}
public class KeyManager : MonoBehaviour
{
    #region Singleton
    public static KeyManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        for (int i = 0; i < (int)KeyAction.KEYCOUNT; ++i)
        {
            KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
        }
    }
    #endregion

    public delegate void OnKeyChange();                     // 대리자
    public OnKeyChange onKeyChange;                         // 대리자 인스턴스
    int key = -1;

    KeyCode[] defaultKeys = new KeyCode[] {
        KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D,
        KeyCode.I, KeyCode.M, KeyCode.Space,
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,KeyCode.Alpha4, KeyCode.Alpha5,
        KeyCode.Escape
    };

    private void OnGUI()
    {
        Event KeyEvent = Event.current;

        if (KeyEvent.isKey)
        {
            KeyCode temp = KeyEvent.keyCode;

            for(int i=0; i<(int)KeyAction.KEYCOUNT; ++i)
            {
                if (KeySetting.keys[(KeyAction)i] == temp)
                {
                    key = -1;
                    return;
                }
            }

            KeySetting.keys[(KeyAction)key] = KeyEvent.keyCode;
            if(onKeyChange != null)
                onKeyChange.Invoke();
            key = -1;
        }
    }

    /*Button에서 OnClick() 으로 사용 중*/
    public void ChangeKey(int num)
    {
        key = num;
    }
}
