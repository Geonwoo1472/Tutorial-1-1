using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// #Usage(용도)#
/// 파일을 저장하기 위한 직렬화데이터 클래스입니다.
/// 
/// #object used(부착 오브젝트)#
/// X 
/// 
/// #Method#
/// X
/// 
/// </summary>
public class DataFile
{
    public int imageNumber;
    public string timeLine;
    public string stageLine;
    public string storyLine;
    public playerPositionVector playerPos;
    public List<int> itemNumberList = new List<int>();


    public class playerPositionVector
    {
        public float x;
        public float y;

        public playerPositionVector(float _x, float _y)
        {
            x = _x;
            y = _y;
        }
    }

    public DataFile()
    {
        //Debug.Log("나는 빈 깡통 생성자");
    }

    public DataFile(int _imageNumber, string _stageLine, string _storyLine, float xpos, float ypos, List<int> _itemNumberList)
    {
        imageNumber = _imageNumber;
        timeLine = System.DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss"));
        stageLine = _stageLine;
        storyLine = _storyLine;
        playerPos = new playerPositionVector(xpos,ypos);

        for (int i = 0; i < _itemNumberList.Count; i++)
        {
            itemNumberList.Add(_itemNumberList[i]);
        }
    }

    public DataFile(string _timeLine, string _stageLine, string _storyLine, float _xpos, float _ypos, List<int> _itemNumberList)
    {
        timeLine = _timeLine;
        stageLine = _stageLine;
        storyLine= _storyLine;
        playerPos= new playerPositionVector(_xpos, _ypos);
        for (int i = 0; i < _itemNumberList.Count; i++)
            itemNumberList.Add(_itemNumberList[i]);

    }

    public void Print()
    {
        Debug.Log("timeLine : " + timeLine);
        Debug.Log("stageLine : " + stageLine);
        Debug.Log("storyLine : " + storyLine);
        Debug.Log("playerPos : " + playerPos.x + "," + playerPos.y);
        for (int i = 0; i < itemNumberList.Count; i++)
        {
            Debug.Log(string.Format("itemNumber i : {0} : {1}", i, itemNumberList[i]));
        }

        Debug.Log("Print() end!");
    }
}
