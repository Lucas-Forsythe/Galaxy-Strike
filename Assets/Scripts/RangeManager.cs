
using UnityEngine;
using UnityEngine.InputSystem;

public class RangeManager : MonoBehaviour
{
    [SerializeField] GameObject[] targets;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetTargets();
        }
    }

    void ResetTargets()
    {
        foreach (GameObject target in targets)
        {
            if (target == null)
            {
                continue;
            }

            Target targetScript = target.GetComponent<Target>();

            if (targetScript != null)
            {
                targetScript.ResetTarget();
            }
            
            else
            {
                target.SetActive(true);
            }
        }

        Debug.Log("All targets have been reset!");
    }
}
