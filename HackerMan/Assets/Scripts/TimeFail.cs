using System;
using UnityEngine;


/*
    Fail State based on time.

    A fail State will be reached when countdownTime <= counter
*/

public class TimeFail : FailState {

    public float countdownTime = 30;

    private float counter;
    
    public override bool CheckIfStateIsReached()
    {
        if (counter >= countdownTime)
        {
            return true;
        }
        return false;
    }

    // Use this for initialization
    void Start () {
        counter = 0;
    }

    void Update()
    {
        //Debug.Log("updaing");
        counter += Time.deltaTime;
    }

    // returns the time remainign
    public override char GetTimeCharAt(int i)
    {
        string text = "" + (countdownTime - counter);
        return text[i];
    }
}
