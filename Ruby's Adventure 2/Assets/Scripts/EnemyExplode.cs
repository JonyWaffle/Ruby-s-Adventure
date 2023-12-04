using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    public GameObject explosionPrefab; 
    public int explosionForce = 200;   

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Projectile"))
        {
       
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

       
            ExplodeObjects();

       
            Destroy(gameObject);
        }
    }

    private void ExplodeObjects()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 3f);

  
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
  
                Vector2 forceDirection = (rb.position - (Vector2)transform.position).normalized;
                rb.AddForce(forceDirection * explosionForce);
            }
        }
    }
}
