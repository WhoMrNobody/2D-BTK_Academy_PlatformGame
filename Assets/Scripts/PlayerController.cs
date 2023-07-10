using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTK_Academy_DigitalGame_Course.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _movementSpeed;
        
        Rigidbody2D _rb;
        bool _isLookingRight;
        Animator _animator;
        void Awake()
        {
            _rb = this.GetComponent<Rigidbody2D>();
            _animator= this.GetComponent<Animator>();
        }

        
        void Update()
        {
            HorizontalMove();

            if (_rb.velocity.x < 0 && !_isLookingRight)
            {
                FlipFace();
            }
            else if (_rb.velocity.x > 0 && _isLookingRight)
            {
                FlipFace();
            }
        }

        void FixedUpdate()
        {
            
        }

        void HorizontalMove()
        {
            _rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _movementSpeed, _rb.velocity.y);    
            _animator.SetFloat("runningSpeed", Mathf.Abs(_rb.velocity.x));
        }

        void FlipFace()
        {
            _isLookingRight = !_isLookingRight;
            Vector3 tempLocalScale = transform.localScale;
            tempLocalScale.x *= -1;
            transform.localScale = tempLocalScale;  
        }

    }
}

