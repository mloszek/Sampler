using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private TilesDatabase tilesDatabase;

    [SerializeField]
    private SoundController soundController;

    [SerializeField]
    private float speed = 0.125f;

    private Dictionary<int, PlayHandler> playDict;
    private Coroutine rollCoroutine;
    private int index;

    private void Start()
    {
        index = 0;

        if (tilesDatabase != null)
            tilesDatabase.Fill(soundController);

        playDict = new Dictionary<int, PlayHandler>();
        SubscribeTilesForPlayEvent();

        if (rollCoroutine != null)
        {
            StopCoroutine(rollCoroutine);
            rollCoroutine = null;
        }

        rollCoroutine = StartCoroutine(RollTheMusic());
    }

    private void SubscribeTilesForPlayEvent()
    {
        List<TilesColumn> tilesColumns = tilesDatabase.GetTilesColumns();

        for (int i = 0; i < tilesColumns.Count; i++)
        {
            playDict.Add(i, new PlayHandler());

            foreach (AudibleTile tile in tilesColumns[i].tiles)
            {
                tile.SubscribeForPlayEvent(playDict[i]);
            }
        }
    }

    private IEnumerator RollTheMusic()
    {
        while (true)
        {
            yield return new WaitForSeconds(speed);

            playDict[HandleIndex()].PlayTiles();
            index++;
        }
    }

    private int HandleIndex()
    {
        if (index > 15)
        {
            index = 0;
        }

        return index;
    }

    private void OnDestroy()
    {
        StopCoroutine(RollTheMusic());
        rollCoroutine = null;
    }
}
