using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator: MonoBehaviour
{
    Vector3 StartingPosition;
    [SerializeField] Vector3 MovementVector;
    [SerializeField] [Range(0,1)] float MovementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = transform.position;
        Debug.Log(StartingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (period == 0) { return; }
        float cycles = Time.time / period;

        const float tau = Mathf.PI * 2;
        float rawSinwave = Mathf.Sin(cycles * tau);

        MovementFactor = (rawSinwave + 1f) / 2f;

        Vector3 offset = MovementVector * MovementFactor;
        transform.position = StartingPosition + offset;
    }
}
