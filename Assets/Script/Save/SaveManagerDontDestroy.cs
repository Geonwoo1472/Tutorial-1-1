using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(용도)#
///
/// #object used(부착 오브젝트)#
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
