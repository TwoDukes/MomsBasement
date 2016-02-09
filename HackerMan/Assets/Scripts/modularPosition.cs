using UnityEngine;
using System.Collections;

public enum ModPosition { Left, TopLeft, TopRight, Right };

public class modularPosition : MonoBehaviour {

    public ModPosition position;



   //will be called to choose state
   public ModPosition ChooseState()
    {
        position = (ModPosition)Random.Range(0, 4);
        return (position);
    }

    //will place item once the state is chosen
    public void PlaceItem()
    {

    }
}
