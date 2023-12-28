using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField]
    private float _disapperTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disapper());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            Destroy(gameObject);
            GameManager.instance.GetPoint();
        }
    }

    IEnumerator Disapper()
    {
        yield return new WaitForSeconds(_disapperTime);
        Destroy(gameObject);
    }
}
