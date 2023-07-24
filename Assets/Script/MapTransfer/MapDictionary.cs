using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDictionary : MonoBehaviour
{
    #region Singleton
    public static MapDictionary instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    public Dictionary<string, string> dict;

    private void Start()
    {
        dict = new Dictionary<string, string>();
        // 1스테이지
        dict.Add("PS1-1", "CameraPos1");
        dict.Add("PS1-2", "CameraPos2");
        dict.Add("PS1-3", "CameraPos3");
        dict.Add("PS1-4", "CameraPos4");

        dict.Add("PE1-1", "CameraPos1");
        dict.Add("PE1-2", "CameraPos2");
        dict.Add("PE1-3", "CameraPos3");
        dict.Add("PE1-4", "CameraPos4");

        // 2스테이지
        // 2-1
        dict.Add("SpawnTop2-1", "CameraPos2-1");
        dict.Add("SpawnRight2-1", "CameraPos2-1");

        // 2-2
        //dict.Add("SpawnDown2-2", "CameraPos2-2");
        dict.Add("SpawnRight2-2", "CameraPos2-2");
        dict.Add("SpawnTop2-2", "CameraPos2-2");
        dict.Add("SpawnLeft2-2", "CameraPos2-2");

        // 2-3
        //dict.Add("SpawnDown2-3", "CameraPos2-3");
        //dict.Add("SpawnRight2-3", "CameraPos2-3");
        dict.Add("SpawnTop2-3", "CameraPos2-3");
        dict.Add("SpawnLeft2-3", "CameraPos2-3");

        // 2-4
        dict.Add("SpawnDown2-4", "CameraPos2-4");
        dict.Add("SpawnRight2-4", "CameraPos2-4");
        dict.Add("SpawnTop2-4", "CameraPos2-4");
        //dict.Add("SpawnLeft2-4", "CameraPos2-4");

        // 2-5
        dict.Add("SpawnDown2-5", "CameraPos2-5");
        dict.Add("SpawnRight2-5", "CameraPos2-5");
        dict.Add("SpawnTop2-5", "CameraPos2-5");
        dict.Add("SpawnLeft2-5", "CameraPos2-5");

        // 2-6
        dict.Add("SpawnDown2-6", "CameraPos2-6");
        //dict.Add("SpawnRight2-6", "CameraPos2-6");
        dict.Add("SpawnTop2-6", "CameraPos2-6");
        dict.Add("SpawnLeft2-6", "CameraPos2-6");

        // 2-7
        dict.Add("SpawnDown2-7", "CameraPos2-7");
        dict.Add("SpawnRight2-7", "CameraPos2-7");
        //dict.Add("SpawnTop2-7", "CameraPos2-7");
        //dict.Add("SpawnLeft2-7", "CameraPos2-7");

        // 2-8
        dict.Add("SpawnDown2-8", "CameraPos2-8");
        dict.Add("SpawnRight2-8", "CameraPos2-8");
        //dict.Add("SpawnTop2-8", "CameraPos2-8");
        dict.Add("SpawnLeft2-8", "CameraPos2-8");

        // 2-9
        dict.Add("SpawnDown2-9", "CameraPos2-9");
        //dict.Add("SpawnRight2-9", "CameraPos2-9");
        //dict.Add("SpawnTop2-9", "CameraPos2-9");
        dict.Add("SpawnLeft2-9", "CameraPos2-9");

    }
}
