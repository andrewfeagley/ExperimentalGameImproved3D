using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insult : MonoBehaviour
{
    public GameObject player;
    public BoxCollider textCollider;
    public TextMesh textMesh;
    public float speed;
    public string[] insults;

    private float width;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        SetText();
        SetSize();
        target = player.transform.position;
        target.y += 1;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }

    void SetText()
    {
        textMesh.text = insults[Random.Range(0, 5)];
    }

    void SetSize()
    {
        foreach (char symbol in textMesh.text)
        {
            CharacterInfo info;
            if (textMesh.font.GetCharacterInfo(symbol, out info, textMesh.fontSize, textMesh.fontStyle))
            {
                width += info.advance;
            }
        }
        float finalWidth = width * textMesh.characterSize * textMesh.transform.lossyScale.x * 0.1f;
        textCollider.size = new Vector3(finalWidth, 1, 1);
        textCollider.center = new Vector3(finalWidth / 2, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(this.gameObject);
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall hit.");
            Destroy(this.gameObject);
        }
        Debug.Log("collision has happened");
    }
}