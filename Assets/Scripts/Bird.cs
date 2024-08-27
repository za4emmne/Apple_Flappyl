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
    [SerializeField] private float _speed;
    [SerializeField] private InputReader _inputReader;

    private BirdMover _mover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandler _birdCollisionHandler;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _birdCollisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void Update()
    {
        if (_inputReader.DownButtonBirdShoot())
            _weapon.Shoot(_shootPoint, transform.rotation, _speed);
    }

    private void OnEnable()
    {
        _birdCollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _birdCollisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
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
}