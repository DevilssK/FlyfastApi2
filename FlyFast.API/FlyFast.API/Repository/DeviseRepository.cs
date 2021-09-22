using FlyFast.API.Models;
using FlyFast.API.Models.ViewModels;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FlyFast.API.Repository
{
    public class DeviseRepository : IDisposable
    {

        #region [Logger]
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        public const String URL_DEVISE = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";


        public async Task<List<Devise>> GetDevises()
        {


            List<Devise> devises = new List<Devise>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = await client.GetAsync(URL_DEVISE);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.Write("Success");

                        var body =await  response.Content.ReadAsStringAsync();

                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(body);


                        devises = doc.GetElementsByTagName("Cube").Cast<XmlNode>()
                            .Where(w=>w.ChildNodes.Count == 0).Select(s=> new Devise() { Currency = s.Attributes["currency"].Value.ToString() , Rate = float.Parse(s.Attributes["rate"].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat), CurrentDate =  DateTime.Now }).ToList();

                    }
                }


            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return devises;
        }

        public void Dispose()
        {
        }
    }
}