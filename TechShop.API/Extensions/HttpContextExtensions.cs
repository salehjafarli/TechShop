using TechShop.Helpers;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Extensions
{
    public static class HttpContextExtensions
    {
        public static async Task LogRequest(this HttpRequest req, ILogger logger)
        {
            //Header
            string log = $"--Request--:\n--Request Headers:--";
            foreach (var pairs in req.Headers)
            {
                log += String.Format("\n{0} : {1}", pairs.Key, pairs.Value);
            }

            //Body
            log += "\n--Request body:--";
            string json = await req.GetBodyJson();
            log += $"\n{json}";

            logger.Information(log);
        }


        public static async Task LogResponse(this HttpResponse res, ILogger logger)
        {
            //Header
            string log = $"--Response--:\n--Response Headers:--";
            foreach (var pairs in res.Headers)
            {
                log += String.Format("\n{0} : {1}", pairs.Key, pairs.Value);
            }

            //Body
            log += "\n--Response body:--";
            string json = await res.GetBodyJson();
            log += $"\n{json}";

            logger.Information(log);
        }



        public async static Task<string> GetBodyJson(this HttpResponse res)
        {
            string responseBodyString;
            res.Body.Position = 0;
            var buffer = new byte[Convert.ToInt32(res.ContentLength)];
            await res.Body.ReadAsync(buffer, 0, buffer.Length);
            responseBodyString = Encoding.UTF8.GetString(buffer);
            string json = JSONPrettier.FormatJson(responseBodyString);
            return json;
        }
        public async static Task<string> GetBodyJson(this HttpRequest req)
        {
            string requestBodyString;
            req.Body.Position = 0;
            var buffer = new byte[Convert.ToInt32(req.ContentLength)];
            await req.Body.ReadAsync(buffer, 0, buffer.Length);
            requestBodyString = Encoding.UTF8.GetString(buffer);
            string json = JSONPrettier.FormatJson(requestBodyString);
            return json;
        }


    }
}
