using System.Collections;
using UnityEngine;

public class ObjectDragTransform : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10;
    [SerializeField] float _maxMoveSpeed = 10;
    Vector3 _mouseDown;
    Vector3 _mouseMove;

    private void Update()
    {
        MouseDrag2();
        RangeLimit();
    }
    void MouseDrag1()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseDown = Input.mousePosition;//�N���b�N���̍��W�擾

        }
        if (Input.GetMouseButton(0))
        {
            _mouseMove = Input.mousePosition;//���݂̃}�E�X�̍��W�擾
            Vector3 distance = _mouseDown - _mouseMove;//����
            //���x����
            if (distance.x > _maxMoveSpeed && distance.x > 0)
            {
                distance.x = _maxMoveSpeed;
            }
            if (distance.y > _maxMoveSpeed && distance.x > 0)
            {
                distance.y = _maxMoveSpeed;
            }
            if (distance.x < _maxMoveSpeed && distance.x < 0)
            {
                distance.x = -_maxMoveSpeed;
            }
            if (distance.y < _maxMoveSpeed && distance.x < 0)
            {
                distance.y = -_maxMoveSpeed;
            }
            this.transform.position += distance / (_moveSpeed * Screen.width);

        }

    }
    void MouseDrag2()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseDown = Input.mousePosition;//�N���b�N���̍��W�擾

        }
        if (Input.GetMouseButton(0))
        {
            _mouseMove = Input.mousePosition;//���݂̃}�E�X�̍��W�擾
            Vector3 distance = _mouseDown - _mouseMove;//����
            this.transform.position += distance / (_moveSpeed * Screen.width);
            distance.x = 0;
            distance.y = 0;
        }
    }
    void RangeLimit()
    {
        //�͈͐���
        if (this.transform.position.x > 1830)
        {
            this.transform.position = new Vector3(1830, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.x < -1325)
        {
            this.transform.position = new Vector3(-1325, this.transform.position.y, this.transform.position.z);
        }
        if (this.transform.position.y > 600)
        {
            this.transform.position = new Vector3(this.transform.position.x, 600, this.transform.position.z);
        }
        if (this.transform.position.y < -1000)
        {
            this.transform.position = new Vector3(this.transform.position.x, -1000, this.transform.position.z);
        }
    }

}