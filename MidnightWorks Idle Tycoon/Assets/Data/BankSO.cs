using UnityEngine;

[CreateAssetMenu(fileName = "BankSO", menuName = "BankSO", order = 0)]
public class BankSO : ScriptableObject
{
    public UIModel uIModel;
    public float currentMoney, currentCourse;
    public int currentHearts;
    private void Start()
    {
        uIModel = new UIModel();

    }
    public BankSO()
    {

    }
}