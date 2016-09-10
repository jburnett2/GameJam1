using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    public float moveSpeed = 0.1f;
    private Rigidbody2D theRigidBody;
    private Transform target;                               //Transform to attempt to move toward each turn.
    private bool hasSeenTarget = true;
    int xDir = 0;
    int yDir = 0;
    int damp = 1;
    int curHealth = 3;
    private Vector2 rayDirection;
    int x = 0;


    public GameObject EnemyObj;
    private enemies eScript;




    // Use this for initialization
    void Start()
    {
        eScript = GetComponent<enemies>();
        theRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;  //Find the player object
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth <= 0)
        {
            GameObject.Destroy(gameObject);
        }

        if (hasSeenTarget)
        {
            var rotationAngle = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationAngle, Time.deltaTime * damp);

            yDir = target.position.y > transform.position.y ? 1 : -1;
            xDir = target.position.x > transform.position.x ? 1 : -1;


            theRigidBody.velocity = new Vector2(xDir * moveSpeed, yDir * moveSpeed);

            if (x >= 10)
            {
                GameObject iEnemy = (GameObject)Instantiate(EnemyObj, transform.position, Quaternion.identity);
                x = 0;
            }
            else
            { x++; }
            //Debug.Log(target.position);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            curHealth = curHealth - 1;
            GameObject.Destroy(gameObject);
        }
    }

}
