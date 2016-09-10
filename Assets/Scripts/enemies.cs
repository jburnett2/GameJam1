using UnityEngine;
using System.Collections;

public class enemies : MonoBehaviour {


    public float moveSpeed = 4f;
    private Rigidbody2D theRigidBody;
    private Transform target;                               //Transform to attempt to move toward each turn.
    private bool hasSeenTarget = true;
    int xDir = 0;
    int yDir = 0;
    int damp = 1;
    int curHealth = 3;
    private Vector2 rayDirection;

    // Use this for initialization
    void Start () {
        theRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;  //Find the player object
    }
	
	// Update is called once per frame
	void Update () {

        rayDirection = target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, 10);
        Debug.Log(hit);

        if (hit.collider == target)
        {
            hasSeenTarget = true;
        }

           
        

        if (curHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }

        // theRigidBody.rotation = Quaternion.LookRotation(target.position);
        //transform.rotation = Quaternion.LookRotation(targetPos.forward, target.position - transform.position);
        //transform.LookAt(target);

        if (hasSeenTarget)
        {
            var rotationAngle = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * damp);

            yDir = target.position.y > transform.position.y ? 1 : -1;
            xDir = target.position.x > transform.position.x ? 1 : -1;


            theRigidBody.velocity = new Vector2(xDir * moveSpeed, yDir * moveSpeed);
            //Debug.Log(target.position);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            GameObject.Destroy(gameObject);
            curHealth = curHealth - 1;
        }
    }

}
