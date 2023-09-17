using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLandValue : MonoBehaviour
{
    [SerializeField]
    private int landValueNumber;
    public int LandValueNumber
    {
        get { return landValueNumber; }
    }
}
