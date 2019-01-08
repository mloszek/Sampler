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
                currentTile.GetComponent<AudioSource>().pitch = GetPitch(j);
                column.tiles.Add(currentTile.GetComponent<AudibleTile>());
                if (inputController != null)
                    inputController.SubscribeForMouseUp(currentTile.GetComponent<AudibleTile>());

                k++;
            }
            tilesColumns.Add(column);
        }
    }

    private float GetPitch(int row)
    {
        switch (row)
        {
            case 0:
                return 0.315f;
            case 1:
                return 0.35f;
            case 2:
                return 0.42f;
            case 3:
                return 0.47f;
            case 4:
                return 0.54f;
            case 5:
                return 0.64f;
            case 6:
                return 0.72f;
            case 7:
                return 0.85f;
            case 8:
                return 0.95f;
            case 9:
                return 1.08f;
            case 10:
                return 1.3f;
            case 11:
                return 1.46f;
            case 12:
                return 1.7f;
            case 13:
                return 1.9f;
            case 14:
                return 2.15f;
            case 15:
                return 2.55f;
            default:
                return 0;
        }
    }
}

[System.Serializable]
public class TilesColumn
{
    public List<AudibleTile> tiles;
}