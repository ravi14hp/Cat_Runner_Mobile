using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private float step;

    [SerializeField] private AudioSource PointGain;
    [SerializeField] private AudioSource CrashCar;
    [SerializeField] private Text TextPoints;
    [SerializeField] private Text TextTime;

    private int points;
    private float time;

    void Update()
    { 
        StartCoroutine(Timeria());

        if (points == 10)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private IEnumerator Timeria()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            time += Time.deltaTime;
            TextTime.text = time.ToString("F1");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enter")
        {
            Vector3 p = other.transform.position;
            p.z += step;
            other.transform.position = p;
        }

        if (other.CompareTag("Point"))
        {
            PointGain.Play();

            points++;
            TextPoints.text = points.ToString();

            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            CrashCar.Play();
            
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");
    }
}
