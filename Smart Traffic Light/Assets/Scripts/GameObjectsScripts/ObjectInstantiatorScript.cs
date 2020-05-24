using Assets.Scripts.Models;
using System.Collections;
using UnityEngine;

public class ObjectInstantiatorScript : MonoBehaviour
{
    public LevelDataScript levelData;

    public GameObject[] carSpawnPoints;
    public GameObject[] peopleSpawnPoints;

    public GameObject[] carPrefabs;
    public GameObject[] humanPrefabs;

    private bool isCarsCanSpawn;
    private bool isPeopleCanSpawn;

    private void Start()
    {
        isCarsCanSpawn = true;
        isPeopleCanSpawn = true;
    }

    private void Update()
    {
        if (CarsParameters.CurrentAmount > levelData.currentCarsAmountOnLevel && isCarsCanSpawn)
        {
            InstantiateCar();
        }

        if (PeopleParameters.CurrentAmount > levelData.currentPeopleAmountOnLevel && isPeopleCanSpawn)
        {
            InstantiatePerson();
        }
    }

    private void InstantiateCar()
    {
        var randomSpawnPointIndex = Random.Range(0, carSpawnPoints.Length);
        var randomSpawnPoint = carSpawnPoints[randomSpawnPointIndex];

        var randomCarIndex = Random.Range(0, carPrefabs.Length);
        var randomCar = carPrefabs[randomCarIndex];

        switch (randomSpawnPointIndex)
        {
            case 0:
                if (!carSpawnPoints[0].GetComponent<SpawnCheck>().isSpawnEmpty)
                {
                    return;
                }

                randomCar.transform.position = 
                    new Vector3(randomSpawnPoint.gameObject.transform.position.x, randomSpawnPoint.transform.position.y);
                randomCar.transform.eulerAngles = new Vector3(0, 0, -90);

                break;

            case 1:
                if (!carSpawnPoints[1].GetComponent<SpawnCheck>().isSpawnEmpty)
                {
                    return;
                }

                randomCar.transform.position =
                    new Vector3(randomSpawnPoint.gameObject.transform.position.x, randomSpawnPoint.transform.position.y);
                randomCar.transform.eulerAngles = new Vector3(0, 0, 90);

                break;
        }

        var newCar = Instantiate(randomCar);
        newCar.name = randomCar.name;

        levelData.currentCarsAmountOnLevel++;

        StartCoroutine(SpawnCarsDelay());
    }

    private void InstantiatePerson()
    {
        var randomSpawnPointIndex = Random.Range(0, peopleSpawnPoints.Length);
        var randomSpawnPoint = peopleSpawnPoints[randomSpawnPointIndex];

        var randomPersonIndex = Random.Range(0, humanPrefabs.Length);
        var randomPerson = humanPrefabs[randomPersonIndex];

        switch (randomSpawnPointIndex)
        {
            case 0:
                if (!peopleSpawnPoints[0].GetComponent<SpawnCheck>().isSpawnEmpty)
                {
                    return;
                }

                randomPerson.transform.position =
                    new Vector3(randomSpawnPoint.gameObject.transform.position.x, randomSpawnPoint.transform.position.y);
                randomPerson.transform.eulerAngles = new Vector3(0, 0, -90);
                randomPerson.GetComponent<PedestrianScript>().moveTo = Vector3.up;

                break;

            case 1:
                if (!peopleSpawnPoints[1].GetComponent<SpawnCheck>().isSpawnEmpty)
                {
                    return;
                }

                randomPerson.transform.position =
                    new Vector3(randomSpawnPoint.gameObject.transform.position.x, randomSpawnPoint.transform.position.y);
                randomPerson.transform.eulerAngles = new Vector3(0, 0, -90);
                randomPerson.GetComponent<PedestrianScript>().moveTo = Vector3.up;

                break;

            case 2:
                if (!peopleSpawnPoints[2].GetComponent<SpawnCheck>().isSpawnEmpty)
                {
                    return;
                }

                randomPerson.transform.position =
                    new Vector3(randomSpawnPoint.gameObject.transform.position.x, randomSpawnPoint.transform.position.y);
                randomPerson.transform.eulerAngles = new Vector3(0, 0, 90);
                randomPerson.GetComponent<PedestrianScript>().moveTo = Vector3.up;

                break;

            case 3:
                if (!peopleSpawnPoints[3].GetComponent<SpawnCheck>().isSpawnEmpty)
                {
                    return;
                }

                randomPerson.transform.position =
                    new Vector3(randomSpawnPoint.gameObject.transform.position.x, randomSpawnPoint.transform.position.y);
                randomPerson.transform.eulerAngles = new Vector3(0, 0, 90);
                randomPerson.GetComponent<PedestrianScript>().moveTo = Vector3.up;

                break;
        }

        var newPerson = Instantiate(randomPerson);
        newPerson.name = randomPerson.name;

        levelData.currentPeopleAmountOnLevel++;

        StartCoroutine(SpawnPersonDelay());
    }

    private IEnumerator SpawnCarsDelay()
    {
        var minSecondsDelay = 3;
        var maxSecondsDelay = 8;
        var realtimeDelay = Random.Range(minSecondsDelay, maxSecondsDelay);

        isCarsCanSpawn = false;

        yield return new WaitForSeconds(realtimeDelay);

        isCarsCanSpawn = true;
    }

    private IEnumerator SpawnPersonDelay()
    {
        var minSecondsDelay = 2;
        var maxSecondsDelay = 5;
        var realtimeDelay = Random.Range(minSecondsDelay, maxSecondsDelay);

        isPeopleCanSpawn = false;

        yield return new WaitForSeconds(realtimeDelay);

        isPeopleCanSpawn = true;
    }
}
