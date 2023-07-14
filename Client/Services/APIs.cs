using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerApp.Services
{
    internal class APIs
    {
        //public const string _baseUrl = "https://localhost:7077/";
        //public const string _baseUrl = "http://localhost:5194/";
        //public const string _baseUrl = "https://2cef-94-205-243-114.in.ngrok.io/";
        public const string _baseUrl = "https://eae4-94-205-243-114.ngrok-free.app/";



        public const string InsertRiders = "api/Settings/Create";
        public const string Create = "api/Settings/Create";
        public const string FilterBy = "api/Settings/FilterBy/";
        public const string GetAll = "api/Settings/GetAll";
        public const string CreateUsers = "api/Users/Create";
        public const string CreateUsersLogin = "api/Login/Create";
        public const string AuthenticateUsersLogin = "api/Login/AuthenticateUser";
        public const string GetByEmail = "api/Users/GetByEmail/";
        public const string UpdateUsers = "api/Users/Update/";
        public const string GetIndustryWithData = "api/Settings/GetIndustryWithData/";
        public const string GetInfluencerByRanking = "api/Influencer/GetInfluencerByRanking/";
        public const string GetInfluencerById = "api/Influencer/GetInfluencerById/";
        public const string GetInfluencerServiceById = "api/Influencer/GetInfluencerServiceById/";
        public const string GetInfluencerRestDayById = "api/Influencer/GetInfluencerRestDayById/";
        public const string GetInfluencerTimeTypeById = "api/Influencer/GetInfluencerTimeTypeById/";
        public const string GetInfluencerByFilter = "api/Influencer/GetInfluencerByFilter/";
        public const string CreateOrder = "api/Order/CreateOrder/";
        public const string CreateDetail = "api/Order/CreateDetail/";
        public const string CreateTarget = "api/Order/CreateTarget/";
        public const string GetUserById = "api/Order/GetUserById/";
        public const string GetOrderById = "api/Order/GetOrderById/";
        public const string ViewOrder = "api/Order/ViewOrder/";
        public const string ViewOrderDetail = "api/Order/ViewOrderDetail/";
        public const string ViewOrderTarget = "api/Order/ViewOrderTarget/";
        public const string CheckoutOrderById = "api/Order/CheckoutOrderById/";
        public const string checkout = "checkout";


    }
}
