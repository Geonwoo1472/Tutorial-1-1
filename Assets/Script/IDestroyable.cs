using UnityEngine;

// 상호작용이 가능한 상태인지 확인해야하므로 공통적으로 가져야 하는 부모
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