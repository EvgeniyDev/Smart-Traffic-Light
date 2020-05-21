using UnityEngine;
using Assets.Scripts.Models;

public class LevelDataScript : MonoBehaviour
{
    public int levelNumber;

    public int maxPeopleAmount;
    public int maxCarsAmount;
    public int currentPeopleAmountOnLevel;
    public int currentCarsAmountOnLevel;

    private readonly LevelLimits levelLimits = new LevelLimits();

    void Start()
    {
        LevelLimits.MaxCarsAmount = maxCarsAmount;
        LevelLimits.MaxPeopleAmount = maxPeopleAmount;
    }
}
