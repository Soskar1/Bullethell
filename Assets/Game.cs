using UnityEngine;
using UnityEngine.InputSystem;

public class Game : MonoBehaviour
{
    public void Restart(InputAction.CallbackContext ctx) => Debug.Log("Возвращение к последнему сейву!");
}
