using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyChicken : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 _moveDirection;
    Rigidbody _myRB;
    [SerializeField] Transform cart;
    [SerializeField] float radius;
    [SerializeField] Transform screen;
    int pos;
    Transform currentPos;
    Transform nextPos;
    int life;
    // Start is called before the first frame update
    void Start()
    {
        _myRB = this.GetComponent<Rigidbody>();
        pos = 5;
        currentPos =  screen.GetChild(pos);
        this.transform.position = currentPos.position;
        life = 10;


    }

    // Update is called once per frame
    void Update()
    {
        screen.transform.position = cart.position;
        screen.transform.rotation = Quaternion.LookRotation(cart.forward, cart.up);
    }

    private void FixedUpdate()
    {

        //  Vector3 directionAux = _moveDirection * _currentSpeed * Time.fixedDeltaTime;
        ////  directionAux.y = _myRB.velocity.y;
        //  _myRB.velocity = directionAux;

    }

    void GetPos(Vector2 newPos)
    {
        if (newPos.y == -1)
        {
            if (pos > 6) return;
            pos += 3;

        }

        if (newPos.y == 1)
        {
            if (pos < 4) return;
            pos -= 3;
        }
        if (newPos.x == -1)
        {
            if (pos % 3 == 1) return;
            pos--;
        }
        if (newPos.x == 1)
        {
            if (pos % 3 == 0) return;
            pos++;
        }

        nextPos = screen.GetChild(pos);

    }
    public void OnMove(InputValue value)
    {
        if (value.Get<Vector2>() != Vector2.zero && !GameManager.onPause)
        {
            //  _isMoving = true;
            //Vector3 forwardProj = (Vector3.Project(Vector3.forward, Camera.main.transform.forward) + Camera.main.transform.forward).normalized * value.Get<Vector2>().y;
            //Vector3 rightProj = (Vector3.Project(Vector3.right, Camera.main.transform.right) + Camera.main.transform.right).normalized * value.Get<Vector2>().x;

            Vector2 direction = value.Get<Vector2>();

            GetPos(direction);
            StartCoroutine(Moving());
            _moveDirection = direction;// * speed;

            //  _moveDirection.y = _myRB.velocity.y;

            // _toRotation = Quaternion.LookRotation(new Vector3(_moveDirection.x, 0, _moveDirection.z));

        }
        else
        {

            _moveDirection = new Vector3(0, 0, 0);
            //_stepCooldown = _walkStepCooldown;
            //anim.SetBool("Run", false);
            //anim.SetBool("Walk", false);
        }
    }

    IEnumerator Moving()
    {
        float factor = 0;
        while(factor < 1)
        {
            factor += Time.deltaTime * speed;

            this.transform.position = Vector3.Lerp(currentPos.position, nextPos.position, factor);
            yield return null;
        }

        currentPos = nextPos;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "tubeSmoke")
        {
            life--;
            Debug.Log("LIFE REMAINING: " + life);
        }
    }
}

