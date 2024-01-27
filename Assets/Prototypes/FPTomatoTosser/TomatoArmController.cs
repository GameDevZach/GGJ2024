using UnityEngine;
using UnityEngine.InputSystem;

public class TomatoArmController : MonoBehaviour
{
    [SerializeField]
    private TomatoTosser tomatoTosser;  

    public void OnThrow(InputValue value)
    {
        
        if (value.isPressed)
        {
            tomatoTosser.BeginCharging();
            Debug.Log("pressed");
        }
        else
        {
            tomatoTosser.Release();
            Debug.Log("release");
        }
    }
}
