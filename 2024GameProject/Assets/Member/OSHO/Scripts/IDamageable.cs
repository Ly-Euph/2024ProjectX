using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    //インターフェースでのダメージ処理管理
    void TakeDamage(int damege);
}
