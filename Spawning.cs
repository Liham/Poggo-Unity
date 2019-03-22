using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    private int RandX;
    private int RandY;
    private Vector3 randPosition;
    private Vector3 randRayPosition;
    public Transform playerPrefab;

    private float correctDist;

    private bool spawned = false;

   
    void Start()
    {
        while (!spawned)
        {
            RandX = Random.Range(-64, 64);
            RandY = Random.Range(-36, 36);
            randPosition = new Vector3(RandX, RandY, 0);
            randRayPosition = new Vector3(RandX, RandY, -10);

            RaycastHit checkSpawnPoint;
            Ray checkingRay = new Ray(randRayPosition, Vector3.forward);

            if (Physics.Raycast(checkingRay, out checkSpawnPoint))
            {
                Debug.DrawRay(randRayPosition, Vector3.forward, Color.red, 1000000);
                if (checkSpawnPoint.distance > 10)
                {
                    Debug.Log("Hit the plane");
                    Instantiate(playerPrefab, randPosition, Quaternion.identity);
                    spawned = true;
                }
                else
                {
                    Debug.Log("Hit the mesh");
                }
            }
        }
        
    }


    void Update()
    {


    }

}
