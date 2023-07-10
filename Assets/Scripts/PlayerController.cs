using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTK_Academy_DigitalGame_Course.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _movementSpeed;
        [SerializeField] float _jumpForce, _jumpFrequency = 0.1f, _nextJumpTime;
        [SerializeField] Transform _groundCheckerObject;
        [SerializeField] float _groundCheckerRadius;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] bool _isGrounded = false;

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
            GroundCheck();

            if (_rb.velocity.x < 0 && !_isLookingRight)
            {
                FlipFace();
            }
            else if (_rb.velocity.x > 0 && _isLookingRight)
            {
                FlipFace();
            }

            if (Input.GetAxis("Vertical") > 0 && _isGrounded && (_nextJumpTime < Time.timeSinceLevelLoad))
            {   
                _nextJumpTime = Time.timeSinceLevelLoad + _jumpFrequency;
                Jump();
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

        void Jump()
        {
            _rb.AddForce(new Vector2(0f, _jumpForce));
        }

        void GroundCheck()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheckerObject.position, _groundCheckerRadius, _layerMask);
        }
    }
}

