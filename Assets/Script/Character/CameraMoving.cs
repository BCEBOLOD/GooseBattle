using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [Range(1, 10)]
    [SerializeField] private float _smooths;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowCamera();
    }


    private void FollowCamera()
    {

        Vector3 targetPosition = _player.position + _offset;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position, targetPosition, _smooths * Time.deltaTime);
        transform.position = SmoothPosition;
    }
}
