using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class JoystickMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);
        _rigidbody.velocity = movement;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            // Mengatur rotasi sesuai arah pergerakan (abaikan jika kecepatan 0)
            Vector3 lookDirection = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
            if (lookDirection != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(lookDirection);

            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }
}
