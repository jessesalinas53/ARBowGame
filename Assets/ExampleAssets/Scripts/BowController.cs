using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject arrowSpawn;
    public float arrowVelocity = 0f;

    public AudioSource shootAudio;

    public void ShootArrow()
    {
        var arrow = Instantiate(arrowPrefab);
        arrow.transform.position = arrowSpawn.transform.position;
        arrow.transform.rotation = arrowSpawn.transform.parent.parent.rotation;
        arrow.GetComponent<Rigidbody>().AddForce(arrow.transform.forward * arrowVelocity);
        shootAudio.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootArrow();
        }
    }
}
