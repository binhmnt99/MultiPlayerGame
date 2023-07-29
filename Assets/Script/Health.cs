using QFSW.QC;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Health : NetworkBehaviour
{
    [field: SerializeField] public int MaxHp { get; private set; }

    public UnityEvent<Health> HealthChanged;

    private readonly NetworkVariable<int> _hp = new(writePerm: NetworkVariableWritePermission.Owner);

    public int CurrentHp
    {
        get => _hp.Value;

        private set
        {
            if (_hp.Value != value)
            {
                _hp.Value = Mathf.Clamp(value, 0, MaxHp);
            }
        }
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        _hp.OnValueChanged += (_, _) => HealthChanged.Invoke(this);
    }

    private void Start()
    {
        if (!IsOwner) return;
        CurrentHp = MaxHp;
    }

    [Command]
    public void TakeDamage(int damage) => CurrentHp -= damage;

    public void OnTakeDamageAction(CallbackContext context)
    {
        if (IsOwner && context.performed)
        {
            TakeDamage(10);
        }
    }
}