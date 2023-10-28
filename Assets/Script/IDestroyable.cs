using UnityEngine;

// 상호작용이 가능한 상태인지 확인해야하므로 공통적으로 가져야 하는 부모
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