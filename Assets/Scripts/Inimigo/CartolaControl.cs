using UnityEngine;

public class CartolaControl : MonoBehaviour
{
    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.position += direction * Time.deltaTime * 5; 
    }
}
