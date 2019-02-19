using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private List<AudibleTile> audibleTiles;
    private GameObject indicatedObject;

    private bool activityOfFirstTile;
    private bool activitySet;

    private void Start()
    {
        audibleTiles = new List<AudibleTile>();
        activitySet = false;
    }

    public void SubscribeForMouseUp(AudibleTile tile)
    {
        if (audibleTiles == null) return;

        audibleTiles.Add(tile);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            CastRay();

        if (Input.GetMouseButtonUp(0))
        {
            activitySet = false;
            ResetAudibleTilesInput();
        }
    }

    private void ResetAudibleTilesInput()
    {
        if (audibleTiles == null) return;

        foreach (AudibleTile tile in audibleTiles)
            tile.ResetSwitch();
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit)
        {
            indicatedObject = hit.collider.gameObject;

            if (!activitySet)
            {
                activityOfFirstTile = indicatedObject.GetComponent<AudibleTile>().IsActive;
                activitySet = true;
            }
            
            indicatedObject.GetComponent<AudibleTile>().SetComponentsActive(!activityOfFirstTile);
        }
    }
}
