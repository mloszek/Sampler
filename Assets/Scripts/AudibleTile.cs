using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudibleTile : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private bool alreadySwitched;
    private Color tileDefaultColor = Color.white;

    public bool IsActive { get; set; }

    private void OnEnable()
    {
        alreadySwitched = false;
        tileDefaultColor.a = 0.5f;
        spriteRenderer.color = tileDefaultColor;
    }

    public void SetComponentsActive(bool activity)
    {
        if (!alreadySwitched)
        {
            if (!IsActive && activity)
            {
                IsActive = true;
                tileDefaultColor.a = 1f;
                spriteRenderer.color = tileDefaultColor;
            }
            else if (IsActive && !activity)
            {
                IsActive = false;
                tileDefaultColor.a = 0.5f;
                spriteRenderer.color = tileDefaultColor;
            }
            alreadySwitched = true;
        }
    }

    public void ResetSwitch()
    {
        alreadySwitched = false;
    }
}
