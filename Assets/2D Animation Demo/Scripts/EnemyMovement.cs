using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int direction = 1;
    public float speed = 2;
    private float enemies;
    public float SpeedAccelaration;
    private float Accelaration;
    // Start is called before the first frame update
    void Start()
    {
        enemies = transform.childCount;
        Accelaration = SpeedAccelaration/enemies;
    }
    private void OnEnable()
    {
        EnemyController.dead += SpeedUp;
    }

    private void OnDisable()
    {
        EnemyController.dead -= SpeedUp;
    }

    private void SpeedUp(int num)
    {
        speed += Accelaration;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
        foreach (Transform enemy in transform)
        {
            if (enemy.position.x < -6.5 || enemy.position.x > 6.5)
            {
                transform.position += Vector3.down * 0.2f;
                direction *= -1;
                break;
            }
        }
    }
}
