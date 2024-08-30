using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private float _xOffSet;

    private void Update()
    {
        var position = transform.position;
        position.x = _bird.transform.position.x + _xOffSet;
        transform.position = position;
    }
}
