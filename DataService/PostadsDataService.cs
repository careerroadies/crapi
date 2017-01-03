using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataAccessLayer;
using DataserviceInterface;

namespace DataService
{
    public class PostadsDataService : IPostAdsService
    {
        public bool SaveAds(postads postads)
        {

            SqlDataAccess obj = new SqlDataAccess();
            string strQuery = "SaveAds";
            var arrParam = new string[13, 2];
            arrParam[0, 0] = "_adsid";
            arrParam[0, 1] = postads.adsid.ToString();

            arrParam[1, 0] = "_adcategoryid";
            arrParam[1, 1] = postads.adcategoryid.ToString();

            arrParam[2, 0] = "_adtitle";
            arrParam[2, 1] = postads.adtitle.ToString();

            arrParam[3, 0] = "_adtitle";
            arrParam[3, 1] = postads.adtitle.ToString();

            arrParam[4, 0] = "_addescription";
            arrParam[4, 1] = postads.addescription.ToString();

            arrParam[5, 0] = "_state";
            arrParam[5, 1] = postads.state.ToString();

            arrParam[6, 0] = "_city";
            arrParam[6, 1] = postads.city.ToString();

            arrParam[7, 0] = "_location";
            arrParam[7, 1] = postads.location.ToString();

            arrParam[8, 0] = "_name";
            arrParam[8, 1] = postads.name.ToString();

            arrParam[9, 0] = "_email";
            arrParam[9, 1] = postads.email.ToString();

            arrParam[10, 0] = "_mobilenumber";
            arrParam[10, 1] = postads.mobilenumber.ToString();

            arrParam[11, 0] = "_image";
            arrParam[11, 1] = postads.image.ToString();

            arrParam[11, 0] = "_createdby";
            arrParam[11, 1] = postads.createdby.ToString();

            arrParam[11, 0] = "_active";
            arrParam[11, 1] = postads.active.ToString();  

            var result = obj.ExecuteNonQuery(strQuery, arrParam);

            return (result > 0) ? true : false;

        }
    }
}
