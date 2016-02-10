using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/**
    This class is used to control the order and flow of challenges in teh game.

    There should only be 1 mission ontroll in each scene. It can be added to any game object.

**/

public class MissionControl : MonoBehaviour {

    public Challenge openningChallege;

    public GameObject computerScreen;

    public LinkedList<Challenge> challengeList;
    public LinkedListNode<Challenge> currentChallenge;
    public bool GameIsRunning;

    private int descriptionIndex = 5;
    private string currentDescription = "";

    public const int LINELENGTH = 13;
    public const int LINEHEIGHT = 7;
    private TextMesh computerTextMesh;

    // It will find all game objects with a Challenge component and order them by
    // that challenge's ORDER property.
    void Start () {
        challengeList = new LinkedList<Challenge>();
        Challenge[] challenges = FindObjectsOfType<Challenge>();
        Array.Sort(challenges, delegate (Challenge x, Challenge y) { return x.order.CompareTo(y.order); });

        for (int i = 0; i < challenges.Length; i++)
        {
            Challenge c = challenges[i];
            //Debug.Log(c.order);
            c.gameObject.SetActive(false);
            c.goalReached += C_goalReached1;
            c.failStateReached += C_failStateReached1;
            challengeList.AddLast(c);
        }

        // select and start the first challenge
        //Debug.Log(++currentChal);
        currentChallenge = challengeList.First;
        computerTextMesh = computerScreen.transform.GetChild(0).GetComponent<TextMesh>();
        displayChallengeDescription();
        currentChallenge.Value.StartChallenge();

        GameIsRunning = true;
	}

    // This method will get evoked if a challenge is failed
    // The methods of failure will be defined in that challenges FailState object.
    private void C_failStateReached1(object sender, EventArgs e)
    {
        GameIsRunning = false;
        currentDescription = "GAME OVER";
    }

    // This method will get evoked if a challenge passes
    // The methods of success will be defined in that challenges GoalState object.
    private void C_goalReached1(object sender, EventArgs e)
    {
        AttemptNextChallenge();
    }

    // Will determine where the challenge will be displayed on screen
    // based off that screens designated LINELENGTH and LINEHEIGHT
    private void displayChallengeDescription()
    {
        currentDescription = currentChallenge.Value.challengeDescription;

        int length = currentDescription.Length;
        int maxChars = LINEHEIGHT * LINELENGTH;
        int range = maxChars - length;
        descriptionIndex = (int)Math.Floor(UnityEngine.Random.value * (range - 3) + 3);
    }

    // Will attempt to start the next challenge in teh list.
    // if there are no more challenges the player has successfully 
    // beaten all the challenges in this level.
    int currentChal = 0;
    private void AttemptNextChallenge()
    {
        Destroy(currentChallenge.Value);
        currentChallenge = currentChallenge.Next;
        // check if there are any more challenges
        if (currentChallenge == null)
        {
            GameIsRunning = false;
            currentDescription = "hacked in";
        }
        else
        {
            Debug.Log(++currentChal);
            displayChallengeDescription();
            currentChallenge.Value.StartChallenge();
        }
        
    }


    // Randomizes the text to appear on screen.
    void Update()
    {
        int tempCounter = 0;

        string textToAppear = "";
        bool useDesc = false;
        int messageIndex = 0;
        for (int i = 0, size = LINELENGTH * LINEHEIGHT; i < size; ++i)
        {
            if (i == descriptionIndex)
            {
                useDesc = true;
            }
            if (useDesc && messageIndex >= currentDescription.Length)
            {
                useDesc = false;
            }
            else if (useDesc)
            {
                textToAppear += currentDescription[messageIndex++];
            }
            else if (i < 2)
            {
                char chara = ' ';
                if (currentChallenge != null) chara = currentChallenge.Value.GetTimeUntilFail(i);
                //Debug.Log(chara);
                textToAppear += chara; // TODO: Getting time not working
            }
            else
            {
                textToAppear += RandomLetter.GetLetter();
            }

            tempCounter++;
            if (tempCounter % LINELENGTH == 0)
            {
                textToAppear += "\n";
            }
        }
        if (GameIsRunning)
        {
            computerTextMesh.text = textToAppear;
        }
        else
        {
            computerTextMesh.text = currentDescription;
        }
        
    }
}

// Helper class for matrix styll text
static class RandomLetter
{
    static System.Random rand = new System.Random();
    public static char GetLetter()
    {
        int num = rand.Next(0, 25);
        char let = (char)('a' + num);
        return let;
    }
}