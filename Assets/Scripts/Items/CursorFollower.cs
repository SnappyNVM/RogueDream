using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.LookAt(Input.mousePosition);
    }
}
