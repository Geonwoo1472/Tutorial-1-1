using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(�뵵)#
/// 
/// #object used(���� ������Ʈ)#
///
/// #Method#
///
/// </summary>
public class OverUIReStart : MonoBehaviour
{
    public void ReStart()
    {
        SceneManager.LoadScene(GameManager.instance.sceneIndex);
    }
}
