using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_system : MonoBehaviour
{
    //インターフェース（敵とのダメージ処理）用のint変数

    public int Em_damage = 10;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("敵に触れました。");
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        damageable.TakeDamage(Em_damage);
    }
}
