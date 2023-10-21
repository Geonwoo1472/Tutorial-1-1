using UnityEngine;

// ��ȣ�ۿ��� ������ �������� Ȯ���ؾ��ϹǷ� ���������� ������ �ϴ� �θ�
public class IDestroyable : MonoBehaviour
{
    protected bool destroyTree;

    private void Start()
    {
        destroyTree = false;
    }
    public void MyOnDestroy()
    {
        destroyTree = true;
    }

    public void OffDestroy()
    {
        destroyTree = false;
    }

    public virtual void InteractionDestroy()
    {

    }

}