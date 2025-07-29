using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObj : MonoBehaviour
{
    [SerializeField] private KitchenObjSO kitchenObjSO;

    private IKitchenObjParent kitchenObjParent;

    public KitchenObjSO GetKitchenObjSO()
    {
        return kitchenObjSO;
    }

    public void SetKitchenObjParent(IKitchenObjParent kitchenObjParent)
    {
        if(this.kitchenObjParent != null)
            this.kitchenObjParent.ClearKitchenObj();
        this.kitchenObjParent = kitchenObjParent;
        if(kitchenObjParent.HasKitchenObj())
        {
            Debug.LogError("这个柜子有一个对象了");
        }
        kitchenObjParent.SetKitchenObj(this);

        transform.parent = kitchenObjParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjParent GetKitchenObjParent()
    {
        return kitchenObjParent;
    }

    public void DestorySelf()
    {
        kitchenObjParent.ClearKitchenObj();
        Destroy(gameObject);
    }

    public static KitchenObj SpawnKitchenObject(KitchenObjSO kitchenObjSO,IKitchenObjParent kitchenObjParent)
    {
        Transform kitchenObjectTranform = Instantiate(kitchenObjSO.prefab);
        KitchenObj kitchenObj = kitchenObjectTranform.GetComponent<KitchenObj>();
        kitchenObj.SetKitchenObjParent(kitchenObjParent);
        return kitchenObj;
    }
}
