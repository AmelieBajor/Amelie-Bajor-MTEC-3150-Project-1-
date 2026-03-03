using UnityEngine;

public class HealthPowerUp : PowerUpScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void ApplyEffect()
    {

        if (player.health < player.maxHealth)
        {
            player.health += 1;
        }
        base.ApplyEffect();
    }




    protected override void NegateEffect()
    {
        base.NegateEffect();
    }




}
