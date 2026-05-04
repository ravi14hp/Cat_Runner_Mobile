using UnityEngine;


public class PointScript : MonoBehaviour
{
    [SerializeField] private float speed = 100f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
