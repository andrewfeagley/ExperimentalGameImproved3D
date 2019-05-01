using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageClicks : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject wall;
    private Vector2 point;

    private bool isAlive;
    private bool justClicked;

    // Start is called before the first frame update
    void Start()
    {
        justClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        ClickSpawn();
        if (justClicked)
            StartCoroutine(WaitBetweenWallClicks());
    }

    public void ClickSpawn()
    {
        if (Input.GetMouseButtonDown(0) && !justClicked)
        {
            Debug.Log("Left mouse button clicked.");
            Vector3 spawnPosition = Input.mousePosition;
            spawnPosition.z = 9.0f;
            var objectPosition = mainCamera.ScreenToWorldPoint(spawnPosition);

            GameObject wallInstance = Instantiate(wall, objectPosition, Quaternion.identity);
            justClicked = true;
        }
    }

    IEnumerator WaitBetweenWallClicks()
    {
        yield return new WaitForSeconds(1f);
        justClicked = false;
    }
}
