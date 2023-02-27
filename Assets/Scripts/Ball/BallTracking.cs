using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{

    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;

    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPosition;
    private Vector3 _minimumBallPosition;
    private Vector3 _beamPosition;



    void Start  ()
    {
        _ball = FindAnyObjectByType<Ball>();
        _beam = FindAnyObjectByType<Beam>();

        _cameraPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;
        TrackBall();
    }

    private void Update()
    {
        if(_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        _cameraPosition = _ball.transform.position;
        _beamPosition = _beam.transform.position;
        _beamPosition.y = _ball.transform.position.y;
        Vector3 direction = (_beamPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPosition -= direction * _lenght;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform); 
    }

}
