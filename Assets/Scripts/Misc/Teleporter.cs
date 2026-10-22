using Unity.Cinemachine;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform SendPlayerTo;
    public Vector2 Offset;

    public CinemachineConfiner2D Confiner;
    public Collider2D CameraContainer;
    public CinemachineCamera Camera;

    public PlayerManager PM;

    private void Awake()
    {
        Camera = FindAnyObjectByType<CinemachineCamera>();
        Confiner = FindAnyObjectByType<CinemachineConfiner2D>();
        PM = FindAnyObjectByType<PlayerManager>();
    }

    public void SwitchCameraView(Transform PlayerPoint)
    {
        Confiner.BoundingShape2D = CameraContainer;
        Camera.gameObject.transform.position = PlayerPoint.position;
    }
}
