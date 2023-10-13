using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FMController : MonoBehaviour
{
    [SerializeField] GameObject activeObj;
    RaycastHit2D hitObject;
    RaycastHit2D hittedObject;

    Vector3 _mouseDown;
    Vector3 _mouseMove;
    bool allowClick = false;

    AudioSource _audio;
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        MouseDrag();
        //���C�L���X�g2D�Ń}�E�X�I�[�o�[�����I�u�W�F�N�g�擾
        var tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var collition2d = Physics2D.OverlapPoint(tapPoint);
        if (collition2d)
        {
            hitObject = Physics2D.Raycast(tapPoint, -Vector2.up);
            if (hitObject)
            {
                //�}�E�X�I�[�o�[�������F�ύX
                hitObject.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 170f / 255f);
                hittedObject = hitObject;
            }
        }
        else
        {
            hitObject = new RaycastHit2D();
        }
        if (Input.GetMouseButtonUp(0) && allowClick)//�N���b�N������
        {
            if (hitObject)
            {
                hitObject.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f, 1f);
                activeObj.SetActive(true);
                _audio.Play();
            }
        }
        if (!hitObject && hittedObject)//�}�E�X�I�[�o�[���ĂȂ��Ƃ�
        {
            hittedObject.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 109f / 255f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activeObj.SetActive(false);
        }
    }
    void MouseDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseDown = Input.mousePosition;//�N���b�N���̍��W�擾

        }
        if (Input.GetMouseButton(0))
        {
            _mouseMove = Input.mousePosition;//���݂̃}�E�X�̍��W�擾
            Vector3 distance = _mouseDown - _mouseMove;//����
            //�}�E�X���h���b�O���Ă���N���b�N�̋���false��
            if (distance.x * distance.x > 100 || distance.y * distance.y > 100)
            {
                allowClick = false;
            }
            else
            {
                allowClick = true;
            }
            //Debug.Log(distance.x + " " + distance.y + " " + allowClick);
        }
    }


}
