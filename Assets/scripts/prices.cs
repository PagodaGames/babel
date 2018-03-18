using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prices : MonoBehaviour {

    private GameObject floorSpawner;
    public int priceFloor;
    public int priceMine;
    public int priceConverter;

    public Text priceMineText;
    private GameObject buildSelector;

    void Start()
    {
        buildSelector = GameObject.Find("selectBuild");
        floorSpawner = GameObject.Find("_gameMaster");
    }

    // Update is called once per frame
    void Update () {
        priceFloor = Mathf.RoundToInt(Mathf.Pow(7 * floorSpawner.transform.GetComponent<floorSpawner>().floorNbr, 2f));
        priceMine = Mathf.RoundToInt(Mathf.Pow(3 * floorSpawner.transform.GetComponent<floorSpawner>().floorNbr, 2f));
        priceConverter = Mathf.RoundToInt(Mathf.Pow(2 * floorSpawner.transform.GetComponent<floorSpawner>().floorNbr, 2f));

        priceMineText.text = (buildSelector.GetComponent<selectBuilding>().mineSelected ? priceMine : priceConverter)+"";
    }
}
