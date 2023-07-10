using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTK_Academy_DigitalGame_Course.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] float _playerHealth;
        [SerializeField] bool _isPlayerDead = false;

        void Start()
        {

        }

        
        void Update()
        {

        }

        public void GetDamage(float damage)
        {
            if((_playerHealth - damage) >= 0)
            {
                _playerHealth -= damage;
            }
            else
            {
                _playerHealth = 0;
            }
            AmIDead();
        }

        void AmIDead()
        {
            if(_playerHealth < 0) { 
                
                _isPlayerDead=true;
            }
        }
    }
}

