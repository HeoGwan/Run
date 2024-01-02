using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float _disapperTime = 5f;

    void Start()
    {
        StartCoroutine(Disapper());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }

    IEnumerator Disapper()
    {
        yield return new WaitForSeconds(_disapperTime);
        Destroy(gameObject);
    }
}
