using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    public GameObject[] heroes;

    public GameObject playerSpawnFX;

    public Transform playerSpawnPoint;

    public float spawnPlayerTime = 0.2f;

    private void Awake()
    {
        MakeSingleton();
    }


    private void Start()
    {
        //SpawnPlayer();
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void SpawnPlayer()
    {
        StartCoroutine(SpawnPlayerAfterDelay());
    }

    IEnumerator SpawnPlayerAfterDelay()
    {
        playerSpawnFX.SetActive(true);


        yield return new WaitForSeconds(spawnPlayerTime);

        Instantiate(heroes[GameManager.instance.selectedHeroIndex], playerSpawnPoint.position, Quaternion.Euler(0.0f,180.0f,0.0f));
    }
}
