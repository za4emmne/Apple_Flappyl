using System;
using System.Collections;
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
    [SerializeField] private int _delay;

    private BirdMover _mover;
    private ScoreCounter _scoreCounter;
    private BirdCollisionHandler _ñollisionHandler;
    private Coroutine _coroutine;

    public event Action GameOver;

    private void Awake()
    {
        _mover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
        _ñollisionHandler = GetComponent<BirdCollisionHandler>();
    }

    private void Update()
    {
        if (_inputReader.IsDownButtonBirdShoot() && _coroutine == null)
        {
            _coroutine = StartCoroutine(ShootWithDelay());
        }
    }

    private void OnEnable()
    {
        _ñollisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _ñollisionHandler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _mover.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is Pipe)
        {
            GameOver?.Invoke();
        }
        //else if (interactable is ScoreZone)
        //{
        //    _scoreCounter.Add();
        //}
        else if (interactable is Bullet)
        {
            _health -= 1;

            if (_health <= 0)
                GameOver?.Invoke();
        }
    }

    private IEnumerator ShootWithDelay()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        _weapon.Shoot(_shootPoint);

        yield return wait;

        _coroutine = null;
    }
}