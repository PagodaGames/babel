using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectBuilding : MonoBehaviour {

    public GameObject mine;
    public GameObject converter;
    public GameObject toBuild;

    public Button mineButton;

    private int from;
    public int to;

    public Button fromGold;
    public Button fromWood;
    public Button fromSand;
    public Button fromRock;

    public Button toGold;
    public Button toWood;
    public Button toSand;
    public Button toRock;

    public Text mineText;

    public bool mineSelected = true;

	// Use this for initialization
	void Start () {
        toBuild = mine;

        mineButton.onClick.AddListener(switchMine);

        fromGold.onClick.AddListener(isFromGold);
        fromWood.onClick.AddListener(isFromWood);
        fromSand.onClick.AddListener(isFromSand);
        fromRock.onClick.AddListener(isFromRock);

        toGold.onClick.AddListener(istoGold);
        toWood.onClick.AddListener(istoWood);
        toSand.onClick.AddListener(istoSand);
        toRock.onClick.AddListener(istoRock);
    }
	
    void switchMine()
    {
        mineSelected = !mineSelected;
    }

    void isFromGold()
    {
        from = 0;

        fromGold.image.color = Color.gray;
        fromWood.image.color = Color.white;
        fromRock.image.color = Color.white;
        fromSand.image.color = Color.white;
    }
    void isFromWood()
    {
        from = 1;

        fromWood.image.color = Color.gray;
        fromGold.image.color = Color.white;
        fromRock.image.color = Color.white;
        fromSand.image.color = Color.white;
    }
    void isFromSand()
    {
        from = 2;

        fromSand.image.color = Color.gray;
        fromWood.image.color = Color.white;
        fromRock.image.color = Color.white;
        fromGold.image.color = Color.white;
    }
    void isFromRock()
    {
        from = 3;

        fromRock.image.color = Color.gray;
        fromWood.image.color = Color.white;
        fromGold.image.color = Color.white;
        fromSand.image.color = Color.white;
    }

    void istoGold()
    {
        to = 0;

        toGold.image.color = Color.gray;
        toWood.image.color = Color.white;
        toRock.image.color = Color.white;
        toSand.image.color = Color.white;
    }
    void istoWood()
    {
        to = 1;

        toWood.image.color = Color.gray;
        toGold.image.color = Color.white;
        toRock.image.color = Color.white;
        toSand.image.color = Color.white;
    }
    void istoSand()
    {
        to = 2;

        toSand.image.color = Color.gray;
        toWood.image.color = Color.white;
        toRock.image.color = Color.white;
        toGold.image.color = Color.white;
    }
    void istoRock()
    {
        to = 3;

        toRock.image.color = Color.gray;
        toWood.image.color = Color.white;
        toGold.image.color = Color.white;
        toSand.image.color = Color.white;
    }

    // Update is called once per frame
    void Update () {
        toBuild = mineSelected ? mine : converter;
        toBuild.GetComponent<converterBehaviour>().from = from;
        toBuild.GetComponent<converterBehaviour>().to = to;
        mineText.text = (mineSelected) ? "mine" : "!mine";
    }
}
