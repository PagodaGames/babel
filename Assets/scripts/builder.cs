using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class builder : MonoBehaviour {

    private GameObject _gameMaster;
    public int minePrice;
    public int converterPrice;
    public bool spawnMine;
    public GameObject mine;
    public GameObject converter;
    [Header("0 : GOLD; 1 : WOOD; 2 : SAND; 3 : ROCK")]
    [Range(0, 3)]
    public int to;
    [Range(0, 3)]
    public int from;
    public bool[] occuped;

    // Use this for initialization
    void Start () {
        
        occuped = new bool[25];
        for (int i = 0; i < 25; i++) occuped[i] = false;
        _gameMaster = GameObject.Find("_gameMaster");
    }


    // Update is called once per frame
    void Update () {
        minePrice = _gameMaster.GetComponent<prices>().priceMine;
        converterPrice = _gameMaster.GetComponent<prices>().priceConverter;

        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(hit.point, hit.point + new Vector3(0, 10, 0), Color.white, 5);
            Debug.DrawRay(hit.point, hit.point + new Vector3(10, 0, 0), Color.red, 5);
            
        }
    }
}
