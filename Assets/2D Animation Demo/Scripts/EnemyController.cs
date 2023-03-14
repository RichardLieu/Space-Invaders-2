using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController: MonoBehaviour
{
    public int score;
    
    public delegate void EnemyDeath(int score);

    public static event EnemyDeath dead;
    public GameObject bullet;

    private AudioSource _audioSource;
    public AudioClip enemyShoot;
    public AudioClip enemyDeath;

    private Animator animator;
    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    //-----------------------------------------------------------------------------
    private void OnTriggerEnter2D(Collider2D bullet)
    {
        if (bullet.CompareTag("Enemy"))
        {
            return;
        }
        _audioSource.clip = enemyDeath;
        _audioSource.Play();
        dead?.Invoke(score);
        Destroy(bullet.gameObject);
        animator.SetTrigger("Died");
    }

    private void Update()
    {
        if (Random.Range(0, 10000) < 5)
        {
            GameObject MakeBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Destroy(MakeBullet, 3);
            _audioSource.clip = enemyShoot;
            _audioSource.Play();
        }
    }
}