using UnityEngine;

public class Ball : MonoBehaviour
{
    public static float MaxSpeed
    {
        get
        {
            return 2.5f;
        }
    }
    
    private void OnEnable()
    {
        Random.InitState(Time.frameCount);
        float Angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        float Speed = Random.Range(4f, 6f);
        GetComponent<Rigidbody2D>().velocity = Speed * new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));
    }
}
