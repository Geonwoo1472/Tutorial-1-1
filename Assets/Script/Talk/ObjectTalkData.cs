using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// ��ǳ�� ������Ʈ�� �������� �⺻ ������ ������ �ֽ��ϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// ��ǳ���� ����� �� ���ӿ�����Ʈ
/// 
/// #Method#
/// X
/// 
/// </summary>
public class ObjectTalkData : MonoBehaviour
{
    public int ID;              //��ǳ���� �ҷ��� ���� ID
    public bool isNpc;          //Npc ����

    [HideInInspector]
    public bool autoTalkUse;     // AutoTalk ��뿩��

}
