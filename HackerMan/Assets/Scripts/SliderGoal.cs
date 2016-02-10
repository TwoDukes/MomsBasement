using UnityEngine;
using System.Collections;
using System;


/*
    Goal state will be reached when a slider is slid up or down (defined in the unity editor of the script)

    Uptrigger: the collider object the slider will touch to be in the UP position
    DownTrigger: the collider object the slider will touch to be in teh DOWN position
*/


public class SliderGoal : GoalState
{
    public GameObject slider;

    public GameObject UpTrigger;
    public GameObject DownTrigger;
    
    public enum SliderDir
    {
        UP,
        DOWN,
        NONE
    }

    SliderDir currentSlide = SliderDir.NONE;

    public SliderDir sliderDirectionGoal = SliderDir.UP;

    public override bool CheckIfStateIsReached()
    {
        return currentSlide == sliderDirectionGoal;
    }

    void Start()
    {
        slider = GameObject.Find(slider.name);

        UpTrigger = GameObject.Find(UpTrigger.name);
        DownTrigger = GameObject.Find(DownTrigger.name);

        UpTrigger.GetComponent<OnTouchBehavior>().objectHit += SliderUpGoal_objectHit;
        DownTrigger.GetComponent<OnTouchBehavior>().objectHit += SliderDownGoal_objectHit;
    }

    private void SliderDownGoal_objectHit(object sender, EventArgs e)
    {
        
            currentSlide = SliderDir.DOWN;
        
    }

    private void SliderUpGoal_objectHit(object sender, EventArgs e)
    {
        Debug.Log("up hit");
            currentSlide = SliderDir.UP;
        
    }
}
