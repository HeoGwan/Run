using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] _planes;

    [SerializeField]
    GameObject _gem;

    [SerializeField]
    int _planeWidth = 30;
    int _index = 0;


    public void MovePlane()
    {
        int planeCount = _planes.Length;
        if (_planes.Length == 0) return;

        _planes[_index].transform.position = new Vector3(_planes[_index].transform.position.x,
            _planes[_index].transform.position.y, _planes[_index].transform.position.z + _planeWidth * planeCount);

        GameObject newGem = Instantiate(_gem);

        newGem.transform.position = new Vector3(_planes[_index].transform.position.x + Random.Range(-1, 2) * 2,
            _planes[_index].transform.position.y + 2f, _planes[_index].transform.position.z);

        _index++;
        _index = _index % planeCount;
    }
}
