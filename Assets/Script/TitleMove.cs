using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #�뵵#
/// ���� Ÿ��Ʋ���� �� �̵�
/// 
/// #���� ������Ʈ#
/// (P)Exit , TileSceneMove() �޼ҵ带 ȣ���ϰ��� �ϴ� ��
/// 
/// #Method#
/// -public void TileSceneMove()
/// MAINTITLE�� ������ �̵��մϴ�.
/// 
/// </summary>
public class TitleMove : MonoBehaviour
{
    public void TileSceneMove()
    {
        SceneManager.LoadScene(SceneConstIndex.MAINTITLE);
    }
}
