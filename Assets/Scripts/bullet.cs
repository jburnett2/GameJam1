﻿using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

   
    public Rigidbody2D theRigidBody;

	// Use this for initialization
	void Start () {
        theRigidBody = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(waitDestroy(5));
       // theRigidBody.velocity = theRigidBody.velocity * bulletSpeed;
	}

    IEnumerator waitDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Destroy(gameObject);
        }
    }

}
