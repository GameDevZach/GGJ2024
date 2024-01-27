using UnityEngine;

public class AirborneTomato : MonoBehaviour
{
    [SerializeField]
    private float splatterThreshold = 3;
    [SerializeField]
    private GameObject splatterDecal;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.magnitude > splatterThreshold)
        {
            Debug.Log("splat");
            if (collision.impulse.y > splatterThreshold / 2) {
                ContactPoint contact = collision.GetContact(0);
                Instantiate(splatterDecal, contact.point + Vector3.up * 0.05f, Quaternion.LookRotation(collision.impulse));
            }
        }
    }
}
