using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject arrowSpawn;
    public float arrowVelocity = 30f;

    [SerializeField] private bool _canShoot = true;
    public bool CanShoot => _canShoot;

    [SerializeField] private GameObject _arrowModel = null;
    [SerializeField] private AudioClip _twangAudio = null;
    [SerializeField] private AudioClip _reloadAudio = null;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ShootArrow()
    {
        var arrow = Instantiate(arrowPrefab);
        arrow.transform.position = arrowSpawn.transform.position;
        arrow.transform.rotation = arrowSpawn.transform.parent.parent.rotation;
        arrow.GetComponentInChildren<Rigidbody>().AddForce(arrow.transform.forward * arrowVelocity);
        _canShoot = false;
    }

    private void PlayTwangAudioAtDraw()
    {
        _audioSource.clip = _twangAudio;
        _audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canShoot)
        {
            ShootArrow();
        }
    }

    public void CallRemoveArrow()
    {
        StartCoroutine(RemoveArrow());
    }

    private IEnumerator RemoveArrow()
    {
        if (_arrowModel)
        {
            _arrowModel.SetActive(false);
        }

        yield return new WaitForSeconds(0.75f);
        _audioSource.clip = _reloadAudio;
        _audioSource.Play();
        yield return new WaitForSeconds(0.5f);

        _arrowModel.SetActive(true);
        _canShoot = true;
    }
}
