using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportAreaWithFade : TeleportationArea
{
    public ScreenFader screenFader = null;

    protected override bool GenerateTeleportRequest(XRBaseInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
    {
        //StartCoroutine(FadeSequence());

        // Wait for fade in

        teleportRequest.destinationPosition = raycastHit.point;
        teleportRequest.destinationRotation = transform.rotation;
        return true;

    }

    private IEnumerator FadeSequence()
    {
        // Fade to black
        yield return screenFader.StartFadeIn();

        // Fade to clear
        yield return screenFader.StartFadeOut();
    }

    private void OnValidate()
    {
        // Get the screen fader 
        if (!screenFader)
            screenFader = FindObjectOfType<ScreenFader>();
    }
}
