using UnityEngine;

[CreateAssetMenu(fileName = "ShopSO", menuName = "ShopSO", order = 0)]
public class ShopSO : ScriptableObject
{
    public float cost;
    public GameObject product;
    public string productName;
}