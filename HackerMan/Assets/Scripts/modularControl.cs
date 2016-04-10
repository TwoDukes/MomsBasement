using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class modularControl : MonoBehaviour {

    public GameObject[] bigItem, mediumItem, smallItem, objectItem;
    public int mixAmount;
    
    

    void Start()
    {
        
            Big();
            Medium();
            Small();
            Object();
        
    }


    void Big()
    {
      //  print("BIG MOD STARTED");
        GameObject[] bigPlace;
        bool moreItems = false;

        bigPlace = GameObject.FindGameObjectsWithTag("Mod(big)");
        print(bigPlace.Length + " = big places");

        for (int n = mixAmount; n > 0; n--)
        {
            if (bigPlace.Length > bigItem.Length)
            {

                int i = bigPlace.Length;
                System.Random rand = new System.Random();
                while (i > 1)
                {
                    i--;
                    GameObject placeHolder;

                    int j = rand.Next(i);
                    print("Random # = " + j);
                    placeHolder = bigPlace[i];
                    bigPlace[i] = bigPlace[j];
                    bigPlace[j] = placeHolder;
                }


            }
            else
            {
                moreItems = true;
                int i = bigItem.Length;
                System.Random rand = new System.Random();
                while (i > 1)
                {
                    i--;
                    GameObject placeHolder;

                    int j = rand.Next(i);
                    print("Random # = " + j);
                    placeHolder = bigItem[i];
                    bigItem[i] = bigItem[j];
                    bigItem[j] = placeHolder;
                }


            }
        }
        //print("PICKED BIG");

        if (moreItems)
        {
            //print(bigPlace.Length + " number of big places");
            for(int x = (bigPlace.Length - 1); x >= 0; x--)
            {
                bigPlace[x].GetComponent<modPlace>().SpawnChallenge(bigItem[x]);
            }
        }
        else
        {
           // print(bigItem.Length + " number of big items");
            for (int x = (bigItem.Length - 1); x >= 0; x--)
            {
                bigPlace[x].GetComponent<modPlace>().SpawnChallenge(bigItem[x]);
            }
        }
        //print("PLACED BIG");


    }

    void Medium()
    {
        GameObject[] mediumPlace;
        bool moreItems = false;

        mediumPlace = GameObject.FindGameObjectsWithTag("Mod(big)");
        print(mediumPlace.Length + " = big places");

        for (int n = mixAmount; n > 0; n--)
        {
            if (mediumPlace.Length > bigItem.Length)
            {

                int i = mediumPlace.Length;
                System.Random rand = new System.Random();
                while (i > 1)
                {
                    i--;
                    GameObject placeHolder;

                    int j = rand.Next(i);
                    print("Random # = " + j);
                    placeHolder = mediumPlace[i];
                    mediumPlace[i] = mediumPlace[j];
                    mediumPlace[j] = placeHolder;
                }


            }
            else
            {
                moreItems = true;
                int i = bigItem.Length;
                System.Random rand = new System.Random();
                while (i > 1)
                {
                    i--;
                    GameObject placeHolder;

                    int j = rand.Next(i);
                    print("Random # = " + j);
                    placeHolder = mediumItem[i];
                    mediumItem[i] = mediumItem[j];
                    mediumItem[j] = placeHolder;
                }


            }
        }

        if (moreItems)
        {
            for (int x = (mediumPlace.Length - 1); x >= 0; x--)
            {
                mediumPlace[x].GetComponent<modPlace>().SpawnChallenge(mediumItem[x]);
            }
        }
        else
        {
            for (int x = (mediumItem.Length - 1); x >= 0; x--)
            {
                mediumPlace[x].GetComponent<modPlace>().SpawnChallenge(mediumItem[x]);
            }
        }
    }

    void Small()
    {
        GameObject[] smallPlace;
        bool moreItems = false;

        smallPlace = GameObject.FindGameObjectsWithTag("Mod(big)");
        print(smallPlace.Length + " = big places");

        for (int n = mixAmount; n > 0; n--)
        {
            if (smallPlace.Length > bigItem.Length)
            {

                int i = smallPlace.Length;
                System.Random rand = new System.Random();
                while (i > 1)
                {
                    i--;
                    GameObject placeHolder;

                    int j = rand.Next(i);
                    print("Random # = " + j);
                    placeHolder = smallPlace[i];
                    smallPlace[i] = smallPlace[j];
                    smallPlace[j] = placeHolder;
                }


            }
            else
            {
                moreItems = true;
                int i = bigItem.Length;
                System.Random rand = new System.Random();
                while (i > 1)
                {
                    i--;
                    GameObject placeHolder;

                    int j = rand.Next(i);
                    print("Random # = " + j);
                    placeHolder = smallItem[i];
                    smallItem[i] = smallItem[j];
                    smallItem[j] = placeHolder;
                }


            }
        }

        if (moreItems)
        {
            for (int x = (smallPlace.Length - 1); x >= 0; x--)
            {
                smallPlace[x].GetComponent<modPlace>().SpawnChallenge(smallItem[x]);
            }
        }
        else
        {
            for (int x = (smallItem.Length - 1); x >= 0; x--)
            {
                smallPlace[x].GetComponent<modPlace>().SpawnChallenge(smallItem[x]);
            }
        }
    }

    void Object()
    {
        GameObject[] objectPlace;
        bool moreItems = false;

        objectPlace = GameObject.FindGameObjectsWithTag("Mod(big)");
        print(objectPlace.Length + " = big places");

        for (int n = mixAmount; n > 0; n--)
        {
            if (objectPlace.Length > bigItem.Length)
            {

                int i = objectPlace.Length;
                System.Random rand = new System.Random();
                while (i > 1)
                {
                    i--;
                    GameObject placeHolder;

                    int j = rand.Next(i);
                    print("Random # = " + j);
                    placeHolder = objectPlace[i];
                    objectPlace[i] = objectPlace[j];
                    objectPlace[j] = placeHolder;
                }


            }
            else
            {
                moreItems = true;
                int i = bigItem.Length;
                System.Random rand = new System.Random();
                while (i > 1)
                {
                    i--;
                    GameObject placeHolder;

                    int j = rand.Next(i);
                    print("Random # = " + j);
                    placeHolder = objectItem[i];
                    objectItem[i] = objectItem[j];
                    objectItem[j] = placeHolder;
                }


            }
        }

        if (moreItems)
        {
            for (int x = (objectPlace.Length - 1); x >= 0; x--)
            {
                objectPlace[x].GetComponent<modPlace>().SpawnChallenge(objectItem[x]);
            }
        }
        else
        {
            for (int x = (objectItem.Length - 1); x >= 0; x--)
            {
                objectPlace[x].GetComponent<modPlace>().SpawnChallenge(objectItem[x]);
            }
        }
    }



}
