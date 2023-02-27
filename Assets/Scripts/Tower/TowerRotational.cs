using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotational : MonoBehaviour
{
    [SerializeField] private float rotateSpead;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float torqe = touch.deltaPosition.x * Time.deltaTime * rotateSpead;
                _rigidbody.AddTorque(Vector3.right * torqe);
            }
        }
    }
}
