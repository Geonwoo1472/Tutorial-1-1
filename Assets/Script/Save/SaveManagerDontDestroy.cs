using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
///
/// #object used(���� ������Ʈ)#
///
/// #Method#
///
/// </summary>
public class SaveManagerDontDestroy : MonoBehaviour
{
    public static SaveManagerDontDestroy instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
