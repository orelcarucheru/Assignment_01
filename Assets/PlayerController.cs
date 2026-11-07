using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    public float minX = -50f;
    public float maxX = 50f;
    public float minY = -50f;
    public float maxY = 50f;
    public int coinsCollected = 0; 
    void Update()
    {
        var dValue = Keyboard.current.dKey.value;
        transform.position += dValue * Vector3.right * speed * Time.deltaTime;

        var aValue = Keyboard.current.aKey.value;
        transform.position += aValue * Vector3.left * speed * Time.deltaTime;
        
        var wValue = Keyboard.current.wKey.value;
        transform.position += wValue * Vector3.up * speed * Time.deltaTime;

        var sValue = Keyboard.current.sKey.value;
        transform.position += sValue * Vector3.down * speed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, 0f);
    }
}