using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float forwardSpeed = 10f;
    public float laneDistance = 3f;
    public float laneChangeSpeed = 10f;
    public float tiltSensitivity = 2f;

    private int currentLane = 1; // 0 = left, 1 = center, 2 = right
    private bool isGameOver = false;
    float smoothTilt = 0f;
    float baseTilt = 0f;

void Start()
{
    baseTilt = Input.acceleration.x;
}

    void Update()
    {
        if (isGameOver) return;

        MoveForward();
        HandleAccelerometer();
        MoveToLane();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    void HandleAccelerometer()
    {
    float rawTilt = Input.acceleration.x - baseTilt; // ✅ DEFINE IT

    smoothTilt = Mathf.Lerp(smoothTilt, rawTilt, Time.deltaTime * 5f);

    float deadZone = 0.15f;

    if (smoothTilt < -deadZone)
    {
        currentLane = 0;
    }
    else if (smoothTilt > deadZone)
    {
        currentLane = 2;
    }
    else
    {
        currentLane = 1;
    }
}

    void MoveLeft()
    {
        if (currentLane > 0)
            currentLane--;
    }

    void MoveRight()
    {
        if (currentLane < 2)
            currentLane++;
    }

    void MoveToLane()
    {
        float targetX = (currentLane - 1) * laneDistance;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}