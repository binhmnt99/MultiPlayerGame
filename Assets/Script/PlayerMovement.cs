using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Animator _animator;

    private Vector3 _velocity;

    private void Start()
    {
        if (!IsOwner)
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateAnimation();
    }

    private void UpdateMovement()
    {
        Vector2 movementInput = _moveAction.action.ReadValue<Vector2>();
        Vector3 direction = transform.forward * movementInput.y + transform.right * movementInput.x;
        _velocity = _movementSpeed * direction.normalized;

        _characterController.SimpleMove(_velocity);
    }

    private void UpdateAnimation()
    {
        _animator.SetBool("isMoving",_velocity.sqrMagnitude>0);
    }
}
