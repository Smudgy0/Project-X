using UnityEngine;

public class PlayerGoundChecker : MonoBehaviour
{
    //public bool GroundTargetFound;
    //public GameObject MyGroundPointChecker;

    public float groundCheckRadius;
    public Transform groundCheckObject; 
    public LayerMask groundMask;  
    public Collider2D isGrounded;

    public PlayerMovement PM;

    private void Awake()
    {
        PM = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckObject.position, groundCheckRadius, groundMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckObject.position, groundCheckRadius);
    }
}
