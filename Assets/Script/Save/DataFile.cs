using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataFile
{
    public string timeLine;
    public string stageLine;
    public string storyLine;
    public playerPositionVector playerPos;
    public List<int> itemNumberList;

    public DataFile(string _stageLine, string _storyLine, float xpos, float ypos, List<int> _itemNumberList)
    {
        timeLine = System.DateTime.Now.ToString(("yyyy-MM-dd HH:mm:ss"));
        stageLine = _stageLine;
        storyLine = _storyLine;
        playerPos = new playerPositionVector(xpos, ypos);


        for (int i = 0; i < _itemNumberList.Count; i++)
        {
            itemNumberList.Add(_itemNumberList[i]);
        }
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

    public class playerPositionVector
    {
        public float x;
        public float y;

        public playerPositionVector(float xpos, float ypos)
        {
            x = xpos;
            y = ypos;
        }
    }
}
