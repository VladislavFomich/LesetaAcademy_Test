using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ChipChecker : MonoBehaviour
{
    [SerializeField] private int rowNum;

    private int _chipInRow;
    private LayerMask _layerChip;

    private void Awake()
    {
        _layerChip = LayerMask.GetMask("Chip");
    }

    public int ChipCheck()
    {
        _chipInRow = 0;
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, Vector3.back,100, _layerChip);
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i].collider.GetComponent<Chip>().RowNum == rowNum)
            {
                _chipInRow++;
            }
        }
        return _chipInRow;
    }

}
