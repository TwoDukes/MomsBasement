using UnityEngine;
using System.Collections;


public class modularPositionHandler : MonoBehaviour {

    bool left = false, topLeft = false, topRight = false, right = false;
    bool chosen = false;
    GameObject[] modItems;
    ModPosition positions;
    
	// Use this for initialization
	void Start () {
        choosePositions();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void choosePositions()
    {
        modItems = GameObject.FindGameObjectsWithTag("modular");
        int modAmount = modItems.Length;

        //cycles while choosings positions
        while (modAmount > 0)
        {
            //cycles through each modular item
            for (int i = 0; i < (modItems.Length - 1); i++)
            {

                //picks a position for an item unless it is already taken
                //then it will choose again until a new position is chosen
                chosen = false;
                while (!chosen)
                {
                    //picks a random positions for a modular item in its own object
                    positions = modItems[i].GetComponent<modularPosition>().ChooseState();

                    if (!left && positions == ModPosition.Left)
                    {
                        left = true;
                        chosen = true;
                        print("LEFT");
                    }
                    if (!right && positions == ModPosition.Right)
                    {
                        right = true;
                        chosen = true;
                        print("RIGHT");
                    }
                    if (!topLeft && positions == ModPosition.TopLeft)
                    {
                        topLeft = true;
                        chosen = true;
                        print("TOPLEFT");
                    }
                    if (!topRight && positions == ModPosition.TopRight)
                    {
                        topRight = true;
                        chosen = true;
                        print("TOPRIGHT");
                    }
                }

            }
            //for each chosen item it will decrement modAmount untill while loop finishes
            if (left)
            {
                modAmount--;
            }
            if (right)
            {
                modAmount--;
            }
            if (topLeft)
            {
                modAmount--;
            }
            if (topRight)
            {
                modAmount--;
            }
        }
        print("Positions Chosen!");
    }
}
