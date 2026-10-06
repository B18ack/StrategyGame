using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SelectController : MonoBehaviour
{
    public GameObject cube;                     // Префаб куба выделения
    public List<GameObject> players = new List<GameObject>();
    public LayerMask groundLayer;               // Слой земли (для рейкастов)
    public LayerMask unitLayer;                 // Слой юнитов (для BoxCast)

    private Camera _cam;
    private GameObject _cubeSelection;
    private Vector3 _startPoint;                // Точка, где нажали ЛКМ

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // ===== ПКМ — отдать приказ выбранным юнитам =====
        if (Input.GetMouseButtonDown(1) && players.Count > 0)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit agentTarget, 1000f, groundLayer))
            {
                foreach (var el in players)
                {
                    if (el != null)
                        el.GetComponent<NavMeshAgent>().SetDestination(agentTarget.point);
                }
            }
        }

        // ===== ЛКМ вниз — начинаем выделение =====
        if (Input.GetMouseButtonDown(0))
        {
            // Снимаем выделение со старых юнитов
            foreach (var el in players)
            {
                if (el != null)
                    el.transform.GetChild(0).gameObject.SetActive(false);
            }
            players.Clear();

            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000f, groundLayer))
            {
                _startPoint = hit.point;
                _cubeSelection = Instantiate(cube, new Vector3(_startPoint.x, 1f, _startPoint.z), Quaternion.identity);
            }
        }

        // ===== Тянем мышью — обновляем размер и позицию куба =====
        if (_cubeSelection != null)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitDrag, 1000f, groundLayer))
            {
                // Центр прямоугольника
                Vector3 center = (_startPoint + hitDrag.point) / 2f;
                center.y = 1f;

                // Размер (всегда положительный)
                float xScale = Mathf.Abs(_startPoint.x - hitDrag.point.x);
                float zScale = Mathf.Abs(_startPoint.z - hitDrag.point.z);

                _cubeSelection.transform.position = center;
                _cubeSelection.transform.localScale = new Vector3(xScale, 1f, zScale);
                _cubeSelection.transform.rotation = Quaternion.identity;
            }
        }

        // ===== ЛКМ вверх — выбираем юнитов и удаляем куб =====
        if (Input.GetMouseButtonUp(0) && _cubeSelection != null)
        {
            Vector3 halfExtents = _cubeSelection.transform.localScale / 2f;
            halfExtents.y = 5f; // запас по высоте, чтобы точно ловить машинки

            RaycastHit[] hits = Physics.BoxCastAll(
                _cubeSelection.transform.position,
                halfExtents,
                Vector3.up,
                Quaternion.identity,
                0f,
                unitLayer
            );

            foreach (var hit in hits)
            {
                // Пропускаем врагов
                if (hit.collider.CompareTag("Enemy")) continue;

                GameObject unit = hit.transform.gameObject;
                players.Add(unit);
                unit.transform.GetChild(0).gameObject.SetActive(true); // включаем индикатор выделения
            }

            Destroy(_cubeSelection);
            _cubeSelection = null;
        }
    }
}