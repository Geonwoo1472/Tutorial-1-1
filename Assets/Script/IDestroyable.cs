using UnityEngine;

// ��ȣ�ۿ��� ������ �������� Ȯ���ؾ��ϹǷ� ���������� ������ �ϴ� �θ�
public class IDestroyable : MonoBehaviour
{
    protected bool destroyObject;

    private void Start()
    {
        destroyObject = false;
    }
    public void MyOnDestroy()
    {
        destroyObject = true;
    }

    public void OffDestroy()
    {
        destroyObject = false;
    }

    public virtual void InteractionDestroy()
    {

    }

}