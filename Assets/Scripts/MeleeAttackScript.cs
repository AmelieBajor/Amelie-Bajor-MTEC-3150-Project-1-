using UnityEngine;

public class MeleeAttackScript : MonoBehaviour
{
    public int damageAmount;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {





        }

    }
}
