using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

    public float moveSpeed = 6f;
    public Vector3 mousePos;
    public Rigidbody2D theRigidBody;

    // Use this for initialization
    void Start () {
        theRigidBody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        //player points towards mouse
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        //player movement
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        theRigidBody.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);

    }
}
