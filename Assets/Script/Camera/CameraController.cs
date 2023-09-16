using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MapMovingPos
{
    public float xMinPos;
    public float xMaxPos;
    public float yMinPos;
    public float yMaxPos;
}

[System.Serializable]
public struct CoordinateObject
{
    public Transform minCoordinate;
    public Transform maxCoordinate;
}


public class CameraController : MonoBehaviour
{
    public Transform cameraPos;
    public Transform playerPos;

    [SerializeField]
    public CoordinateObject[] structCoordinate;

    private MapMovingPos[] mapMovingPos;

    [Header("Ȯ�ο�")]
    [SerializeField]
    private int mapIndex;

    private Vector3 cameraVector;

    public int MapIndex
    {
        set { mapIndex = value; }
    }

    /*
     �ν����ͷ� ���� ���� ������Ʈ�� ��ġ�� �������
    ����ó�� �� �Ǽ��� �����ϰ��ִ� ����ü�� �ʱ�ȭ�ϴ� �۾��� ��Ĩ�ϴ�.
    �ܰ��� ������ ���⵵ ���� ���� InitSetPosition()�� �ѹ� ȣ���մϴ�.
     */
    private void Awake()
    {
        cameraVector = new Vector3(playerPos.position.x, playerPos.position.y, -10);
        mapIndex = 0;
        mapMovingPos = new MapMovingPos[structCoordinate.Length];

        for (int i = 0; i < structCoordinate.Length; i++)
        {
            mapMovingPos[i].xMinPos = structCoordinate[i].minCoordinate.position.x;
            mapMovingPos[i].yMinPos = structCoordinate[i].minCoordinate.position.y;
            mapMovingPos[i].xMaxPos = structCoordinate[i].maxCoordinate.position.x;
            mapMovingPos[i].yMaxPos = structCoordinate[i].maxCoordinate.position.y;
        }
        InitSetPosition();

    }

    /*
     ���� ������ �����δٸ� ī�޶�� �÷��̾��� ��ġ�� ���󰩴ϴ�.
    ���� �ۿ��� �����δٸ� ������ �ʽ��ϴ�.
     */
    void Update()
    {
        if (playerPos.position.x > mapMovingPos[mapIndex].xMinPos && playerPos.position.x < mapMovingPos[mapIndex].xMaxPos)
        {
            cameraVector.x = playerPos.position.x;
        }
        if (playerPos.position.y > mapMovingPos[mapIndex].yMinPos && playerPos.position.y < mapMovingPos[mapIndex].yMaxPos)
        {
            cameraVector.y = playerPos.position.y;
        }

        cameraPos.position = cameraVector;
    }

    /*
     �� ó�� �������� �����ϴ� ��� �ܰ��� �������� ����˴ϴ�.
     ������ ���� ���� ����ó���ϴ� �����Դϴ�.
     */
    private void InitSetPosition()
    {
        if (playerPos.position.x < mapMovingPos[mapIndex].xMinPos)
            cameraVector.x = mapMovingPos[mapIndex].xMinPos;
        else if (playerPos.position.x > mapMovingPos[mapIndex].xMaxPos)
            cameraVector.x = mapMovingPos[mapIndex].xMaxPos;

        if (playerPos.position.y < mapMovingPos[mapIndex].yMinPos)
            cameraVector.y = mapMovingPos[mapIndex].yMinPos;
        else if(playerPos.position.y > mapMovingPos[mapIndex].yMaxPos)
            cameraVector.y = mapMovingPos[mapIndex].yMaxPos;
    }
}
