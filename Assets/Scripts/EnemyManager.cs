using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTK_Academy_DigitalGame_Course.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] float _health;
        [SerializeField] float _damage;
        
        bool _isColliderBusy = false;
        void Start()
        {

        }

        
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Player") && !_isColliderBusy)
            {   
                _isColliderBusy = true;
                coll.GetComponent<PlayerManager>().GetDamage(_damage);
            }
        }

        void OnTriggerExit2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                _isColliderBusy = false;
            }
        }
    }
}

