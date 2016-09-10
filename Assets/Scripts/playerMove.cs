using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

    public float moveSpeed = 6f;
    private Vector3 mousePos;
    private Rigidbody2D theRigidBody;

    // Use this for initialization
    void Start () {
        theRigidBody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        theRigidBody.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
    }
}
