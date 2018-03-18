using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickBlock : MonoBehaviour {

    private Button buildButton;

    public GameObject mine;
    public GameObject converter;
    public bool buildMine;

    private ressourcesHandler gameMaster;
    private prices prices;

    private bool occupied;

    private GameObject buildSelector;

	// Use this for initialization
	void Start () {
        buildButton = GameObject.Find("buildButton").GetComponent<Button>();
        buildButton.onClick.AddListener(TaskOnClick);
        occupied = false;
        gameMaster = GameObject.Find("_gameMaster").GetComponent<ressourcesHandler>();
        prices = GameObject.Find("_gameMaster").GetComponent<prices>();
        buildSelector = GameObject.Find("selectBuild");
    }

    void TaskOnClick()
    {
        if(GetComponent<groundColor>().clicked == true)
        {
            if(!occupied)
            {
                GameObject willBeBuilt = buildSelector.GetComponent<selectBuilding>().toBuild;
                int itsPrice = buildSelector.GetComponent<selectBuilding>().mineSelected ? prices.priceMine : prices.priceConverter;
                int whichTo = buildSelector.GetComponent<selectBuilding>().to;

                switch(whichTo)
                {
                    case 0:
                        if (gameMaster.rock >= itsPrice)
                        {
                            gameMaster.rock -= itsPrice;
                            occupied = true;
                            GetComponent<groundColor>().clicked = false;
                            Instantiate(willBeBuilt, transform.position, Quaternion.identity);
                        }
                        break;
                    case 1:
                        if (gameMaster.gold >= itsPrice)
                        {
                            gameMaster.gold -= itsPrice;
                            occupied = true;
                            GetComponent<groundColor>().clicked = false;
                            Instantiate(willBeBuilt, transform.position, Quaternion.identity);
                        }
                        break;
                    case 2:
                        if (gameMaster.wood >= itsPrice)
                        {
                            gameMaster.wood -= itsPrice;
                            occupied = true;
                            GetComponent<groundColor>().clicked = false;
                            Instantiate(willBeBuilt, transform.position, Quaternion.identity);
                        }
                        break;
                    case 3:
                    default:
                        if (gameMaster.sand >= itsPrice)
                        {
                            gameMaster.sand -= itsPrice;
                            occupied = true;
                            GetComponent<groundColor>().clicked = false;
                            Instantiate(willBeBuilt, transform.position, Quaternion.identity);
                        }
                        break;
                }
            }
        }
    }
	
	// Update is called once per frame
    void Update () {
        Ray ray;
        RaycastHit hit;
        if(Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "carre") { if (!hit.transform.gameObject.GetComponent<clickBlock>().occupied) { hit.transform.gameObject.GetComponent<groundColor>().clicked = true; } } else { if (hit.transform.tag == "Player") { GetComponent<groundColor>().clicked = false; } }
            } //else { GetComponent<groundColor>().clicked = false; }
        }
        if (Input.GetMouseButton(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "carre") {  hit.transform.gameObject.GetComponent<groundColor>().clicked = false; }
            } //else { GetComponent<groundColor>().clicked = false; }
        }
    }
}
