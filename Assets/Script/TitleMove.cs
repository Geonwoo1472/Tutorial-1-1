using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #용도#
/// 메인 타이틀로의 씬 이동
/// 
/// #부착 오브젝트#
/// (P)Exit , TileSceneMove() 메소드를 호출하고자 하는 곳
/// 
/// #Method#
/// -public void TileSceneMove()
/// MAINTITLE의 씬으로 이동합니다.
/// 
/// </summary>
public class TitleMove : MonoBehaviour
{
    public void TileSceneMove()
    {
        SceneManager.LoadScene(SceneConstIndex.MAINTITLE);
    }
}
