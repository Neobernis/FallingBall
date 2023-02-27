using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BullJump : MonoBehaviour
{
    [SerializeField] private float _jumpSpead;
    public Rigidbody _rigidbody;
   


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * _jumpSpead * Time.deltaTime, ForceMode.Impulse);
        }
        
    }
}
