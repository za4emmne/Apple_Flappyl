using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(ScoreCounter))]
[RequireComponent(typeof(BirdCollisionHandler))]

public class Bird : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _shootPoint;

    private BirdMover _birdMover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandler _birdCollisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _birdCollisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            _weapon.Shoot(_shootPoint); 
        }
    }

    private void OnEnable()
    {
        _birdCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Pipe)
            GameOver?.Invoke();

        else if (interactable is ScoreZone)
            _scoreCounter.Add();

        else if (interactable is Bullet)
        {
            _health -= 1;

            if (_health <= 0)
                GameOver?.Invoke();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _birdMover.Reset();
    }
}
