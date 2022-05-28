using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Rigidbody2D bullet;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] int scoreAmount = 25;
    [SerializeField] float lifeTime = 0.25f;
    [SerializeField] AudioClip bulletSound;



    private void Awake()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    public void MoveInDirection(Vector2 direction)
    {
        bullet.velocity = direction * bulletSpeed;
        AudioSource.PlayClipAtPoint(bulletSound, Camera.main.transform.position);
        Invoke("DestroyBullet", lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            bullet.velocity = Vector2.zero;
            Player._instance.playerScore += scoreAmount;
            Player._instance.UpdateUI();
            Destroy(collision.gameObject);
            CancelInvoke("DestroyBullet");
            Destroy(gameObject);
        } 
        else if (collision.CompareTag("Walls"))
        {
            CancelInvoke("DestroyBullet");
            Destroy(gameObject);
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }


}
