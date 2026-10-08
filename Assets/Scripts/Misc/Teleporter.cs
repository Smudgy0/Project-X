using Unity.Cinemachine;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform SendPlayerTo;
    public Vector2 Offset;

    public CinemachineConfiner2D Confiner;
    public Collider2D CameraContainer;
    public CinemachineCamera Camera;

    private void Awake()
    {
        Camera = FindAnyObjectByType<CinemachineCamera>();
        Confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    public void SwitchCameraView(Transform PlayerPoint)
    {
        Confiner.BoundingShape2D = CameraContainer;
        Camera.gameObject.transform.position = PlayerPoint.position;
    }
}
