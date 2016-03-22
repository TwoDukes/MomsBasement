using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class modularList : IComparable<modularList>
{
    public GameObject item;
    public GameObject place;

    

    public modularList(GameObject newItem, GameObject newPlace)
    {
        item = newItem;
        place = newPlace;
    }

    public int CompareTo(modularList other)
    {
        //not done
        throw new NotImplementedException();
    }
}


public class modularControl : MonoBehaviour {

    GameObject[,] bigTest;

    int iterator = 0;


    List<modularList> big = new List<modularList>();


	// Use this for initialization
	void Start () {
        bigItems();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void bigItems()
    {
        

        foreach (GameObject item in GameObject.FindGameObjectsWithTag("bigChallenge"))
        {
            
        }





        foreach (GameObject place in GameObject.FindGameObjectsWithTag("Mod(big)"))
        {

            

        }

        
    }
}
