using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    /*
     ���� �ų����� ������ �ִ� ���� ���� ���ڿ� ������ ����
    ���εǾ� �ִ� ������ ī�޶� �Űܰ��ϴ�.
    MapToal���� ȣ���Ͽ� ����ϰ� �ֽ��ϴ�.
     */
    public void CameraPosMove()
    {
        string cameraPivot = GameManager.instance.currentMapName;
        GameObject go = GameObject.Find(cameraPivot);
        if(go != null)
        {
            transform.position = go.transform.position;
        }
        else
            Debug.Log("go�� NULL �Դϴ�.");
    }
}
