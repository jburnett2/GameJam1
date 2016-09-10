using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

   
    public Rigidbody2D theRigidBody;

	// Use this for initialization
	void Start () {
        theRigidBody = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
       // theRigidBody.velocity = theRigidBody.velocity * bulletSpeed;
	}

   
}
