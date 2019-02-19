using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField]
    private TilesDatabase tilesDatabase;

    [SerializeField]
    private float speed =  0.125f;

    private Coroutine rollCoroutine;

    private int index;

    private void Start()
    {
        index = 0;

        if (tilesDatabase != null)
            tilesDatabase.Fill();

        if (rollCoroutine != null)
        {
            StopCoroutine(rollCoroutine);
            rollCoroutine = null;
        }

        rollCoroutine = StartCoroutine(RollTheMusic());
    }

    private IEnumerator RollTheMusic()
    {
        yield return new WaitForSeconds(speed);

        Interact(tilesDatabase.GetTilesColumns()[HandleIndex()]);
        index++;

        rollCoroutine = StartCoroutine(RollTheMusic());
    }

    private int HandleIndex()
    {
        if (index > 15)
        {
            index = 0;
        }

        return index;
    }

    private void Interact(TilesColumn tilesColumn)
    {
        foreach (AudibleTile tile in tilesColumn.tiles)
        {
            if (tile.IsActive)
            {
                tile.gameObject.GetComponent<Animator>().Play("Play");
                tile.gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
