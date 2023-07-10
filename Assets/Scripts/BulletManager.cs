using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTK_Academy_DigitalGame_Course.Manager
{
    public class BulletManager : MonoBehaviour
    {
        [SerializeField] float _lifeTime, _fireballDamage;

        public float FireballDamage => _fireballDamage;
        void Start()
        {
            Destroy(gameObject, _lifeTime);
        }
    }
}

