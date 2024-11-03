using UnityEngine;

public class CharacterCanUpScript : MonoBehaviour
{
    public bool canUp = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canUp = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        { 
            canUp = true; 
        }
    }
}
