using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;

    private Beam _beam;
    private Ball _ball;
    private Vector3 _camepaPosition;
    private Vector3 _minimumBallPosition;

    private void Start()
    {
        _beam = FindObjectOfType<Beam>();
        _ball = FindObjectOfType<Ball>();

        _camepaPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;

        TrackBall();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition = _ball.transform.position;
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _camepaPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        _camepaPosition -= direction * _lenght;
        transform.position = _camepaPosition;
        transform.LookAt(_ball.transform);
    }
}
