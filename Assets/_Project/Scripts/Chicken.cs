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


    Animator anim;
    public bool hasCarKey;
    public Light lantern;


    private Rigidbody _myRB;
    private float _currentSpeed;
    private bool _isMoving;
    [SerializeField]private bool _isJumping;

    private Collider _CollisionObj;
    private Quaternion _toRotation;
    private float _randomTime;

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
        if (value.Get<Vector2>() != Vector2.zero)
        {
            _isMoving = true;
            _moveDirection = new Vector3(value.Get<Vector2>().x, _myRB.velocity.y, value.Get<Vector2>().y);
            _toRotation = Quaternion.LookRotation(new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y), Vector3.up);
            
            if(_currentSpeed == speed)
            {
                anim.SetBool("Walk", true);
            }
            else
            {
                anim.SetBool("Run", true);
            }
        }
        else
        {
            _isMoving = false;
            _moveDirection = new Vector3(0, _myRB.velocity.y, 0);
            anim.SetBool("Run", false);
            anim.SetBool("Walk", false);
        }
    }

    public void OnRun(InputValue value)
    {
        Debug.Log(value.isPressed);
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
        if (_CollisionObj.CompareTag("human"))
        {
            _CollisionObj.GetComponent<Cowboy>().ActivateDialog();

        }

        if (_CollisionObj.CompareTag("otherChicken"))
        {

            _CollisionObj.GetComponent<OtherChicken>().ActivateDialog();
        }

        if (_CollisionObj.CompareTag("car") && hasCarKey)
        {
            SceneManager.LoadScene("City");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        _CollisionObj = other;
    }

    public void OnJump()
    {
        if (!_isJumping)
        {
            anim.SetTrigger("Jump");
            _isJumping = true;
            _myRB.AddForce(Vector2.up * jumpForce * 100);
        }
    }
    public void ChangeIsJump(bool val)
    {
        _isJumping = val;
    }
}
