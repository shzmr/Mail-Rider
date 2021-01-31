using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : Damageable
{
    public float moveSpeed = 1;
    public new Camera camera;

    public RaycastHit2D[] hitCache;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        Damageable.globalDamageEvent.AddListener(OnDamage);
        Damageable.globalDeathEvent.AddListener(OnDeath);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vertical = Input.GetAxis("Vertical") * Vector3.up * moveSpeed * Time.deltaTime;
        Vector3 horizontal = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;
        transform.Translate(vertical + horizontal);
        //Debug.DrawRay(transform.position, 10 * (vertical + horizontal), Color.green, 2, false);
        //RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position + vertical * 50 + horizontal * 50, 20 * (vertical + horizontal), rayMask);

        /*if (hit.collider == null)
        {
            transform.Translate(vertical + horizontal);
        }
        else
        {
            print(hit.collider.gameObject.name);
        }*/
    }

    void OnDeath(GameObject go, float damage)
    {
        moveSpeed = 0;
        GetComponent<Animator>().SetTrigger("Death");
        StartCoroutine(Restart());
    }

    void OnDamage(GameObject go, float damage)
    {
        GetComponent<Animator>().SetTrigger("Damage");
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameScene");
    }

}

