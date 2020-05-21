using Assets.Scripts.Models;
using System.Collections;
using UnityEngine;

public class TrafficLightGameObject : MonoBehaviour
{
    public LevelDataScript levelData;

    public GameObject redLightBlocker;
    public GameObject yellowLightBlocker;
    public GameObject greenLightBlocker;

    public TrafficLightSignal startSignal;

    public GameobjectsWaitingCars[] gameobjectsWaitingCars;
    private WaitingCarsParameters thisWaitingCarsParameters;

    public Collider2D[] waitingCarsStoplineColliders;

    [HideInInspector]
    public TrafficLight trafficLightLogic;

    private bool isSignalCoroutineEnd;
    private TrafficLightSignal previousSignal;
    private int delay;

    private void Awake()
    {
        thisWaitingCarsParameters = new WaitingCarsParameters()
        {
            WaitingCarsAmount = 0
        };

        trafficLightLogic = new TrafficLight(new WaitingPeopleParameters(), thisWaitingCarsParameters)
        {
            TrafficLightSignal = startSignal
        };

        isSignalCoroutineEnd = true;
    }

    private void Update()
    {
        if (isSignalCoroutineEnd)
        {
            GetCarsAmount();

            switch (trafficLightLogic.TrafficLightSignal)
            {
                case TrafficLightSignal.RedLight:
                    StartCoroutine(RedSignal());
                    break;

                case TrafficLightSignal.YellowLight:
                    StartCoroutine(YellowSignal());
                    break;

                case TrafficLightSignal.GreenLight:
                    StartCoroutine(GreenSignal());
                    break;

                default:
                    throw new System.Exception("Unrecognized traffic light signal");
            }
        }
    }

    private IEnumerator RedSignal()
    {
        isSignalCoroutineEnd = false;

        VisualizeTrafficLightSignal(trafficLightLogic.TrafficLightSignal);
        delay = trafficLightLogic.CalculateDelay(levelData.levelNumber);

        Debug.Log($"{gameObject.name} : {trafficLightLogic.TrafficLightSignal} : {delay}s");

        yield return new WaitForSecondsRealtime(delay);

        previousSignal = TrafficLightSignal.RedLight;
        trafficLightLogic.TrafficLightSignal = TrafficLightSignal.YellowLight;
        isSignalCoroutineEnd = true;
    }

    private IEnumerator YellowSignal()
    {
        isSignalCoroutineEnd = false;

        VisualizeTrafficLightSignal(trafficLightLogic.TrafficLightSignal);
        delay = trafficLightLogic.CalculateDelay(levelData.levelNumber);

        Debug.Log($"{gameObject.name} : {trafficLightLogic.TrafficLightSignal} : {delay}s");

        yield return new WaitForSecondsRealtime(delay);

        if (previousSignal == TrafficLightSignal.RedLight)
        {
            trafficLightLogic.TrafficLightSignal = TrafficLightSignal.GreenLight;
        }
        else //if (previousSignal == TrafficLightSignal.GreenLight)
        {
            trafficLightLogic.TrafficLightSignal = TrafficLightSignal.RedLight;
        }
        isSignalCoroutineEnd = true;
    }

    private IEnumerator GreenSignal()
    {
        isSignalCoroutineEnd = false;
        SetCarColliderStatus(false);

        VisualizeTrafficLightSignal(trafficLightLogic.TrafficLightSignal);
        delay = trafficLightLogic.CalculateDelay(levelData.levelNumber);

        Debug.Log($"{gameObject.name} : {trafficLightLogic.TrafficLightSignal} : {delay}s");

        yield return new WaitForSecondsRealtime(delay);

        previousSignal = TrafficLightSignal.GreenLight;
        trafficLightLogic.TrafficLightSignal = TrafficLightSignal.YellowLight;
        SetCarColliderStatus(true);
        isSignalCoroutineEnd = true;
    }

    /// <summary>
    /// Activates and deactivates necessary signal blockers on traffic light
    /// </summary>
    /// <param name="trafficLightSignal">Setted traffic light signal</param>
    private void VisualizeTrafficLightSignal(TrafficLightSignal trafficLightSignal)
    {
        switch (trafficLightSignal)
        {
            case TrafficLightSignal.RedLight:
                redLightBlocker.SetActive(false);
                yellowLightBlocker.SetActive(true);
                greenLightBlocker.SetActive(true);
                break;

            case TrafficLightSignal.YellowLight:
                redLightBlocker.SetActive(true);
                yellowLightBlocker.SetActive(false);
                greenLightBlocker.SetActive(true);
                break;

            case TrafficLightSignal.GreenLight:
                redLightBlocker.SetActive(true);
                yellowLightBlocker.SetActive(true);
                greenLightBlocker.SetActive(false);
                break;
        }
    }
    
    /// <summary>
    /// Enables or disables car colliders
    /// </summary>
    /// <param name="isEnabled"></param>
    private void SetCarColliderStatus(bool isEnabled)
    {
        foreach (var collider in waitingCarsStoplineColliders)
        {
            collider.enabled = isEnabled;
        }
    }

    /// <summary>
    /// Gets current amount of objects (waiting cars) that are nearby the traffic light
    /// </summary>
    private void GetCarsAmount()
    {
        thisWaitingCarsParameters.WaitingCarsAmount = 0;

        foreach (var gameobjectsWaitingCars in gameobjectsWaitingCars)
        {
            thisWaitingCarsParameters.WaitingCarsAmount += gameobjectsWaitingCars.waitingCarsParameters.WaitingCarsAmount;
        }
    }
}
