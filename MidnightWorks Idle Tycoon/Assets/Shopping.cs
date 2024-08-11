using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : MonoBehaviour
{
    public UIView uIView;
    public ShopSO[] products;
    public Button buttun;

    private void Start()
    {
        for (int i = 0; i < products.Length; i++)
        {
            GameObject newButton = Instantiate(buttun.gameObject, transform.position, Quaternion.identity);
            newButton.gameObject.transform.SetParent(gameObject.transform, false);
            int myI = i;
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                if (uIView.uIModel.CurrentMoney >= products[myI].cost)
                {
                    Buy(products[myI]);

                }
            });
        }
    }

    public void Buy(ShopSO shopSO)
    {

        //todo: write buy code

        uIView.uIController.SpendMoney(shopSO.cost);

    }

}
