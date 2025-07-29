using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjSO kitchenObjectSO;
    


    public override void Interact(Player player)
    {
        if(!HasKitchenObj())
        {
            if(player.HasKitchenObj())
            {
                player.GetKitchenObj().SetKitchenObjParent(this);
            }      
        }
        else
        {
            if (!player.HasKitchenObj())
            {
                GetKitchenObj().SetKitchenObjParent(player);
            }
        }
    }

  
}
