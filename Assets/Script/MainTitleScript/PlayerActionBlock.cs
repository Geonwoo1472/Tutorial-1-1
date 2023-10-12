using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionBlock : MonoBehaviour
{
    public bool isValue;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.MoveStatus = isValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
