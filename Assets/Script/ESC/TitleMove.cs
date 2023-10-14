using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleMove : MonoBehaviour
{
    public void TileSceneMove()
    {
        SceneManager.LoadScene(SceneConstIndex.MAINTITLE);
    }
}
