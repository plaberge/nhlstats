﻿using Newtonsoft.Json.Linq;
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

            // Collect the Game Preview Data
            var gameContentArray = JArray.Parse(json.SelectToken("editorial.preview.items").ToString());
            previewTitle = gameContentArray[0].SelectToken("seoTitle").ToString();
            previewHeadline = gameContentArray[0].SelectToken("headline").ToString();
            previewSubHead = gameContentArray[0].SelectToken("subhead").ToString();
            previewSeoDescription = gameContentArray[0].SelectToken("seoDescription").ToString();
            previewUrl = "http://www.nhl.com" + gameContentArray[0].SelectToken("url").ToString();

            JObject imageData = JObject.Parse(gameContentArray[0].SelectToken("media.image.cuts").ToString());
            //if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.2568x1444.src")))
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

            //Collect the Game Recap data.
            gameContentArray = JArray.Parse(json.SelectToken("editorial.recap.items").ToString());
            recapTitle = gameContentArray[0].SelectToken("seoTitle").ToString();
            recapHeadline = gameContentArray[0].SelectToken("headline").ToString();
            recapSubHead = gameContentArray[0].SelectToken("subhead").ToString();
            recapSeoDescription = gameContentArray[0].SelectToken("seoDescription").ToString();
            recapUrl = "http://www.nhl.com" + gameContentArray[0].SelectToken("url").ToString();

             imageData = JObject.Parse(gameContentArray[0].SelectToken("media.image.cuts").ToString());
            
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
        }
    }
}