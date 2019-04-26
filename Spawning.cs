using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    private int RandX;
    private int RandY;
    private int numHits;

    private Vector2 randPosition;
    private Vector2 castPosition;
    private Vector2 correctSpawn;

    public Transform playerPrefab;

    private bool spawned = false;
    private bool doneCasting = false;

   
    public void Spawn()
    {
        while (!spawned)
        {
            RandX = Random.Range(-64, 64);
            RandY = Random.Range(-36, 36);
            randPosition = new Vector2(RandX, RandY);
            castPosition = randPosition;
            correctSpawn = randPosition;
            numHits = 0;

            while (!doneCasting)
            {
                RaycastHit2D checkSpawnPoint = Physics2D.Raycast(castPosition, Vector2.up, 150f);
                Debug.Log(checkSpawnPoint.point);

                if (checkSpawnPoint.collider != null)
                {
                    numHits++;
                    castPosition.x = checkSpawnPoint.point.x;
                    castPosition.y = checkSpawnPoint.point.y + 0.1F;
                }
                else
                {
                    Debug.Log("Reached the else statement.");
                    doneCasting = true;
                }
            }

            if (numHits % 2 == 1)
            {
                Debug.Log("reached the odd check");
                Instantiate(playerPrefab, correctSpawn, Quaternion.identity);
                spawned = true;
            }


        }
        
        
    }


    void Update()
    {


    }

}
