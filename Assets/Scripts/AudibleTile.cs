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
    private PlayHandler playHandler;

    public bool IsActive { get; set; }

    private void OnEnable()
    {
        alreadySwitched = false;
        tileDefaultColor.a = 0.5f;
        spriteRenderer.color = tileDefaultColor;
    }

    public void SubscribeForPlayEvent(PlayHandler playHandler)
    {
        if (playHandler != null)
        {
            this.playHandler = playHandler;
            this.playHandler.OnPlay -= Play;
            this.playHandler.OnPlay += Play;
        }
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

    private void Play()
    {
        if (IsActive)
        {
            animator.Play("Play");
            audioSource.Play();
        }
    }

    public void ResetSwitch()
    {
        alreadySwitched = false;
    }

    private void OnApplicationQuit()
    {
        playHandler.OnPlay -= Play;
    }
}
