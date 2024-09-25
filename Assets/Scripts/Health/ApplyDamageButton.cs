using UnityEngine;

public class ApplyDamageButton : ModifyHealthButton
{
    protected override void OnClick()
    {
        HealthComponent.TakeDamage(Amount);
    }
}
