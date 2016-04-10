using UnityEngine;
using System.Collections;

public class modPlace : MonoBehaviour {


   public void SpawnChallenge(GameObject ItemSpawn)
    {
        Instantiate(ItemSpawn, gameObject.transform.position, Quaternion.identity);
        print("PLACED " + ItemSpawn);
        Destroy(gameObject);
    }
}
