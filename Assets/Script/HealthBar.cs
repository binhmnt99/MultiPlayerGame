using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _image;

    private void Start() {
        
    }

    public void SetValue(float value)
    {
        _image.localScale = new Vector3(value, 1, 1);
    }

    public void Health_HealthChanged(Health health) => SetValue((float)health.CurrentHp / health.MaxHp);

}
