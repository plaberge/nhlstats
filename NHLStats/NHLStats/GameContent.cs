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
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.2568x1444.src")))
            {
                previewMediaPhoto2568x1444 = gameContentArray[0].SelectToken("media.image.cuts.2568x1444.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.2208x1242.src")))
            {
                previewMediaPhoto2208x1242 = gameContentArray[0].SelectToken("media.image.cuts.2208x1242.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.2048x1152.src")))
            {
                previewMediaPhoto2048x1152 = gameContentArray[0].SelectToken("media.image.cuts.2048x1152.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1704x960.src")))
            {
                previewMediaPhoto1704x960 = gameContentArray[0].SelectToken("media.image.cuts.1704x960.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1536x864.src")))
            {
                previewMediaPhoto1536x864 = gameContentArray[0].SelectToken("media.image.cuts.1536x864.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1284x722.src")))
            {
                previewMediaPhoto1284x722 = gameContentArray[0].SelectToken("media.image.cuts.1284x722.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1136x640.src")))
            {
                previewMediaPhoto1136x640 = gameContentArray[0].SelectToken("media.image.cuts.1136x640.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1024x576.src")))
            {
                previewMediaPhoto1024x576 = gameContentArray[0].SelectToken("media.image.cuts.1024x576.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.960x540.src")))
            {
                previewMediaPhoto960x540 = gameContentArray[0].SelectToken("media.image.cuts.960x540.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.768x432.src")))
            {
                previewMediaPhoto768x432 = gameContentArray[0].SelectToken("media.image.cuts.768x432.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.640x360.src")))
            {
                previewMediaPhoto640x360 = gameContentArray[0].SelectToken("media.image.cuts.640x360.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.568x320.src")))
            {
                previewMediaPhoto568x320 = gameContentArray[0].SelectToken("media.image.cuts.568x320.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.372x210.src")))
            {
                previewMediaPhoto372x210 = gameContentArray[0].SelectToken("media.image.cuts.372x210.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.320x180.src")))
            {
                previewMediaPhoto320x180 = gameContentArray[0].SelectToken("media.image.cuts.320x180.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.248x140.src")))
            {
                previewMediaPhoto248x140 = gameContentArray[0].SelectToken("media.image.cuts.248x140.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.124x70.src")))
            {
                previewMediaPhoto124x70 = gameContentArray[0].SelectToken("media.image.cuts.124x70.src").ToString();
            }

            //Collect the Game Recap data.
            gameContentArray = JArray.Parse(json.SelectToken("editorial.recap.items").ToString());
            recapTitle = gameContentArray[0].SelectToken("seoTitle").ToString();
            recapHeadline = gameContentArray[0].SelectToken("headline").ToString();
            recapSubHead = gameContentArray[0].SelectToken("subhead").ToString();
            recapSeoDescription = gameContentArray[0].SelectToken("seoDescription").ToString();
            recapUrl = "http://www.nhl.com" + gameContentArray[0].SelectToken("url").ToString();

            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.2568x1444.src")))
            {
                recapMediaPhoto2568x1444 = gameContentArray[0].SelectToken("media.image.cuts.2568x1444.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.2208x1242.src")))
            {
                recapMediaPhoto2208x1242 = gameContentArray[0].SelectToken("media.image.cuts.2208x1242.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.2048x1152.src")))
            {
                recapMediaPhoto2048x1152 = gameContentArray[0].SelectToken("media.image.cuts.2048x1152.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1704x960.src")))
            {
                recapMediaPhoto1704x960 = gameContentArray[0].SelectToken("media.image.cuts.1704x960.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1536x864.src")))
            {
                recapMediaPhoto1536x864 = gameContentArray[0].SelectToken("media.image.cuts.1536x864.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1284x722.src")))
            {
                recapMediaPhoto1284x722 = gameContentArray[0].SelectToken("media.image.cuts.1284x722.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1136x640.src")))
            {
                recapMediaPhoto1136x640 = gameContentArray[0].SelectToken("media.image.cuts.1136x640.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.1024x576.src")))
            {
                recapMediaPhoto1024x576 = gameContentArray[0].SelectToken("media.image.cuts.1024x576.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.960x540.src")))
            {
                recapMediaPhoto960x540 = gameContentArray[0].SelectToken("media.image.cuts.960x540.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.768x432.src")))
            {
                recapMediaPhoto768x432 = gameContentArray[0].SelectToken("media.image.cuts.768x432.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.640x360.src")))
            {
                recapMediaPhoto640x360 = gameContentArray[0].SelectToken("media.image.cuts.640x360.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.568x320.src")))
            {
                recapMediaPhoto568x320 = gameContentArray[0].SelectToken("media.image.cuts.568x320.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.372x210.src")))
            {
                recapMediaPhoto372x210 = gameContentArray[0].SelectToken("media.image.cuts.372x210.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.320x180.src")))
            {
                recapMediaPhoto320x180 = gameContentArray[0].SelectToken("media.image.cuts.320x180.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.248x140.src")))
            {
                recapMediaPhoto248x140 = gameContentArray[0].SelectToken("media.image.cuts.248x140.src").ToString();
            }
            if (gameContentArray.Contains(gameContentArray[0].SelectToken("media.image.cuts.124x70.src")))
            {
                recapMediaPhoto124x70 = gameContentArray[0].SelectToken("media.image.cuts.124x70.src").ToString();
            }
            //recapPlaybackFLASH_192K_320X180 = gameContentArray[0].SelectToken("tokendata.").ToString();
        }
    }
}
