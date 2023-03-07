using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController: MonoBehaviour
{
    public int score;
    
    public delegate void EnemyDeath(int score);

    public static event EnemyDeath dead;
    public GameObject bullet;

    //-----------------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (bullet.CompareTag("Enemy"))
        {
            return;
        }
        dead?.Invoke(score);
        Destroy(bullet.gameObject); // destroy bullet
        Destroy(gameObject);
        Debug.Log("Ouch!" + score);
    }

    private void Update()
    {
        if (Random.Range(0, 10000) < 5)
        {
            GameObject MakeBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Destroy(MakeBullet, 3);
        }
    }
}