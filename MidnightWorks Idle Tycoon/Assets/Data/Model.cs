using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Model", menuName = "Model", order = 0)]
public class Model : ScriptableObject
{
    public event Action<float> OnMoneyChanged, OnCourseChanged;
    public event Action<int> OnHertsChanged;
    public float currentMoney, currentCourse;
    public int currentHearts;
}