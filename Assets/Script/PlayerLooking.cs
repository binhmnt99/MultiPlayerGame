using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLooking : NetworkBehaviour
{
    [SerializeField] private InputActionReference _lookingAction;
    [SerializeField] private float anglePerSec;

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
        float lookingInput = _lookingAction.action.ReadValue<float>();
        transform.Rotate(0f, lookingInput * Time.deltaTime * anglePerSec, 0f);
    }
}
