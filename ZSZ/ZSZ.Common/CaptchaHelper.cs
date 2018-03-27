using CaptchaGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.Common
{
    /// <summary>
    /// 验证码帮助类
    ///     1，引用 Install-Package CaptchaGen
    /// </summary>
    public class CaptchaHelper
    {
        public static string CreateVerifyCode(int len)
        {
            //定义验证码字符及出现频次 ,避免出现0 o j i l 1 x;  
            char[] data = { 'a', 'c', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 's', 't', 'w', 'x', 'y', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'Q', 'R' };
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < len; i++)
            {
                int index = rand.Next(data.Length);//[0,data.length)
                char ch = data[index];
                sb.Append(ch);
            }
            return sb.ToString();
        }

        public static MemoryStream CreateVerifyCodeImg(string code)
        {           
            MemoryStream ms = ImageFactory.GenerateImage(code, 60, 100, 20, 6);
            return ms;

        }
    }
}
