using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesDatabase : MonoBehaviour
{
    [SerializeField]
    private GameObject audibleTile;

    [SerializeField]
    private InputController inputController;

    [SerializeField]
    private List<AudioClip> notes;

    [SerializeField]
    private List<TilesColumn> tilesColumns;


    public List<TilesColumn> GetTilesColumns()
    {
        if (tilesColumns != null)
            return tilesColumns;

        return new List<TilesColumn>();
    }

    public void Fill()
    {
        TilesColumn column;
        int k = 0;

        for (int i = 0; i < 16; i++)
        {
            column = new TilesColumn();
            column.tiles = new List<AudibleTile>();

            for (int j = 0; j < 16; j++)
            {
                GameObject currentTile = Instantiate(audibleTile, new Vector3(i * 0.4f, j * 0.4f, 0), Quaternion.identity, gameObject.transform);
                currentTile.GetComponent<AudioSource>().clip = notes[j];
                column.tiles.Add(currentTile.GetComponent<AudibleTile>());
                if (inputController != null)
                    inputController.SubscribeForMouseUp(currentTile.GetComponent<AudibleTile>());

                k++;
            }
            tilesColumns.Add(column);
        }
    }
}

[System.Serializable]
public class TilesColumn
{
    public List<AudibleTile> tiles;
}