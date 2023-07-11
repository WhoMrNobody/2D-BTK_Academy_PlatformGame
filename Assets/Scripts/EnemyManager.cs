using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BTK_Academy_DigitalGame_Course.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] float _health;
        [SerializeField] float _damage;
        
        bool _isColliderBusy = false;
        Slider _healthSlider;
        void Start()
        {
            _healthSlider= GetComponentInChildren<Slider>();
            _healthSlider.maxValue = _health;
            _healthSlider.value = _health;
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

            if (coll.gameObject.CompareTag("Fireball"))
            {
                GetDamage(coll.GetComponent<BulletManager>().FireballDamage);
                Destroy(coll.gameObject);
            }
        }

        void OnTriggerExit2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                _isColliderBusy = false;
            }
        }

        public void GetDamage(float damage)
        {
            if ((_health - damage) >= 0)
            {
                _health -= damage;
            }
            else
            {
                _health = 0;
            }

            _healthSlider.value = _health;

            ZombieDead();
        }

        void ZombieDead()
        {
            if (_health <= 0)
            {

                Destroy(this.gameObject);
            }
        }
    }
}

