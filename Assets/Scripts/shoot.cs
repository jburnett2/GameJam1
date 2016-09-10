using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public float bulletSpeed = 20f;

    public GameObject bulletObj;
    bool fire;
    private bullet bScript;
    private playerMove player;
    private Vector2 heading;
    private Vector2 mPos2;
    private Vector2 direction;
   

    // Use this for initialization
    void Start () {
        //bScript = (bullet) FindObjectOfType(typeof(bullet));
        bScript = GetComponent<bullet>();
        player = GetComponent<playerMove>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("fire");
            mPos2 = new Vector2(player.mousePos.x, player.mousePos.y);
            heading = mPos2 - player.theRigidBody.position;
            direction = heading / heading.magnitude;
            //Debug.Log(direction);
            GameObject iBullet = (GameObject) Instantiate(bulletObj, transform.position, Quaternion.identity);
            Rigidbody2D rb = iBullet.GetComponent<Rigidbody2D>();
            rb.velocity += direction * bulletSpeed;
        }
	}
}
