using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// [����� ���ǰ� ���� �ʽ��ϴ�.]
/// ���� �ų����� ������ �ִ� ���� ���� ���ڿ� ������ ����
/// ���εǾ� �ִ� ������ ī�޶� �Űܰ��ϴ�.
/// MapToal���� ȣ���Ͽ� ����ϰ� �ֽ��ϴ�.
/// 
/// ���� ������Ʈ : Main Camera
/// 
/// -public void CameraPosMove()
/// ���ӸŴ����� ���ڿ��� �̷���� ���� ���� �̸��� �����ɴϴ�.
/// ���� �� ��ġ�� ī�޶��� ��ġ�� ���Ӱ� �����մϴ�.
/// </summary>
public class CameraMove : MonoBehaviour
{
    public void CameraPosMove()
    {
        string cameraPivot = GameManager.instance.currentMapName;
        GameObject go = GameObject.Find(cameraPivot);
        if(go != null)
        {
            transform.position = go.transform.position;
        }
        else
            Debug.Log("CameraMove.cs , go�� NULL �Դϴ�.");
    }
}
