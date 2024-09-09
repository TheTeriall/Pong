using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private Transform ball;
    public float speed = 1f;
    public float minY = -3f;
    public float maxY = 3f;

    private void Start()
    {
        GameManager.Instance.OnBallSpawned += GameManager_OnBallSpawned;
    }

    private void GameManager_OnBallSpawned(object sender, System.EventArgs e)
    {
        GameObject ballObject = GameManager.Instance.GetBall();
        ball = ballObject.transform;
    }

    private void Update()
    {
        if (ball != null)
        {
            float direction = Mathf.Sign(ball.position.y - transform.position.y);

            Vector2 movement = new Vector2(0, direction) * speed * Time.deltaTime;

            transform.Translate(movement);

            Vector2 clampedPosition = transform.position;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
            transform.position = clampedPosition;
        }
    }
}
