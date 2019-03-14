using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    private int playerRandX;
    private int playerRandY;
    private Vector3 randPosition;
    public Transform playerPrefab;

    void Start()
    {
        playerRandX = Random.Range(0, 64);
        playerRandY = Random.Range(0, 36);
        randPosition = new Vector3(playerRandX, playerRandY, 0);

        Instantiate(playerPrefab, randPosition, Quaternion.identity);
    }

}
