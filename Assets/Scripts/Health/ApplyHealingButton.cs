using UnityEngine;

public class ApplyHealingButton : ModifyHealthButton
{
    protected override void OnClick()
    {
        HealthComponent.TakeHealing(Amount);
    }
}
