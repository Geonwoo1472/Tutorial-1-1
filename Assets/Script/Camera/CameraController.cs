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

    [Header("확인용")]
    [SerializeField]
    private int mapIndex;

    private Vector3 cameraVector;

    public int MapIndex
    {
        set { mapIndex = value; }
    }

    /*
     인스펙터로 받은 게임 오브젝트의 위치를 기반으로
    예외처리 할 실수를 포함하고있는 구조체를 초기화하는 작업을 거칩니다.
    외곽의 검은색 노출도 막기 위해 InitSetPosition()을 한번 호출합니다.
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
     범위 내에서 움직인다면 카메라는 플레이어의 위치를 따라갑니다.
    범위 밖에서 움직인다면 따라가지 않습니다.
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
     맨 처음 구석에서 시작하는 경우 외곽의 검은색이 노출됩니다.
     노출을 막기 위해 예외처리하는 과정입니다.
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
