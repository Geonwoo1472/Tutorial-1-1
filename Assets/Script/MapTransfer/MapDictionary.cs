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

    public Dictionary<string, string> dict;         // 스폰된 위치에 따라 현재 맵을 구분하는 사전입니다.

    private void Start()
    {
        dict = new Dictionary<string, string>();

        Stage1();
        Stage2();
        Stage3();
        SaveStage();
    }

    private void SaveStage()
    {
        dict.Add("StartPoint2", "CameraPos2-1");
        dict.Add("StartPoint3", "CameraPos3-1");
        dict.Add("StartPointCenter4", "CameraPos4-1");
        dict.Add("StartPointLeft4", "CameraPos4-3");
        dict.Add("StartPointRight4", "CameraPos4-4");
    }

    private void Stage1()
    {
        // 1스테이지
        dict.Add("PS1-1", "CameraPos1");
        dict.Add("PS1-2", "CameraPos2");
        dict.Add("PS1-3", "CameraPos3");
        dict.Add("PS1-4", "CameraPos4");

        dict.Add("PE1-1", "CameraPos1");
        dict.Add("PE1-2", "CameraPos2");
        dict.Add("PE1-3", "CameraPos3");
        dict.Add("PE1-4", "CameraPos4");
    }
    private void Stage2()
    {
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
    private void Stage3()
    {
        // 3스테이지
        // 3-1 ok
        dict.Add("SpawnTop3-1", "CameraPos3-1");
        dict.Add("SpawnRight3-1", "CameraPos3-1");

        // 3-2 ok
        //dict.Add("SpawnDown3-2", "CameraPos3-2");
        dict.Add("SpawnRight3-2", "CameraPos3-2");
        dict.Add("SpawnTop3-2", "CameraPos3-2");
        dict.Add("SpawnLeft3-2", "CameraPos3-2");

        // 3-3 ok
        //dict.Add("SpawnDown3-3", "CameraPos3-3");
        dict.Add("SpawnRight3-3", "CameraPos3-3");
        dict.Add("SpawnTop3-3", "CameraPos3-3");
        dict.Add("SpawnLeft3-3", "CameraPos3-3");

        // 3-4 ok
        //dict.Add("SpawnDown3-4", "CameraPos3-4");
        dict.Add("SpawnRight3-4", "CameraPos3-4");
        dict.Add("SpawnTop3-4", "CameraPos3-4");
        dict.Add("SpawnLeft3-4", "CameraPos3-4");

        // 3-5 ok
        dict.Add("SpawnDown3-5", "CameraPos3-5");
        dict.Add("SpawnRight3-5", "CameraPos3-5");
        //dict.Add("SpawnTop3-5", "CameraPos3-5");
        //dict.Add("SpawnLeft3-5", "CameraPos3-5");

        // 3-6 ok
        dict.Add("SpawnDown3-6", "CameraPos3-6");
        dict.Add("SpawnRight3-6", "CameraPos3-6");
        //dict.Add("SpawnTop3-6", "CameraPos3-6");
        dict.Add("SpawnLeft3-6", "CameraPos3-6");

        // 3-7 ok
        dict.Add("SpawnDown3-7", "CameraPos3-7");
        dict.Add("SpawnRight3-7", "CameraPos3-7");
        dict.Add("EXIT", "CameraPos3-7");
        dict.Add("SpawnLeft3-7", "CameraPos3-7");

        // 3-8 ok
        dict.Add("SpawnDown3-8", "CameraPos3-8");
        dict.Add("SpawnRight3-8", "CameraPos3-8");
        //dict.Add("SpawnTop3-8", "CameraPos3-8");
        dict.Add("SpawnLeft3-8", "CameraPos3-8");

        // 3-9 ok
        dict.Add("SpawnDown3-9", "CameraPos3-9");
        //dict.Add("SpawnRight3-9", "CameraPos3-9");
        //dict.Add("SpawnTop3-9", "CameraPos3-9");
        dict.Add("SpawnLeft3-9", "CameraPos3-9");
    }
}
