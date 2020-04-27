using ContactApps.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ContactApps.Helper {
    class ContactHelper {
        public static string ReadSettings(string key) {
            string result = string.Empty;
            try {
                var settings = ConfigurationSettings.AppSettings;
                result = settings[key];
            } catch (Exception es) {
                throw es;
            }
            return result;
        }

        public static bool Validation(string name, string phone) {
            return (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone)) ? false : true;
        }
    }
}
