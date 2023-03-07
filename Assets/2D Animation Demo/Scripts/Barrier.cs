using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private int BarrierHealth = 2;

    public Sprite BarrierSprite;

    private void OnTriggerEnter2D(Collider2D bullet)
    {
        Destroy(bullet.gameObject);
        BarrierHealth--;
        if (BarrierHealth == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = BarrierSprite;
        }
    }
}
