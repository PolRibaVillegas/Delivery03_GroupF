using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float MovementHorizontal { get; private set; }
    public float MovementVertical { get; private set; }

    void Update()
    {
        MovementHorizontal = Input.GetAxis("Horizontal");
        MovementVertical = Input.GetAxis("Vertical");
    }
}
