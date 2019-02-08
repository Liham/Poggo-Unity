using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerBeeScript : MonoBehaviour {

    public float speed;
    public float health;
    public float stopTime = 0f;
    public float chargeStartTime;
    public float chargingDistance;
    
    private Transform player;
    private Vector2 target;


	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < chargingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                if (stopTime == chargeStartTime)
                {
                    target = new Vector2(player.position.x, player.position.y);
                    stopTime = 0f;

                }
                else
                {
                    stopTime++;
                }

            }
        }
    }
}
