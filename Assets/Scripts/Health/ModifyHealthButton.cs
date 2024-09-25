using UnityEngine;

public abstract class ModifyHealthButton : ButtonClickHandler
{
    [SerializeField] private Health _health;
    [SerializeField, Min(0f)] private float _amount;

    protected Health HealthComponent => _health;

    protected float Amount => _amount;
}
