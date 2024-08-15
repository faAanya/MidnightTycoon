using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : MonoBehaviour, IDataPersistence
{
    public UIView uIView;
    public List<ShopSO> products;
    public Button button;
    public GameObject buttonWrapper;

    public int size;
    public int shopIndex;

    public void Start()
    {

        for (int i = 0; i < products.Count; i++)
        {
            GameObject newButton = Instantiate(button.gameObject, transform.position, Quaternion.identity);
            newButton.gameObject.transform.SetParent(buttonWrapper.gameObject.transform, false);
            int myI = i;
            newButton.GetComponent<Button>().interactable = !products[i].isBought;

            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (uIView.uIModel.CurrentMoney >= products[myI].cost && !products[myI].isBought)
                {
                    Buy(products[myI]);
                    // products.RemoveAt(myI);
                    newButton.GetComponent<Button>().interactable = false;
                }
            });
            newButton.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = products[myI].productName;
            newButton.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = products[myI].cost.ToString();
        }
    }

    public virtual void Buy(ShopSO shopSO)
    {
        int result = uIView.uIModel.CurrentMoney - shopSO.cost;
        if (result > 0)
        {
            uIView.uIController.SpendMoney(shopSO.cost);
            shopSO.isBought = true;
        }
    }

    public void LoadData(GameData gameData)
    {
        // for (int i = 0; i < products.Count; i++)
        // {
        //     for (int j = 0; j < gameData.shopsWrapper.Count; j++)
        //     {
        //         if (products[i].name == gameData.shopsWrapper[j].productName)
        //         {
        //             products[i].isBought = gameData.shopsWrapper[j].isBought;
        //         }
        //     }

        // }

    }

    public void SaveData(ref GameData gameData)
    {
        for (int i = 0; i < products.Count; i++)
        {
            ShopSOWrapper shopSOWrapper = new ShopSOWrapper();
            shopSOWrapper.productName = products[i].name;
            shopSOWrapper.isBought = products[i].isBought;
            gameData.shopsWrapper[shopIndex].Add(shopSOWrapper);
        }

    }
}
