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

    public void Fill(SoundController soundController)
    {
        TilesColumn column;
        GameObject currentTile;
        AudibleTile audioComponent;

        for (int i = 0; i < 16; i++)
        {
            column = new TilesColumn
            {
                tiles = new List<AudibleTile>()
            };

            for (int j = 0; j < 16; j++)
            {
                currentTile = Instantiate(audibleTile, new Vector3(i * 0.4f, j * 0.4f, 0), Quaternion.identity, gameObject.transform);
                audioComponent = currentTile.GetComponent<AudibleTile>();
                audioComponent.SetAudioSource(soundController.GetAudioSource(j));
                column.tiles.Add(audioComponent);
                if (inputController != null)
                    inputController.SubscribeForMouseUp(currentTile.GetComponent<AudibleTile>());
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