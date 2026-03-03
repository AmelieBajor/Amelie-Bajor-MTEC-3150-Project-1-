using UnityEngine;

public class InvincibilityPowerUp : PowerUpScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void ApplyEffect()
    {

        player.IFramesTrue = true;
        base.ApplyEffect();
    }

    protected override void NegateEffect()
    {
        base.NegateEffect();
    }



}
