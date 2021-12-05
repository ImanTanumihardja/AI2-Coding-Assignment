using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bin : MonoBehaviour
{
    /// <summary>
    /// The <c>Bin<c> class mages when the bin has collected trash.
    /// </summary>

    public delegate void CollectedEventHandler();
    public static event CollectedEventHandler onCollectedEvent;

    private const string UNCOLLECTED = "Uncollected";

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        // Check if has been collected
        if (go.CompareTag(UNCOLLECTED))
        {
            go.tag = "Untagged";
            // Disable grab
            go.GetComponent<XRGrabInteractable>().enabled = false;

            Behaviour halo = (Behaviour)go.gameObject.GetComponent("Halo");
            halo.enabled = false;

            onCollectedEvent();
        }
    }
}
