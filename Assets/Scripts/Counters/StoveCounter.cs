using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;

    private float fryingTimer;
    private void Update()
    {
        if (HasKitchenObj())
        {
            fryingTimer += Time.deltaTime;
            FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObj().GetKitchenObjSO());
            if (fryingTimer > fryingRecipeSO.FryingTimerMax)
            {
                fryingTimer = 0;
                GetKitchenObj().DestorySelf();
                KitchenObj.SpawnKitchenObject(fryingRecipeSO.output, this);
            }
        }
           
    }
    public override void Interact(Player player)
    {
        if (!HasKitchenObj())
        {
            if (player.HasKitchenObj())
            {
                if (HasRecipeWithInput(player.GetKitchenObj().GetKitchenObjSO()))
                {
                    player.GetKitchenObj().SetKitchenObjParent(this);
                    fryingTimer = 0;
                }
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


    private bool HasRecipeWithInput(KitchenObjSO inputkitchenObjectSo)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputkitchenObjectSo);

        return fryingRecipeSO != null;

    }

    private KitchenObjSO GetOutputForInput(KitchenObjSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null)
            return fryingRecipeSO.output;
        else return null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjSO kitchenObjSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == kitchenObjSO)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }
}

