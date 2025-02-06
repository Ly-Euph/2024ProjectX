using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    public List<GameObject> enemyFolder = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (enemyFolder.Count == 0)
        {
            Debug.Log("enemyFolder‚Ì’†g‚ª‹ó‚Å‚·");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Em_Spawn();
    }

    private void Em_Spawn()
    {

    }
}
