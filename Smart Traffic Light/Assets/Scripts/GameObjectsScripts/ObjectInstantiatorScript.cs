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

    void Start()
    {
        isCarsCanSpawn = true;
        isPeopleCanSpawn = true;
    }

    void Update()
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

    void InstantiateCar()
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

    void InstantiatePerson()
    {
        
    }

    IEnumerator SpawnCarsDelay()
    {
        var minSecondsDelay = 3;
        var maxSecondsDelay = 8;
        var realtimeDelay = Random.Range(minSecondsDelay, maxSecondsDelay);

        isCarsCanSpawn = false;

        yield return new WaitForSeconds(realtimeDelay);

        isCarsCanSpawn = true;
    }
}
