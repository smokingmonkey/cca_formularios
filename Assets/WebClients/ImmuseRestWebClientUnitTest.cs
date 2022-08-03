// using ScreenCaptureTools;
// using TeamUtilityEditor;
// using UnityEngine;
//
// namespace WebClients
// {
//     public class ImmuseRestWebClientUnitTest : MonoBehaviour
//     {
//         [SerializeField] private ImmuseRestWebClient webClient;
//     
//         public void TestUploadNft()
//         {
//             var owner = "0xa3e3e4a2c053149b1bed48fc6afc9099f7729ddd1d749bc08b384270cb2efc1643df8a8c5a9d56476173129d19223e7a4a67a0c68a04c7c7cf37712e912754631c";
//             var image = "https://ipfs.io/ipfs/bafybeid5meznsj6h6pk5qicpvs4nd6rw3ipzembxgbgua2i5j23vvru4be/Test1RemixNft.png";
//         
//             webClient.UploadRemixNft(owner, "remixManualTest1", "un remix", image, 
//                 "xxxxx", "xxxxxx", PrintResult );
//
//         }
//     
//     
//         public void TestUploadScreenshot()
//         {
//             string imageResponse = "";
//         
//             StartCoroutine(ImmuseScreenCapture.Instance.CaptureScreenshotAsTexture2D());
//         
//         
//             ImmuseScreenCapture.Instance.OnScreenshotTexture2DReady += texture2D =>
//             {
//                 imageResponse = TextureToBase64Tool.Texture2DToBase64(texture2D);
//                 Debug.LogError("Base64  " + imageResponse);
//             
//                 webClient.UploadScreenshot(imageResponse, "Test1", PrintResult);
//             };
//         }
//
//
//
//         public void TestGetRemixByWallet()
//         {
//             string wallet = "0xa3e3e4a2c053149b1bed48fc6afc9099f7729ddd1d749bc08b384270cb2efc1643df8a8c5a9d56476173129d19223e7a4a67a0c68a04c7c7cf37712e912754631c";
//             
//             webClient.GetRemixByWallet(wallet, PrintResult);
//         }
//
//         void PrintResult(bool success ,string result)
//         {
//             Debug.LogError("Printing result ***************************************************************: " + success + " " + result);
//         }
//
//     }
// }
