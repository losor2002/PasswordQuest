using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        public int verticalPlayerMovement;
        public int horizontalPlayerMovement;

        private Animator animator;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _direction;

        private void Start()
        {
            animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || horizontalPlayerMovement == -1)
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || horizontalPlayerMovement == 1)
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || verticalPlayerMovement == 1)
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || verticalPlayerMovement == -1)
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            _direction = dir;
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = speed * _direction;
        }
    }
}
