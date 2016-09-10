using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public GameObject bulletObj;
    bool fire;
    private bullet bScript;

	// Use this for initialization
	void Start () {
        bScript = (bullet) FindObjectOfType(typeof(bullet));
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("fire");
            GameObject iBullet = (GameObject) Instantiate(bulletObj, transform.position, Quaternion.identity);
            //iBullet.Find("theRigidBody").GetComponent<Rigidbody2D>().velocity = new Vector2()
            bScript.theRigidBody.velocity = new Vector2(bScript.bulletSpeed, bScript.bulletSpeed);
        }
	}
}
