// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityNpgsql;
//
// public class WebClient : MonoBehaviour
// {
//     async void Start()
//     {
//         //var connString = "Host=psql-mock-database-cloud.postgres.database.azure.com;Username=tfdetbnxachfqkzfetegjgzd@psql-mock-database-cloud;Password=erkakaozkgfcdakoemszqhvw;Database=booking1658606619405qgssjredrshubpwm";
//
//         var connString = "Host=servidor-pruebas-base.cy8xvk5wzzp5.sa-east-1.rds.amazonaws.com;Username=admin_diogenes;Password=Region1.05;Database=postgres";   
//
//         
//         
// // var connString =
// //             "Host=servidor-pruebas-base.cy8xvk5wzzp5.sa-east-1.rds.amazonaws.com;Username=admin_diogenes;Password=Region1.05;Database=BasePruebaFormulario";
//
//
//         await using var conn = new NpgsqlConnection(connString);
//         await conn.OpenAsync();
//
// //Insert some data
//         // await using (var cmd =
//         //     new NpgsqlCommand(
//         //         "INSERT INTO analiticafacil (nombre, documento, ocupacion, ingresos, ciudad) VALUES ('Holderlin', '10', 'poeta',15,'Egmundo')",
//         //         conn))
//         // {
//         //     //cmd.Parameters.AddWithValue("p", "Hello world");
//         //     await cmd.ExecuteNonQueryAsync();
//         // }
//
//
// // // Retrieve all rows
// //         await using (var cmd = new NpgsqlCommand("SELECT some_field FROM bookings", conn))
// //         await using (var reader = await cmd.ExecuteReaderAsync())
// //         {
// //             while (await reader.ReadAsync())
// //                 Debug.LogError(reader.GetString(0));
// //         }
//     }
// }