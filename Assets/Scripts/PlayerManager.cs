using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace BTK_Academy_DigitalGame_Course.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] float _playerHealth;
        [SerializeField] bool _isPlayerDead = false;
        [SerializeField] Transform _fireball, _floatingText;
        [SerializeField] float _fireballSpeed;
        [SerializeField] Slider _healthSlider;

        Transform _muzzle;
        bool _mouseIsNotOverUI;
        void Start()
        {
            _muzzle = transform.GetChild(1);
            _healthSlider.value = _playerHealth;
            _healthSlider.maxValue = _playerHealth;
        }

        
        void Update()
        {
            _mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

            if(Input.GetMouseButtonDown(0) && _mouseIsNotOverUI)
            {
                ShootFireBall();
            }
        }

        public void GetDamage(float damage)
        {   
            Instantiate(_floatingText, this.transform.position, Quaternion.identity).GetComponent<TMP_Text>().text = damage.ToString();

            if((_playerHealth - damage) >= 0)
            {
                _playerHealth -= damage;
            }
            else
            {
                _playerHealth = 0;
            }
            _healthSlider.value = _playerHealth;
            AmIDead();
        }

        void AmIDead()
        {
            if(_playerHealth < 0) {

                DataManager.Instance.LossProcess();
                _isPlayerDead=true;
            }
        }

        void ShootFireBall()
        {
            Transform tempFireball;
            tempFireball = Instantiate(_fireball, _muzzle.position, Quaternion.identity);
            tempFireball.GetComponent<Rigidbody2D>().AddForce(_muzzle.forward * _fireballSpeed);
            DataManager.Instance.ShootBullet++;
        }
    }
}

