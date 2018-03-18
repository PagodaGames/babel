using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundColor : MonoBehaviour {

    // public GameObject floor;
    private Renderer rend;
    public Color grassColor;
    public Color concreteColor;
    private int etage;
    floorSwitcher myParent;
    public bool clicked; 
    public Color highLighted;
    blockFloor scriptNb;
    RaycastHit hit;
    Ray ray;
    bool touched;
    bool click;
    private floorSpawner _gameMaster;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        etage = GetComponent<blockFloor>().floorNb;
        _gameMaster = GameObject.Find("_gameMaster").GetComponent<floorSpawner>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        click = Input.GetMouseButtonDown(0);

        if (click)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            touched = Physics.Raycast(ray, out hit);
        //}

        //Debug.Log(touched);
        if (touched)
        {
            int instance = hit.transform.gameObject.GetInstanceID();
            if (instance == this.gameObject.GetInstanceID()) { clicked = true; }
            else clicked = false;
        }*/

        if (_gameMaster.floorNbr - 1 != etage) clicked = false;

        if (clicked) rend.material.color = new Color(rend.material.color.r / ((etage != 0) ? 1.1f : 1), rend.material.color.g / 1.1f, rend.material.color.b / ((etage != 0) ? 1.1f : 1), rend.material.color.a);
        else if(etage == 0) rend.material.color = grassColor;
        else rend.material.color = concreteColor;
    }

}
