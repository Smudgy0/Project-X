using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null;
    public GameObject interactionIcon;
    public LayerMask interactionLayerMask;

    void Start()
    {
        interactionIcon.SetActive(false);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            interactableInRange?.Interact();
        }
    }

    private void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, 1, interactionLayerMask);

        if (col != null)
        {
            if (col.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
            {
                interactableInRange = interactable;
                interactionIcon.SetActive(true);
            }
            else
            {
                interactableInRange = null;
                interactionIcon.SetActive(false);
            }
        }
        else
        {
            interactableInRange = null;
            interactionIcon.SetActive(false);
        }
    }
}
