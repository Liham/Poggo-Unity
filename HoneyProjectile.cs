using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyProjectile : MonoBehaviour {

    public float speed;
    public float honeyTime = 0f;
    public float honeyDestroyTime;

    private Transform player;
    //private Vector2 target;

	// Use this for initialization
	void Start () {
		
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //target = new Vector2(player.position.x, player.position.y);

    }
	
	// Update is called once per frame
	void Update () {

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        /*if(transform.position.x == target.x && transform.position.y == target.y) {
            DestroyHoneyProjectile();
        }*/

        if(honeyTime == honeyDestroyTime) {

            DestroyHoneyProjectile();

        } else {

            honeyTime++;
        }

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            DestroyHoneyProjectile();
        }
    }

    void DestroyHoneyProjectile() {

        Destroy(gameObject);
    }
}
