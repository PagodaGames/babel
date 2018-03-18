using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockFloor : MonoBehaviour {

    private GameObject floorSpawner;
    private floorSpawner _gameMaster;
    public int floorNb;
    private Rigidbody rb;
    public float yCible;
    //private groundColor gColor;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        _gameMaster = GameObject.Find("_gameMaster").GetComponent<floorSpawner>();
        //gColor = GetComponent<groundColor>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.transform.position.y < yCible)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.transform.position = new Vector3(rb.transform.position.x, yCible, rb.transform.position.z);
        }
        //if (floorNb != _gameMaster.floorNbr - 1) gColor.clicked = false;
        if (rb.transform.position.y < 4*(_gameMaster.floorNbr-5))
        {
            Destroy(this.gameObject);
        }
    }
}
