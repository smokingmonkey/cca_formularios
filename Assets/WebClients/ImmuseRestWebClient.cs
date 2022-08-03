using System;
using System.Collections.Generic;
using Models;
using Newtonsoft.Json.Linq;
using Proyecto26;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using WebClients.ImmuseDataModels;

namespace WebClients
{
    public class ImmuseRestWebClient : MonoBehaviour
    {
        private readonly string basePath = "https://jsonplaceholder.typicode.com";

        private const string immuseBasePath = "https://immuse.live/api/ipfs/";

        private const string uploadScreenshotUrl = immuseBasePath + "uploadScreenshot/";
        private const string uploadRemixNftUrl = immuseBasePath + "uploadRemix/";
        private const string getRemixByWalletUrl = "https://immuse.live/api/remixnft/getRemix/";


        private RequestHelper currentRequest;

        private void LogMessage(string title, string message)
        {
#if UNITY_EDITOR
            //EditorUtility.DisplayDialog(title, message, "Ok");
#else
		Debug.Log(message);
#endif
        }


        public void UploadScreenshot(string file, string fileName, Action<bool, string> callbackMethod)
        {
            // We can add default query string params for all requests
            RestClient.DefaultRequestParams["param1"] = "My first param";
            RestClient.DefaultRequestParams["param3"] = "My other param";

            currentRequest = new RequestHelper
            {
                Uri = uploadScreenshotUrl,
                // Params = new Dictionary<string, string>
                // {
                //     {"param1", "value 1"},
                //     {"param2", "value 2"}
                // },
                Body = new UploadScreenshotData
                {
                    file = file,
                    fileName = fileName
                },
                EnableDebug = true
            };

            RestClient.Post<UploadScreenshotResponseData>(currentRequest)
                .Then(res =>
                {
                    // And later we can clear the default query string params for all requests
                    RestClient.ClearDefaultParams();

                    this.LogMessage("Success", JsonUtility.ToJson(res, true));

                    callbackMethod(true, res.imageUri);
                })
                .Catch(err =>
                {
                    this.LogMessage("Error", err.Message);
                    callbackMethod(false, null);
                });
        }

        public void UploadRemixNft(string owner, string name, string description, string image, string attributes,
            string remixSliderData, Action<bool, string> callbackMethod)
        {
            // We can add default query string params for all requests
            RestClient.DefaultRequestParams["param1"] = "My first param";
            RestClient.DefaultRequestParams["param3"] = "My other param";

            currentRequest = new RequestHelper
            {
                Uri = uploadRemixNftUrl,
                // Params = new Dictionary<string, string>
                // {
                //     {"param1", "value 1"},
                //     {"param2", "value 2"}
                // },
                Body = new UploadRemixNftData
                {
                    owner = owner,
                    name = name,
                    description = description,
                    image = image,
                    attributes = attributes,
                    remixSliderData = remixSliderData
                },
                EnableDebug = true
            };

            RestClient.Post(currentRequest)
                .Then(res =>
                {
                    // And later we can clear the default query string params for all requests
                    RestClient.ClearDefaultParams();

                    this.LogMessage("Success", JsonUtility.ToJson(res, true));

                    callbackMethod(true, "Success");
                })
                .Catch(err =>
                {
                    callbackMethod(false, null);
                    this.LogMessage("Error", err.Message);
                });
        }


        public void GetRemixByWallet(string wallet, Action<bool, string> callback)
        {
            // We can add default request headers for all requests
            RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";

            var uri = getRemixByWalletUrl + wallet;

            RestClient.Get<GetRemixByWalletDataResponse>(uri).Then(res =>
            {
                this.LogMessage("Success", JsonUtility.ToJson(res, true));

                callback(true, res.owner);

                foreach (var element in res.payload)
                {
                    Debug.LogError("Uri: " + element.tokenUri);
                    Debug.LogError("Image: " + element.tokenImage);
                }

                RestClient.ClearDefaultHeaders();
            }).Catch(err =>
            {
                this.LogMessage("Error", err.Message);
                callback(false, null);
            });
        }


        public void Get()
        {
            // We can add default request headers for all requests
            RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";

            RequestHelper requestOptions = null;

            RestClient.GetArray<Post>(basePath + "/posts").Then(res =>
            {
                this.LogMessage("Posts", JsonHelper.ArrayToJsonString<Post>(res, true));
                return RestClient.GetArray<Todo>(basePath + "/todos");
            }).Then(res =>
            {
                this.LogMessage("Todos", JsonHelper.ArrayToJsonString<Todo>(res, true));
                return RestClient.GetArray<User>(basePath + "/users");
            }).Then(res =>
            {
                this.LogMessage("Users", JsonHelper.ArrayToJsonString<User>(res, true));

                // We can add specific options and override default headers for a request
                requestOptions = new RequestHelper
                {
                    Uri = basePath + "/photos",
                    Headers = new Dictionary<string, string>
                    {
                        {"Authorization", "Other token..."}
                    },
                    EnableDebug = true
                };
                return RestClient.GetArray<Photo>(requestOptions);
            }).Then(res =>
            {
                this.LogMessage("Header", requestOptions.GetHeader("Authorization"));

                // And later we can clear the default headers for all requests
                RestClient.ClearDefaultHeaders();
            }).Catch(err => this.LogMessage("Error", err.Message));
        }

        public void Post()
        {
            // We can add default query string params for all requests
            RestClient.DefaultRequestParams["param1"] = "My first param";
            RestClient.DefaultRequestParams["param3"] = "My other param";

            currentRequest = new RequestHelper
            {
                Uri = basePath + "/posts",
                Params = new Dictionary<string, string>
                {
                    {"param1", "value 1"},
                    {"param2", "value 2"}
                },
                Body = new Post
                {
                    title = "foo",
                    body = "bar",
                    userId = 1
                },
                EnableDebug = true
            };

            RestClient.Post<Post>(currentRequest)
                .Then(res =>
                {
                    // And later we can clear the default query string params for all requests
                    RestClient.ClearDefaultParams();

                    this.LogMessage("Success", JsonUtility.ToJson(res, true));
                })
                .Catch(err => this.LogMessage("Error", err.Message));
        }

        public void Put()
        {
            currentRequest = new RequestHelper
            {
                Uri = basePath + "/posts/1",
                Body = new Post
                {
                    title = "foo",
                    body = "bar",
                    userId = 1
                },
                Retries = 5,
                RetrySecondsDelay = 1,
                RetryCallback = (err, retries) =>
                {
                    Debug.Log(string.Format("Retry #{0} Status {1}\nError: {2}", retries, err.StatusCode, err));
                }
            };
            RestClient.Put<Post>(currentRequest, (err, res, body) =>
            {
                if (err != null)
                {
                    this.LogMessage("Error", err.Message);
                }
                else
                {
                    this.LogMessage("Success", JsonUtility.ToJson(body, true));
                }
            });
        }

        public void Delete()
        {
            RestClient.Delete(basePath + "/posts/1", (err, res) =>
            {
                if (err != null)
                {
                    this.LogMessage("Error", err.Message);
                }
                else
                {
                    this.LogMessage("Success", "Status: " + res.StatusCode.ToString());
                }
            });
        }

        public void AbortRequest()
        {
            if (currentRequest != null)
            {
                currentRequest.Abort();
                currentRequest = null;
            }
        }

        public void DownloadFile()
        {
            var fileUrl = "https://raw.githubusercontent.com/IonDen/ion.sound/master/sounds/bell_ring.ogg";
            var fileType = AudioType.OGGVORBIS;

            RestClient.Get(new RequestHelper
            {
                Uri = fileUrl,
                DownloadHandler = new DownloadHandlerAudioClip(fileUrl, fileType)
            }).Then(res =>
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.clip = ((DownloadHandlerAudioClip) res.Request.downloadHandler).audioClip;
                audio.Play();
            }).Catch(err => { this.LogMessage("Error", err.Message); });
        }
    }
}