using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_system : MonoBehaviour
{
    //�C���^�[�t�F�[�X�i�G�Ƃ̃_���[�W�����j�p��int�ϐ�

    public int Em_damage = 10;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("�G�ɐG��܂����B");
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        damageable.TakeDamage(Em_damage);
    }
}
