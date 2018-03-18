using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class floorSpawner : MonoBehaviour {

    public int floorNbr = 0;
    public GameObject floorToSpawn;
    public GameObject columnToSpawn;
    public float smoothTime = 0.3F;
    private float yVelocity = 0.0F;
    private Vector3 yVelocity3;
    private bool spawn;
    public Button yourButton;
    public Text floorToPrint;
    private GameObject _gameMaster;
    public GameObject ground;
    private ressourcesHandler rHandle;

    // Use this for initialization
    void Start () {
        floorNbr = 0;
        _gameMaster = GameObject.Find("_gameMaster");
        rHandle = _gameMaster.transform.GetComponent<ressourcesHandler>();

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject objet = Instantiate(floorToSpawn, new Vector3(2f * i, 4f * floorNbr + 15 + (i+j), 2f * j), Quaternion.identity);
                objet.GetComponent<blockFloor>().yCible = 4 * floorNbr;
                objet.transform.GetComponent<blockFloor>().floorNb = floorNbr;
            }
        }

        floorToPrint.text = "" + floorNbr;
        floorNbr++;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("a")) TaskOnClick();

        int price = _gameMaster.transform.GetComponent<prices>().priceFloor;
        // fait spawner un étage, augmente le numero d'étage, retire le gold necessaire si c'est possible, met à jour l'affichage
        if (spawn && (rHandle.gold >= price) && (rHandle.wood >= price) && (rHandle.sand >= price) && (rHandle.rock >= price))
        {
            rHandle.gold -= price;
            rHandle.wood -= price;
            rHandle.sand -= price;
            rHandle.rock -= price;

            invokeFloor();
        }
        spawn = false;



        float newPosition = Mathf.SmoothDamp(Camera.main.transform.position.y, 4*floorNbr+8, ref yVelocity, smoothTime);
        Camera.main.transform.position = new Vector3(-10, newPosition, -10);
    }

    void TaskOnClick()
    {
        spawn = true;
    }

    void invokeFloor()
    {
        /*for (int i = 0; i < 25; i++)
        {
            gameController.GetComponent<builder>().occuped[i] = false;
        }
        ressourcesHandler.transform.GetComponent<ressourcesHandler>().gold += -ressourcesHandler.transform.GetComponent<prices>().priceFloor;
        // ressourcesHandler.transform.GetComponent<ressourcesHandler>().wood += (ressourcesHandler.transform.GetComponent<ressourcesHandler>().wood <= 0) ? 0 : -ressourcesHandler.transform.GetComponent<prices>().priceFloor;
        */
        for (int i = 0; i < 4; i++)
        {
            GameObject objet1 = Instantiate(columnToSpawn, new Vector3(-1.32f, 4f * (floorNbr - 1) + 2 * (i + 1), -1.32f), Quaternion.identity);
            objet1.GetComponent<blockFloor>().yCible = 4 * (floorNbr - 1) + 0.6875f + i - 1 * 0.875f;

            objet1 = Instantiate(columnToSpawn, new Vector3(9.32f, 4f * (floorNbr - 1) + 2 * (i + 1), -1.32f), Quaternion.identity);
            objet1.GetComponent<blockFloor>().yCible = 4 * (floorNbr - 1) + 0.6875f + i - 1 * 0.875f;

            objet1 = Instantiate(columnToSpawn, new Vector3(9.32f, 4f * (floorNbr - 1) + 2 * (i + 1), 9.32f), Quaternion.identity);
            objet1.GetComponent<blockFloor>().yCible = 4 * (floorNbr - 1) + 0.6875f + i - 1 * 0.875f;

            objet1 = Instantiate(columnToSpawn, new Vector3(-1.32f, 4f * (floorNbr - 1) + 2 * (i + 1), 9.32f), Quaternion.identity);
            objet1.GetComponent<blockFloor>().yCible = 4 * (floorNbr - 1) + 0.6875f + i - 1 * 0.875f;
        }

        GameObject objet = Instantiate(ground, new Vector3(4, 4f * floorNbr + 9 , 4), Quaternion.identity);
        objet.GetComponent<blockFloor>().yCible = 4 * (floorNbr - 1) + 0.6875f + 3 * 0.875f;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject objet2 = Instantiate(floorToSpawn, new Vector3(2*i, 4f * floorNbr + 10 + (i + j), 2*j), Quaternion.identity);
                objet2.GetComponent<blockFloor>().yCible = 4 * floorNbr;
                objet2.transform.GetComponent<blockFloor>().floorNb = floorNbr;
            }
        }
        
        
        
        
        floorToPrint.text = "" + floorNbr;
        floorNbr++;
    }

}
