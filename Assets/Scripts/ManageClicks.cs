using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageClicks : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject wall;
    public Renderer wallRenderer;
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
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.name == "Floor" && Input.GetMouseButtonDown(0))
            {
                Vector3 spawnPosition = hit.point;
                spawnPosition.y += (wallRenderer.bounds.size.y /4);
                GameObject wallInstance = Instantiate(wall, spawnPosition, Quaternion.identity);
                justClicked = true;
            }
        }
    }

    IEnumerator WaitBetweenWallClicks()
    {
        yield return new WaitForSeconds(1f);
        justClicked = false;
    }
}
