using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerDontDestroy : MonoBehaviour
{
    public static MixerDontDestroy instance;
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
