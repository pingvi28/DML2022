using System.Collections;
using UnityEngine;

// перемещение камеры с игроком (уже с поворотом)
public class PlayerCameraController : MonoBehaviour
{
    public Camera cam;
    public Transform target;

    public float speedX = 360f;
    public float speedy = 240f;
    public float limitY = 40f;
    public float minDistance = 1.5f;
    public float hideDistance = 2f;

    public VectorValue pos;
    public LayerMask obstacles;
    public LayerMask noPlayer;

    private float _maxDistance;
    private float _currentYRotation;
    private Vector3 _localPosition;
    private LayerMask _camOrigin;

    private Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Start()
    {
        _localPosition = target.InverseTransformPoint(_position);
        _maxDistance = Vector3.Distance(_position, target.position);
        _camOrigin = cam.cullingMask;
    }

    void LateUpdate()
    {
        _position = target.TransformPoint(_localPosition);
        CameraRotation();
        ObstaclesReact();
        PlayerReact();

        _localPosition = target.InverseTransformPoint(_position);
    }

    void CameraRotation()
    {
        transform.LookAt(target);
    }

    void ObstaclesReact()
    {
        var distance = Vector3.Distance(_position, target.position);
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, _maxDistance, obstacles))
        {
            _position = hit.point;
        }
        else if (distance < _maxDistance && !Physics.Raycast(_position, -transform.forward, .1f, obstacles))
        {
            _position -= transform.forward * .05f;
        }
    }

    void PlayerReact()
    {
        var distance = Vector3.Distance(_position, target.position);
        if (distance < hideDistance)
            cam.cullingMask = noPlayer;
        else
            cam.cullingMask = _camOrigin;
    }
}
