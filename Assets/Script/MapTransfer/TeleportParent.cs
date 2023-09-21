using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportParent : MonoBehaviour
{
    public int numberOfPorts;
    public GameObject objectFolder;

    void Start()
    {
        objectFolder.GetComponentInChildren<Teleport>().teleports = numberOfPorts;
    }
}