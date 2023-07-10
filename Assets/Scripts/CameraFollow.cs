using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTK_Academy_DigitalGame_Course.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] Transform _followTarget;
        [SerializeField] float _followSpeed;
        void Update()
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(_followTarget.position.x, _followTarget.position.y, transform.position.z), _followSpeed);
        }
    }
}

