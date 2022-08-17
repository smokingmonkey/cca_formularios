using System;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _ACCA.Scripts.Controllers.FormItems
{
    public class TablesForm : MonoBehaviour
    {
        public event Action<int> AddRows;

        private int currentNumberOfRows;

        [SerializeField] TMP_InputField casillaPrefab;

        [SerializeField] private GameObject TableCOntrollerParent;
        [SerializeField] private TableColumnController columnsParent;

        [SerializeField] private Button addColumn;
        [SerializeField] private Button addRow;


        private void OnEnable()
        {
            addColumn.onClick.AddListener(AddColumn);
            addRow.onClick.AddListener(AddRow);
        }
        
        private void OnDisable()
        {
            addColumn.onClick.RemoveListener(AddColumn);
            addRow.onClick.RemoveListener(AddRow);
        }

        private void Start()
        {
            currentNumberOfRows = 1;
            AddColumn();
        }

        void AddColumn()
        {
            var tableColumnController = Instantiate(columnsParent, TableCOntrollerParent.transform);
            tableColumnController.Init(this, casillaPrefab, currentNumberOfRows);
        }

        void AddRow()
        {
            AddRows?.Invoke(1);
            currentNumberOfRows++;
        }


        protected virtual void OnAddRows(int obj)
        {
            AddRows?.Invoke(obj);
        }
    }
}