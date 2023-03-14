using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    private Animator playerAnimator;
    public int speed;

    private int hp = 3;

    public AudioClip playerShoot;
    public AudioClip playerDeath;

    private AudioSource audioSource;
    
    //-----------------------------------------------------------------------------
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // todo - trigger a "shoot" on the animator
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            audioSource.clip = playerShoot;
            audioSource.Play();

            Destroy(shot, 3f);
        }

        var HorizontalMovement = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * HorizontalMovement * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        hp--;
        Destroy(col.gameObject);
        audioSource.clip = playerDeath;
        audioSource.Play();
        if (hp == 2)
        {
            playerAnimator.SetBool("First", true);
        }
        if (hp == 1)
        {
            playerAnimator.SetBool("Second", true);
        }
        if (hp == 0)
        {
            SceneSwitching.MaintoCredits();
        }
    }
}
