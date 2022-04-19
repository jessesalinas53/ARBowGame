using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject arrowSpawn;
    public float arrowVelocity = 20f;
    GameObject arrow;

    public void ShootArrow()
    {
        arrow = Instantiate(arrowPrefab, arrowSpawn.transform.position, arrowSpawn.transform.rotation);
        arrow.GetComponent<Rigidbody>().AddForce(transform.forward * arrowVelocity);
        //add sound
    }
}
