using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D mapBounds;

    private float _xMin, _xMax, _yMin, _yMax;
    private float _camY,_camX;
    private float _camOrthsize;
    private float _cameraRatio;
    private Camera _mainCam;
    private Vector3 _smoothPos;
    public float smoothSpeed = 0.5f;

    private void Start()
    {
        var bounds = mapBounds.bounds;
        _xMin = bounds.min.x;
        _xMax = bounds.max.x;
        _yMin = bounds.min.y;
        _yMax = bounds.max.y;
        _mainCam = GetComponent<Camera>();
        _camOrthsize = _mainCam.orthographicSize;
        _cameraRatio = (_xMax + _camOrthsize) / 2.0f;
    }

    private void FixedUpdate()
    {
        var targetPosition = followTransform.position;
        _camY = Mathf.Clamp(targetPosition.y, _yMin + _camOrthsize, _yMax - _camOrthsize);
        _camX = Mathf.Clamp(targetPosition.x, _xMin + _cameraRatio, _xMax - _cameraRatio);
        var position = transform.position;
        _smoothPos = Vector3.Lerp(position, new Vector3(_camX, _camY, position.z), smoothSpeed);
        position = _smoothPos;
        transform.position = position;
    }
}