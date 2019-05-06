using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHealth : MonoBehaviour, IDamageable
{
    public float startingHealth;
    public GameObject parent;
    [SerializeField]
    private float currentHealth;

    public void TakeDamage()
    {
        currentHealth -= 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(parent);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Insult")
        {            
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
}
