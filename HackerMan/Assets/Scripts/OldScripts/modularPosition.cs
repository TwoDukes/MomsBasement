using UnityEngine;
using System.Collections;

public enum ModPosition { Left, TopLeft, TopRight, Right };

public class modularPosition : MonoBehaviour {

    public ModPosition position;
    public bool modular = true;

    public Vector3[] locations;
    public Vector3[] rotations;


   //will be called to choose state
   public ModPosition ChooseState()
    {
        if (modular)
        {
            position = (ModPosition)Random.Range(0, 4);
        }
       // print(position + " place");
        return (position);
    }

    //will place item once the state is chosen
    public void PlaceItem()
    {
        switch (position)
        {
            case ModPosition.Left:
                transform.position = locations[0];
                transform.rotation = Quaternion.Euler(rotations[0].x, rotations[0].y, rotations[0].z);
                break;
            case ModPosition.TopLeft:
                transform.position = locations[1];
                transform.rotation = Quaternion.Euler(rotations[1].x, rotations[1].y, rotations[1].z);
                break;
            case ModPosition.TopRight:
                transform.position = locations[2];
                transform.rotation = Quaternion.Euler(rotations[2].x, rotations[2].y, rotations[2].z);
                break;
            case ModPosition.Right:
                transform.position = locations[3];
                transform.rotation = Quaternion.Euler(rotations[3].x, rotations[3].y, rotations[3].z);
                break;
        }
    }
}
