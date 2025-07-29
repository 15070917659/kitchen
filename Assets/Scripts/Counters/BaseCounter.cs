using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjParent
{
    [SerializeField] private Transform counterTopPoint;


    private KitchenObj kitchenObj;
    public virtual void Interact(Player player)
    {
        Debug.LogError("���ֻ��౻����Interact");
    }

    public virtual void InteractAlternate(Player player)
    {
        //Debug.LogError("���ֻ��౻����InteractAlternate");
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }

    public void SetKitchenObj(KitchenObj kitchenObj)
    {
        this.kitchenObj = kitchenObj;
    }

    public KitchenObj GetKitchenObj() { return kitchenObj; }

    public void ClearKitchenObj()
    {
        kitchenObj = null;
    }

    public bool HasKitchenObj()
    {
        return kitchenObj != null;
    }
}
