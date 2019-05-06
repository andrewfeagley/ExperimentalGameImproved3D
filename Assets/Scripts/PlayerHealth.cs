using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;
    public Text healthText;
    bool justHit = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        healthText.text = "Happiness: " + currentHealth.ToString();
        StartCoroutine(HealthDecrease());
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Happiness: " + currentHealth.ToString();

        if (justHit)
            StartCoroutine(HealthDecrease());
    }

    IEnumerator HealthDecrease()
    {
        currentHealth -= 1;
        justHit = false;
        yield return new WaitForSeconds(1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Insult")
        {
            Debug.Log("Player hit");
            Destroy(collision.gameObject);
            justHit = true;
        }
    }
}