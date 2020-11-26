using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0); // get first touch since touch count is greater than zero

        if (touch.phase != TouchPhase.Stationary && touch.phase != TouchPhase.Moved) return;
        var touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

        transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
    }
}
