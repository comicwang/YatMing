using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 商户资料管理系统.YatServer;

namespace 商户资料管理系统.Common
{
    public class ServiceProvider
    {
        private static YatMingServiceClient _clent = null;

        public static YatMingServiceClient Clent
        {
            get 
            {
                if (_clent == null)
                    _clent = new YatMingServiceClient();
                return ServiceProvider._clent; 
            }
            set { ServiceProvider._clent = value; }
        }
    }
}
