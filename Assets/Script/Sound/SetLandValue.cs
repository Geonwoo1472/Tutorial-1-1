using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// #Usage(�뵵)#
/// �ش� ������ ������ �����մϴ�.
/// 
/// #object used(���� ������Ʈ)#
/// �������� ���Ǵ� ������Ʈ
/// 
/// #Method#
/// -int GetterLandValue()
/// ������ ���� ���� �����մϴ�.
/// 
/// </summary>
public class SetLandValue : MonoBehaviour
{
    [SerializeField]
    private int landValueNumber;
    public int LandValueNumber
    {
        get { return landValueNumber; }
    }
}
