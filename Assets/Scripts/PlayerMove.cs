using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 20f;
    public float rotationSpeed = 40f;
    public float teleportDistance = 10f; // 순간이동할 거리
    public float jumpHeight = 5f; // Space바로 올라갈 높이
    public int deathCount = 10;
    public Text leftLife;

    private Animator animator;
    private bool isJumping = false;
    public AudioClip hitSound; // 피격음 파일
    private AudioSource audioSource;
    private void Start()
    {
        animator = GetComponent<Animator>(); // Animator 컴포넌트 가져오기
        audioSource = gameObject.AddComponent<AudioSource>(); // AudioSource 추가
        leftLife.text = "남은 목숨: " + deathCount;
    }

    void Update()
    {
        // 이동 처리
        bool isMoving = false;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            isMoving = true;
        }

        // 애니메이션: Run 설정
        if (!isJumping)  // 점프 중이 아닐 때만 이동 상태 적용
        {
            animator.SetBool("IsMoving", isMoving);
        }

        // 마우스 회전 처리
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);

        // Shift 키 입력 시 순간이동
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 teleportDirection = transform.forward * teleportDistance;
            transform.position += teleportDirection;
        }

        // 점프 처리
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true; // 점프 상태로 변경
            animator.SetBool("IsJumping", true); // Jump 애니메이션 실행
            transform.Translate(0, jumpHeight, 0); // y축 이동 (점프)

            // 1초 후 점프 상태 해제
            StartCoroutine(EndJumpAnimation());
        }
    }

    IEnumerator EndJumpAnimation()
    {
        yield return new WaitForSeconds(1f); // 1초 대기
        isJumping = false; // 점프 상태 해제
        animator.SetBool("IsJumping", false); // Jump 애니메이션 종료
    }

    // 적과 충돌 시 호출
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // 피격음 재생
            if (hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);
            }
            deathCount--;
            leftLife.text = "남은 목숨: " + deathCount;
            Destroy(other.gameObject);
        }
    }
}
