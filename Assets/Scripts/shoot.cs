using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {

    public GameObject bullet;
    bool fire;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (fire)
        {
            GameObject iBullet = (GameObject) Instantiate(bullet, transform.position, Quaternion.identity);
            iBullet.
        }
	}
}
