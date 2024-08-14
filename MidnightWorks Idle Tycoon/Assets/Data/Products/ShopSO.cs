using UnityEngine;



[CreateAssetMenu(fileName = "ShopSO", menuName = "ShopSO", order = 0)]
[System.Serializable]
public class ShopSO : ScriptableObject
{
    public int cost;
    public GameObject product;
    public string productName;
}