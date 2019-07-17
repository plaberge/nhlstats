using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStats
{
    public class GameContent
    {

        public string gameID { get; set; }
        public string previewTitle { get; set; }
        public string previewHeadline { get; set; }
        public string previewSubHead { get; set; }
        public string previewSeoDescription { get; set; }
        public string previewUrl { get; set; }
        public string previewMediaPhoto2568x1444 { get; set; }
        public string previewMediaPhoto2208x1242 { get; set; }
        public string previewMediaPhoto2048x1152 { get; set; }
        public string previewMediaPhoto1704x960 { get; set; }
        public string previewMediaPhoto1536x864 { get; set; }
        public string previewMediaPhoto1284x722 { get; set; }
        public string previewMediaPhoto1136x640 { get; set; }
        public string previewMediaPhoto1024x576 { get; set; }
        public string previewMediaPhoto960x540 { get; set; }
        public string previewMediaPhoto768x432 { get; set; }
        public string previewMediaPhoto640x360 { get; set; }
        public string previewMediaPhoto568x320 { get; set; }
        public string previewMediaPhoto372x210 { get; set; }
        public string previewMediaPhoto320x180 { get; set; }
        public string previewMediaPhoto248x140 { get; set; }
        public string previewMediaPhoto124x70 { get; set; }
        public JObject gameContentJson { get; set; } // Populate the raw JSON to a property

         


        public string recapTitle { get; set; }
        public string recapHeadline { get; set; }
        public string recapSubHead { get; set; }
        public string recapSeoDescription { get; set; }
        public string recapUrl { get; set; }  //Line 1938
        public string recapMediaPhoto2568x1444 { get; set; }  // Line 1955
        public string recapMediaPhoto2208x1242 { get; set; }
        public string recapMediaPhoto2048x1152 { get; set; }
        public string recapMediaPhoto1704x960 { get; set; }
        public string recapMediaPhoto1536x864 { get; set; }
        public string recapMediaPhoto1284x722 { get; set; }
        public string recapMediaPhoto1136x640 { get; set; }
        public string recapMediaPhoto1024x576 { get; set; }
        public string recapMediaPhoto960x540 { get; set; }
        public string recapMediaPhoto768x432 { get; set; }
        public string recapMediaPhoto640x360 { get; set; }
        public string recapMediaPhoto568x320 { get; set; }
        public string recapMediaPhoto372x210 { get; set; }
        public string recapMediaPhoto320x180 { get; set; }
        public string recapMediaPhoto248x140 { get; set; }
        public string recapMediaPhoto124x70 { get; set; }

        public string recapPlaybackFLASH_192K_320X180 { get; set; }
        public string recapPlaybackFLASH_450K_400X224 { get; set; }
        public string recapPlaybackFLASH_1200K_640X360 { get; set; }
        public string recapPlaybackFLASH_1800K_960X540 { get; set; }
        



        //Example Content:  https://statsapi.web.nhl.com/api/v1/game/2018020323/content
        //Image content:  https://nhl.bamcontent.com/images/photos/302168986/248x140/cut.jpg

        // Default Constructor
        public GameContent()
        {

        }

        public GameContent(string theGameID)
        {
            // Populate the gameID property
            gameID = theGameID;

            // Get the URL for the API call to a specific Game
            string theGame = NHLAPIServiceURLs.specificGameContent.Replace("###", theGameID);

            // Execute the API call
            var json = DataAccessLayer.ExecuteAPICall(theGame);

            // Populate the raw JSON feed to a property
            gameContentJson = json;

            // Collect the Game Preview Data
            var gameContentArray = JArray.Parse(json.SelectToken("editorial.preview.items").ToString());
            JObject gCJson = new JObject(json.SelectToken("editorial").ToObject<JObject>());
            JObject imageData;

            JObject previewJson = new JObject();

            if (gCJson.ContainsKey("preview") && gameContentArray.Count > 0)
            {

                previewJson = JObject.Parse(gCJson.SelectToken("preview.items[0]").ToString());
                if (previewJson.ContainsKey("seoTitle") == true)
                {
                    previewTitle = gameContentArray[0].SelectToken("seoTitle").ToString();
                }

                if (previewJson.ContainsKey("headline") == true)
                {
                    previewHeadline = gameContentArray[0].SelectToken("headline").ToString();

                }

                if (previewJson.ContainsKey("subhead") == true)
                {
                    previewSubHead = gameContentArray[0].SelectToken("subhead").ToString();
                }

                if (previewJson.ContainsKey("seoDescription") == true)
                {
                    previewSeoDescription = gameContentArray[0].SelectToken("seoDescription").ToString();
                }

                if (previewJson.ContainsKey("url") == true)
                {
                    previewUrl = "http://www.nhl.com" + gameContentArray[0].SelectToken("url").ToString();
                }

                //var imageJson = JObject.Parse(gameContentArray[0].ToString());
                var imageJson = JObject.Parse(json.ToString());

                if (imageJson.ContainsKey("editorial"))
                {
                    var imageJson2 = JObject.Parse(imageJson.SelectToken("editorial").ToString());
                    
                    if (imageJson2.ContainsKey("preview"))
                    { 
                    var imageJson3 = JObject.Parse(imageJson2.SelectToken("preview").ToString());

                        if (imageJson3.ContainsKey("items"))
                        {

                            if (imageJson3.ContainsKey("image"))
                            {

                                //var cutsJson = JObject.Parse(imageJson2.SelectToken("image.cuts").ToString());

                                //if (cutsJson.ContainsKey("cuts"))
                                //{
                                //imageData = JObject.Parse(gameContentArray[0].SelectToken("media.image.cuts").ToString());

                                imageData = JObject.Parse(imageJson2.SelectToken("cuts").ToString());
                                if (imageData.ContainsKey("2568x1444"))
                                {
                                    previewMediaPhoto2568x1444 = imageData.SelectToken("2568x1444.src").ToString();
                                }
                                if (imageData.ContainsKey("2208x1242"))
                                {
                                    previewMediaPhoto2208x1242 = imageData.SelectToken("2208x1242.src").ToString();
                                }
                                if (imageData.ContainsKey("2048x1152"))
                                {
                                    previewMediaPhoto2048x1152 = imageData.SelectToken("2048x1152.src").ToString();
                                }
                                if (imageData.ContainsKey("1704x960"))
                                {
                                    previewMediaPhoto1704x960 = imageData.SelectToken("1704x960.src").ToString();
                                }
                                if (imageData.ContainsKey("1536x864"))
                                {
                                    previewMediaPhoto1536x864 = imageData.SelectToken("1536x864.src").ToString();
                                }
                                if (imageData.ContainsKey("1284x722"))
                                {
                                    previewMediaPhoto1284x722 = imageData.SelectToken("1284x722.src").ToString();
                                }
                                if (imageData.ContainsKey("1136x640"))
                                {
                                    previewMediaPhoto1136x640 = imageData.SelectToken("1136x640.src").ToString();
                                }
                                if (imageData.ContainsKey("1024x576"))
                                {
                                    previewMediaPhoto1024x576 = imageData.SelectToken("1024x576.src").ToString();
                                }
                                if (imageData.ContainsKey("960x540"))
                                {
                                    previewMediaPhoto960x540 = imageData.SelectToken("960x540.src").ToString();
                                }
                                if (imageData.ContainsKey("768x432"))
                                {
                                    previewMediaPhoto768x432 = imageData.SelectToken("768x432.src").ToString();
                                }
                                if (imageData.ContainsKey("640x360"))
                                {
                                    previewMediaPhoto640x360 = imageData.SelectToken("640x360.src").ToString();
                                }
                                if (imageData.ContainsKey("568x320"))
                                {
                                    previewMediaPhoto568x320 = imageData.SelectToken("568x320.src").ToString();
                                }
                                if (imageData.ContainsKey("372x210"))
                                {
                                    previewMediaPhoto372x210 = imageData.SelectToken("372x210.src").ToString();
                                }
                                if (imageData.ContainsKey("320x180"))
                                {
                                    previewMediaPhoto320x180 = imageData.SelectToken("320x180.src").ToString();
                                }
                                if (imageData.ContainsKey("248x140"))
                                {
                                    previewMediaPhoto248x140 = imageData.SelectToken("248x140.src").ToString();
                                }
                                if (imageData.ContainsKey("124x70"))
                                {
                                    previewMediaPhoto124x70 = imageData.SelectToken("124x70.src").ToString();
                                }
                            }
                        }
                    }
                }
            }


            gameContentArray = JArray.Parse(json.SelectToken("editorial.recap.items").ToString());

            //Collect the Game Recap data.
            if (gCJson.ContainsKey("recap") && gameContentArray.Count > 0)
            {


                previewJson = gCJson.SelectToken("recap.items[0]").ToObject<JObject>();
                if (previewJson.ContainsKey("seoTitle") == true)
                {
                    recapTitle = gameContentArray[0].SelectToken("seoTitle").ToString();
                }

                if (previewJson.ContainsKey("headline") == true)
                {
                    recapHeadline = gameContentArray[0].SelectToken("headline").ToString();
                }

                if (previewJson.ContainsKey("subhead") == true)
                {
                    recapSubHead = gameContentArray[0].SelectToken("subhead").ToString();
                }

                if (previewJson.ContainsKey("seoDescription") == true)
                {
                    recapSeoDescription = gameContentArray[0].SelectToken("seoDescription").ToString();
                }

                if (previewJson.ContainsKey("url") == true)
                {
                    recapUrl = "http://www.nhl.com" + gameContentArray[0].SelectToken("url").ToString();
                }

                //var imageJson = JObject.Parse(gameContentArray[0].ToString());
                var imageJson = JObject.Parse(json.SelectToken("highlights").ToString());

                if (imageJson.ContainsKey("scoreboard"))
                {
                    var imageJson2 = JObject.Parse(imageJson.SelectToken("scoreboard").ToString());

                    if (imageJson2.ContainsKey("items"))
                    {
                        var imageJson3 = JObject.Parse(imageJson2.SelectToken("items[0]").ToString());

                        if (imageJson3.ContainsKey("image"))
                        {
                            var imageJson4 = JObject.Parse(imageJson3.SelectToken("image").ToString());

                            //if (imageJson4.ContainsKey("cuts"))
                            //{
                            //    imageJson5 = JObject.Parse(imageJson4.SelectToken("cuts").ToString());



                            //var cutsJson = JObject.Parse(imageJson2.SelectToken("image.cuts").ToString());

                            //if (cutsJson.ContainsKey("cuts"))
                            //{
                            //imageData = JObject.Parse(gameContentArray[0].SelectToken("gameCenter.image.cuts").ToString());

                            imageData = JObject.Parse(imageJson4.SelectToken("cuts").ToString());
                            if (imageData.ContainsKey("2568x1444"))
                            {
                                recapMediaPhoto2568x1444 = imageData.SelectToken("2568x1444.src").ToString();
                            }
                            if (imageData.ContainsKey("2208x1242"))
                            {
                                recapMediaPhoto2208x1242 = imageData.SelectToken("2208x1242.src").ToString();
                            }
                            if (imageData.ContainsKey("2048x1152"))
                            {
                                recapMediaPhoto2048x1152 = imageData.SelectToken("2048x1152.src").ToString();
                            }
                            if (imageData.ContainsKey("1704x960"))
                            {
                                recapMediaPhoto1704x960 = imageData.SelectToken("1704x960.src").ToString();
                            }
                            if (imageData.ContainsKey("1536x864"))
                            {
                                recapMediaPhoto1536x864 = imageData.SelectToken("1536x864.src").ToString();
                            }
                            if (imageData.ContainsKey("1284x722"))
                            {
                                recapMediaPhoto1284x722 = imageData.SelectToken("1284x722.src").ToString();
                            }
                            if (imageData.ContainsKey("1136x640"))
                            {
                                recapMediaPhoto1136x640 = imageData.SelectToken("1136x640.src").ToString();
                            }
                            if (imageData.ContainsKey("1024x576"))
                            {
                                recapMediaPhoto1024x576 = imageData.SelectToken("1024x576.src").ToString();
                            }
                            if (imageData.ContainsKey("960x540"))
                            {
                                recapMediaPhoto960x540 = imageData.SelectToken("960x540.src").ToString();
                            }
                            if (imageData.ContainsKey("768x432"))
                            {
                                recapMediaPhoto768x432 = imageData.SelectToken("768x432.src").ToString();
                            }
                            if (imageData.ContainsKey("640x360"))
                            {
                                recapMediaPhoto640x360 = imageData.SelectToken("640x360.src").ToString();
                            }
                            if (imageData.ContainsKey("568x320"))
                            {
                                recapMediaPhoto568x320 = imageData.SelectToken("568x320.src").ToString();
                            }
                            if (imageData.ContainsKey("372x210"))
                            {
                                recapMediaPhoto372x210 = imageData.SelectToken("372x210.src").ToString();
                            }
                            if (imageData.ContainsKey("320x180"))
                            {
                                recapMediaPhoto320x180 = imageData.SelectToken("320x180.src").ToString();
                            }
                            if (imageData.ContainsKey("248x140"))
                            {
                                recapMediaPhoto248x140 = imageData.SelectToken("248x140.src").ToString();
                            }
                            if (imageData.ContainsKey("124x70"))
                            {
                                recapMediaPhoto124x70 = imageData.SelectToken("124x70.src").ToString();
                            }


                            //recapPlaybackFLASH_192K_320X180 = gameContentArray[0].SelectToken("tokendata.").ToString();
                            // Need to add:  Recap Flash Videos, Line Score 17111 (see line 15882:  liveData.linescore),  Boxscore (see line 15992:  liveData.boxscore), Decisions (see line 17810:  liveData.decisions
                            //}
                        }
                    }
                }
            }
        }
    }
}
