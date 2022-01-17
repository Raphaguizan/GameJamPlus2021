using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class Chicken : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    [SerializeField] float runSpeed = 200f;
    [Space]
    [SerializeField] float rotationSpeed = 200f;
    [Space]
    [SerializeField] float jumpForce = 200f;
    [Space]
    public bool canMove = true;
    [Space]
    [SerializeField] RandomSound chickenSound;
    [SerializeField] RandomSound stepSound;

    Animator anim;
    public Light lantern;


    private Rigidbody _myRB;
    private float _currentSpeed;
    private bool _isMoving;
    private bool _isJumping;

    private Collider _CollisionObj;
    private Quaternion _toRotation;
    private float _randomTime;
    public float _walkStepCooldown = 0.25f;
    public float _runStepCooldown = 0.15f;

    [Header("hit")]
    public HitController chickenHit;
    public bool hitenabled = false;

    private float _stepCooldown;
    private float _currentStepCooldown = 0;

    private void OnEnable()
    {
        TimeController.TimeChange += ToggleLantern;
    }

    private void OnDisable()
    {
        TimeController.TimeChange -= ToggleLantern;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _myRB = GetComponent<Rigidbody>();

        _isMoving = false;
        _isJumping = false;
        _currentSpeed = speed;

        StartCoroutine(RandomAnimations());
    }

    IEnumerator RandomAnimations()
    {
        while (true)
        {
            if (!_isMoving)
            {
                _randomTime = Random.Range(4, 20);
                yield return new WaitForSeconds(_randomTime);
                if (!_isMoving)
                {
                    float randomaux = Random.value;
                    if (randomaux >= 0.5f)
                    {
                        anim.SetTrigger("Eat");
                    }
                    else
                    {
                        anim.SetTrigger("TurnHead");
                    }
                    if(chickenSound) chickenSound.PlayRandom();
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _toRotation, rotationSpeed * Time.deltaTime);
        if(_isMoving && _currentStepCooldown <= 0 && !_isJumping){
            if(stepSound)stepSound.PlayRandom();
            _currentStepCooldown = _stepCooldown;
        }else if(_isMoving){
            _currentStepCooldown -= Time.deltaTime;
        }
    }

    public void ToggleLantern()
    {
        bool val = TimeController._isDay;
        if(val)
            lantern.intensity = 0;
        else
            lantern.intensity = 2;
    }

    private Vector3 _moveDirection;
    private void FixedUpdate()
    {

        Vector3 directionAux = _moveDirection * _currentSpeed * Time.fixedDeltaTime;
        directionAux.y = _myRB.velocity.y;
        _myRB.velocity = directionAux;

    }
    public void OnMove(InputValue value)
    {
        if (value.Get<Vector2>() != Vector2.zero && canMove)
        {
            _isMoving = true;
            _moveDirection = new Vector3(value.Get<Vector2>().x, _myRB.velocity.y, value.Get<Vector2>().y);
            _toRotation = Quaternion.LookRotation(new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y), Vector3.up);

            if(_currentSpeed == speed)
            {
                _stepCooldown = _walkStepCooldown;
                anim.SetBool("Walk", true);
            }
            else
            {
                _stepCooldown = _runStepCooldown;
                anim.SetBool("Run", true);
            }
        }
        else
        {
            _isMoving = false;
            _moveDirection = new Vector3(0, _myRB.velocity.y, 0);
            _stepCooldown = _walkStepCooldown;
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
        }
    }

    public void OnRun(InputValue value)
    {
        if (value.isPressed)
        {
            _currentSpeed = runSpeed;
            if(_isMoving)
            {
                anim.SetBool("Run", true);
            }
        }
        else
        {
            _currentSpeed = speed;
            if (_isMoving)
            {
                anim.SetBool("Run", false);
            }
        }
    }
    public void OnInteract()
    {
        if (!_CollisionObj) return;

        var npc = _CollisionObj.GetComponent<InteractiveNPC>();
        if (chickenSound) chickenSound.PlayRandom();
        if (npc)
        {
            npc.ActivateDialog();
        }
        else
        {
            var item = _CollisionObj.GetComponent<ItemCollectableBase>();
            if (item)
            {
                item.Collect();
            }
            else
            {
                var consume = _CollisionObj.GetComponent<ConsumeItem>();
                if (consume)
                {
                    consume.CheckItem();
                }
            }
        }
    }

    public void OnJump()
    {
        if (!_isJumping && canMove)
        {
            if (chickenSound) chickenSound.PlayRandom();
            anim.SetTrigger("Jump");
            _isJumping = true;
            _myRB.AddForce(Vector2.up * jumpForce * 100);
        }
    }
    public void OnMenu()
    {
        GameManager.Instance.TogglePause();
        if (GameManager.onPause)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    public void OnHit()
    {
        if (!hitenabled) return;

        anim.SetTrigger("MakeHit");
        if (chickenSound) chickenSound.PlayRandom();

        chickenHit.Hit();
    }

    public void ChangeIsJump(bool val)
    {
        _isJumping = val;
    }

    public void ChangeCanMove(bool val)
    {
        canMove = val;
    }

    private void OnTriggerStay(Collider other)
    {
        _CollisionObj = other;
    }

    private void OnTriggerExit(Collider other)
    {
        _CollisionObj = null;
    }
}
