using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace _ACCA.Scripts.Controllers.FormItems
{
    public class TableColumnController : MonoBehaviour
    {
        TablesForm tableForm;

        TMP_InputField casillaPrefab;
        private void OnEnable()
        {
        }
        
        private void OnDisable()
        {
            tableForm.AddRows -= AddRows;
        }

        public void AddRows(int numberOfRows)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                Instantiate(casillaPrefab, transform);
            }
        }

        public void Init(TablesForm tablesForm, TMP_InputField casillaPrefab)
        {
            this.tableForm = tablesForm;
            this.casillaPrefab = casillaPrefab;
            tableForm.AddRows += AddRows;
        }

        public static void Test()
        {
            
        }
    }
}
