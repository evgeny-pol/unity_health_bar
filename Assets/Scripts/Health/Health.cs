using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Min(1f)] private float _current = 1f;
    [SerializeField, Min(1f)] private float _max = 1f;

    public event Action CurrentChanged;

    public float Current => _current;

    public float Max => _max;

    private void OnValidate()
    {
        _current = MathF.Min(_current, _max);
    }

    public void TakeDamage(float damageAmount)
    {
        damageAmount = Mathf.Min(damageAmount, _current);

        if (damageAmount <= 0)
            return;

        _current -= damageAmount;
        CurrentChanged?.Invoke();
    }

    public void TakeHealing(float healAmount)
    {
        healAmount = Mathf.Min(healAmount, _max - _current);

        if (healAmount <= 0)
            return;

        _current += healAmount;
        CurrentChanged?.Invoke();
    }
}
