using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// #Usage(용도)#
/// 
/// #object used(부착 오브젝트)#
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
