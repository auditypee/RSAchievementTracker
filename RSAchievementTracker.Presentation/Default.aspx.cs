using System;
using System.Net;
using System.Web.UI;

namespace RSAchievementTracker.Presentation
{
    public partial class Default : Page
    {
        private readonly string URLSTATS = "https://secure.runescape.com/m=hiscore/index_lite.ws?player=";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // do something initially
            }
        }

        protected void TrackBtn_Click(object sender, EventArgs e)
        {
            string username = userNameTB.Text;

            // error check for valid username
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(URLSTATS + username);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Response.Redirect("UserPage.aspx?User=" + Server.UrlEncode(username));
                }
                else
                {
                }

                response.Close();
            }
            catch (WebException we)
            {
                UsernameLbl.Text = username + " does not exist or is not a valid username.";
                WebErrorLbl.Text = we.Message;
            }
        }
    }
}