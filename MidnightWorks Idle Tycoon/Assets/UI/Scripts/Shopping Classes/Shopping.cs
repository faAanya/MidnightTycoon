using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : MonoBehaviour
{
    public UIView uIView;
    public List<ShopSO> products;
    public Button button;

    public int size;

    public void Start()
    {

        for (int i = 0; i < products.Count; i++)
        {
            GameObject newButton = Instantiate(button.gameObject, transform.position, Quaternion.identity);
            newButton.gameObject.transform.SetParent(gameObject.transform, false);
            int myI = i;
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (uIView.uIModel.CurrentMoney >= products[myI].cost)
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
        uIView.uIController.SpendMoney(shopSO.cost);

    }

    public void LoadData(GameData gameData)
    {
        foreach (var item in gameData.shopsWrapper)
        {
            if (item.placeNameSave == this.GetInstanceID())
            {
                products.Capacity = item.capacitySave;
            }
        }
    }

    public void SaveData(ref GameData gameData)
    {
        ShopsState shopsState = new ShopsState();
        shopsState.capacitySave = products.Count;
        shopsState.placeNameSave = this.GetInstanceID();
        gameData.shopsWrapper.Add(shopsState);

    }
}
