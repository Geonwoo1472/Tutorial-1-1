using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum KeyAction
{
    UP = 0,
    DOWN = 1,
    LEFT = 2,
    RIGHT = 3,
    INVENTORY = 4,
    MAP = 5,
    INTERACTION = 6,
    QUICKONE = 7,
    QUICKTWO = 8,
    QUICKTHREE = 9,
    QUICKFOUR = 10,
    QUICKFIVE = 11,
    ESC = 12,
    KEYCOUNT
}

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

    public delegate void OnKeyChange();                     // �븮��
    public OnKeyChange onKeyChange;                         // �븮�� �ν��Ͻ�
    
    KeyCode[] defaultKeys = new KeyCode[] {
        KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D,
        KeyCode.I, KeyCode.M, KeyCode.Space,
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,KeyCode.Alpha4, KeyCode.Alpha5,
        KeyCode.Escape
    };
    /* 
    �� ������ ���� ȣ��Ǵ� �༮ Update�� �� ���̴� ����.
    Ű ���� �̺�Ʈ ó�� ����� ����ϰ� ����. 
     */
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

    int key = -1;
    public void ChangeKey(int num)
    {
        key = num;
    }
}
