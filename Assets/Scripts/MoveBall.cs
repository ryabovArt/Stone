using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    public Rigidbody rb; // ссылка на Rigidbody
    public Transform myCamera; // ссылка на камеру
    private GroundDetection groundDetection; // ссылка на скрипт, описывающий, касается ли объект платформы
    public List<GameObject> textObject; // список текстовых объектов
    public float force; // ускорение при движениии
    public float jumpForce; //  ускорение при прыжке
    bool isCP = false; // является ли объект чекпоинтом
    bool isFallPlayer; // упал ли игрок с платформы
    HealthSystem healthSystem;

    void Start()
    {
        groundDetection = GetComponent<GroundDetection>();
        rb.transform.position = new Vector3(0, 3.5f, 0);
        healthSystem = GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundDetection.isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(myCamera.forward * force);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce((myCamera.forward + Vector3.up) * -force);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(myCamera.right * -force);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(myCamera.right * force);

        if (isFallPlayer) // если игрок упал с платформы
            myCamera.LookAt(gameObject.transform.position); // камера смотрит в направлении игрока
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("CheckPoint")) // если игрок коснулся чекпоинта
        {
            PlayerPrefs.SetFloat("xPos", transform.position.x); //
            PlayerPrefs.SetFloat("yPos", transform.position.y); // запоминаем его положение
            PlayerPrefs.SetFloat("zPos", transform.position.z); //
            Destroy(col.gameObject); // уничтожаем чекпоинт
            isCP = true; // указываем, что объект был чекпоинтом
            for (int i = 0; i < textObject.Count; i++) // удаляем надпись "чекпоинт"
            {
                Destroy(textObject[0]);
                textObject.Remove(textObject[0]);
                return;
            }
        }
        if (col.gameObject.CompareTag("LowestPoint")) // при касании "нижней точки"
        {
            healthSystem.health--; // отнимаем 1 жизнь
            StartCoroutine(FallPlayer()); // запускаем корутину
        }
    }
    /// <summary>
    /// Поведение камеры в момент падения с платформы
    /// </summary>
    /// <returns></returns>
    IEnumerator FallPlayer()
    {
        MoveCamera cam = myCamera.GetComponent<MoveCamera>();
        cam.enabled = false; // отключаем поведение камеры в скрипте MoveCamera
        isFallPlayer = true; // разрешаем камере смотреть в направлении игрока
        yield return new WaitForSeconds(2f); // ждем 2 сек
        cam.enabled = true; // включаем поведение камеры в скрипте MoveCamera
        isFallPlayer = false; // запрещаем камере смотреть в направлении игрока
        PassedCheckpoint();
    }
    /// <summary>
    /// Прошел ли игрок Чекпоинт
    /// </summary>
    public void PassedCheckpoint()
    {
        if (isCP == true) // если игрок прошел через чекпоинт
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("xPos"), PlayerPrefs.GetFloat("yPos"),
            PlayerPrefs.GetFloat("zPos")); // возвращаем его к ближайшему чекпоинту
        }
        else // если нет
            transform.position = new Vector3(0, 2, 0); // возвращаем его к началу уровня
    }
}
