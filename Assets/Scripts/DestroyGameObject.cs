using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTK_Academy_DigitalGame_Course.Utilities
{
    public class DestroyGameObject : MonoBehaviour
    {
        [SerializeField] float _lifeTime;
        void Start()
        {
            Destroy(gameObject, _lifeTime);
        }


    }
}

