using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjSO kitchenObjectSO;
  
   
    public override void Interact(Player player)
    {
        if(!player.HasKitchenObj())
        {
            KitchenObj.SpawnKitchenObject(kitchenObjectSO, player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
    public override void InteractAlternate(Player player)
    {
      
    }
}
