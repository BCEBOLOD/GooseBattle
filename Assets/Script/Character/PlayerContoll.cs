using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerContoll : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;
    [SerializeField] private Collider2D _coll2d;
    [SerializeField] private LayerMask _layerMaskGround;
    [SerializeField] private Animator _animator;
    [SerializeField] Shop_panel _shop_Panel;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpVelocity;
    [SerializeField] private float _distanceDamage;
    //[SerializeField] private float _timeToSave;
    [Space]
    ////////////////////////////////////////
    [SerializeField] private Text _countCoin;
    private Item _item;    
    public int Coin { get; private set; }
    public float Speed { get { return _speed; } private set  { _speed = value; } }
    public float JumpVelocity { get { return _jumpVelocity; } private set { _jumpVelocity = value; } }
    

    private enum Anim  {Idle,Run,Jump,Folling,Damage}
    Anim _animEnum = Anim.Idle;
    private void Start()
    {
        _item = GetComponent<Item>();
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _coll2d = GetComponent<Collider2D>();
        CoinText();
    }

   
    public void OnCoinChanged(int money)
    {
        Coin += money;
        _countCoin.text ="Balance =" +  Coin.ToString();
    }
    private void FixedUpdate()
    {
        if (_animEnum != Anim.Damage && _animEnum != Anim.Folling)
        {
            MoveDirection();
            
        }
        _animator.SetInteger("state", (int)_animEnum);        
        AnimationState();
       // _timeToSave += 1 * Time.deltaTime;
        TOSave();

    }

    private void CoinText()
    {
        _countCoin.text = "Balance =" + Coin.ToString();
    }
    private void MoveDirection()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            _rb2d.velocity = new Vector2(-_speed, _rb2d.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb2d.velocity = new Vector2(_speed, _rb2d.velocity.y);
            transform.localScale = new Vector2(1, 1);
         
            }
        if (Input.GetKey(KeyCode.Space) && _coll2d.IsTouchingLayers(_layerMaskGround))
        {
            Jump();
        }
        
       
    }

    private void AnimationState()
    {
         if (_animEnum == Anim.Jump)
        {
            if (_rb2d.velocity.y < 0.1f)
            {
                _animEnum = Anim.Folling;
            }
        }
        else if (_animEnum == Anim.Folling) 
        {
            if (_coll2d.IsTouchingLayers(_layerMaskGround))
            {
                _animEnum = Anim.Idle;

            }
        }
        else if (_animEnum == Anim.Damage)
        {
            if (Mathf.Abs( _rb2d.velocity.x) < 0.05f)
            {
               _animEnum = Anim.Idle;
            }
        }
        else if (Mathf.Abs(_rb2d.velocity.x) >= 2)
        {
            _animEnum = Anim.Run;
        }
        else
        {
            _animEnum = Anim.Idle;
        }
    }
    private void Jump()
    {
        _rb2d.velocity = new Vector2(_rb2d.velocity.x, _jumpVelocity);
        _animEnum = Anim.Jump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {

            if (_animEnum == Anim.Folling && transform.position.y > enemy.transform.localScale.y /2 +0.3f)
            {
                enemy.JumpOnEnemy();
                Jump();
            }
            else
            {
            _animEnum = Anim.Damage;
                if (collision.gameObject.transform.position.x > transform.position.x)
                {                    
                    OnHurt(-_distanceDamage);
                
                }
                else
                {                    
                    OnHurt(_distanceDamage);
                }

            }
           
           
            
        }
    }
   

    private void OnHurt( float distance)
    {
        _rb2d.velocity = new Vector2(distance, _rb2d.velocity.y);
        
    }
    public void ChangedAll (float value0_speed,float value1_Jump,int Coin)
    {
        ChangedSpeed(value0_speed);
        ChangedJumpVelosity(value1_Jump);
        ChangedCoin(Coin);

    }
    private void ChangedSpeed(float value)
    {
        _speed += value;
    }
    private void ChangedJumpVelosity(float value)
    {
        _jumpVelocity += value;
    }
    private void ChangedCoin(int Coins)
    {
        Coin -= Coins;
        CoinText();
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);

    }
    public  void LoadGame()
    {
        SaveSystem.LoadPlayer();
        PlayerData data = SaveSystem.LoadPlayer();
        Coin = data.Coin;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
   
    public void TOSave()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayer();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
            CoinText();
        }
    }
}
