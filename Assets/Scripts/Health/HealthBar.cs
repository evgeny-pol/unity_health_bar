using UnityEngine;

[RequireComponent(typeof(ResourceBar))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private ResourceBar _resourceBar;

    private float FillCoef => _health.Current / _health.Max;

    private void Awake()
    {
        _resourceBar = GetComponent<ResourceBar>();
    }

    private void Start()
    {
        _health.CurrentChanged += UpdateCurrentHealth;
        _resourceBar.SetInitialFillCoef(FillCoef);
    }

    private void OnDisable()
    {
        _health.CurrentChanged -= UpdateCurrentHealth;
    }

    private void UpdateCurrentHealth()
    {
        _resourceBar.SetFillCoef(FillCoef);
    }
}
