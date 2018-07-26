using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using Mzl.Common.ConfigHelper;
using Mzl.IApplication.Token;
using Mzl.IApplication.Token.Domain;
using Mzl.DomainModel.Token;
using Mzl.DomainModel.Enum;
using Mzl.IBLL.Token.Token;
using Mzl.DomainModel.Events;
using System.Text.RegularExpressions;

namespace Mzl.Application.Token.Domain
{
    public class TokenDomain : ITokenDomain
    {
        private ITokenBLL<TokenModel> tokenBll;

        public TokenDomain(ITokenBLL<TokenModel> tokenBll)
        {
            this.tokenBll = tokenBll;
        }

        /// <summary>
        /// 检查Token
        /// </summary>
        /// <returns></returns>
        public TokenResultModel CheckToken(HttpRequestMessage request)
        {
            TokenResultModel resultModel=new TokenResultModel();
            string token = request.Headers.GetValues("MojoryToken").First();
            //如果头部没有token 从参数中获取token
            if(string.IsNullOrEmpty(token))
            {
                string url = request.GetRequestContext().Url.ToString();
                Regex regex = new Regex("token=(?<token>.+?)&");
                token = regex.Match(url).Groups["token"].Value;
            }
            /*
             * 如果传入的token是给定的token数据，则直接返回
             */
            if (token == AppSettingsHelper.GetAppSettings(AppSettingsEnum.OAToken))
            {
                resultModel.Code = TokenResultEnum.Allow;
                resultModel.Token = token;

                IEnumerable<string> cidValuesList;
                if (request.Headers.TryGetValues("Cid", out cidValuesList))
                {
                    resultModel.Cid = Convert.ToInt32(cidValuesList.FirstOrDefault());
                }
                IEnumerable<string> oidValuesList;
                if (request.Headers.TryGetValues("Oid", out oidValuesList))
                {
                    resultModel.Oid = oidValuesList.FirstOrDefault();
                }
                else
                {
                    throw new Exception("请传入操作员id");
                }
                return resultModel;
            }

            TokenModel tokenModel=new TokenModel();
            //1.判断是否存在Token
            if (string.IsNullOrEmpty(token))//1.1 不存在，则生成Token，返回登录首页
            {
                tokenModel.Value = new TokenValueModel {Status = TokenResultEnum.Initial};
                resultModel.Code = TokenResultEnum.Initial;
                resultModel.Token = SetToken(tokenModel);
                return resultModel;
            }
            //2.根据传入的Token获取Redis中对应的信息
            tokenModel= GetToken(token);
            if (tokenModel == null)//2.1 如果不存在Redis中，则生成初始Token
            {
                tokenModel = new TokenModel {Value = new TokenValueModel {Status = TokenResultEnum.Initial}};
                resultModel.Code = TokenResultEnum.Initial;
                resultModel.Token = SetToken(tokenModel);
                return resultModel;
            }
           
            if (tokenModel.Value.Status == TokenResultEnum.Initial)//2.2.2 Token为初始状态
            {
                resultModel.Code = TokenResultEnum.Initial;
                resultModel.Token = token;
                return resultModel;
            }
            if (tokenModel.Value.Status == TokenResultEnum.NoAllow)//2.2.2 Token为禁止访问Api
            {
                resultModel.Code = TokenResultEnum.NoAllow;
                resultModel.Token = token;
                return resultModel;
            }
            //2.2.3 允许访问Api
            resultModel.Code = TokenResultEnum.Allow;
            resultModel.Token = token;
            resultModel.Cid = tokenModel.Value.Cid;
            //2.2.4 更新Token有效时间
            ExpireToken(token, 24);
            return resultModel;
        }
        /// <summary>
        ///  更新登录用户的Token，并将Token状态设置为Allow
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void UpdateUserToken(object o, TokenEventArgs e)
        {
            TokenModel t = new TokenModel
            {
                Token = e.Token,
                Value = new TokenValueModel
                {
                    UserId = e.UserId,
                    Status = TokenResultEnum.Allow,
                    Cid = e.Cid,
                    FromSource = e.FromSource
                }
            };

            UpdateToken(t);
        }
        /// <summary>
        /// 删除Token
        /// </summary>
        /// <param name="key"></param>
        public void DeleteToken(string key)
        {
            tokenBll.Delete(key);
        }

        #region 私有方法
        /// <summary>
        /// 生成Token，并保存在Redis中
        /// </summary>
        /// <returns></returns>
        private string SetToken(TokenModel token)
        {
            var key = Guid.NewGuid().ToString().Replace("-", "");
            token.Token = key;
            //保存在Redis中，默认有效期为半小时
            tokenBll.Set(token, TimeSpan.FromHours(0.5));
            return key;
        }
        /// <summary>
        /// 更新token
        /// </summary>
        /// <param name="token"></param>
        private void UpdateToken(TokenModel token)
        {
            if (!string.IsNullOrEmpty(token?.Value?.FromSource) &&(token.Value.FromSource == "A" || token.Value.FromSource == "I"))
            {
                tokenBll.Set(token, TimeSpan.FromDays(30));
            }
            else
            {
                tokenBll.Set(token, TimeSpan.FromHours(24));
            }
          
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        private TokenModel GetToken(string token)
        {
            //根据Token从Reids获取相应信息
            return tokenBll.Get(token);
        }

        /// <summary>
        /// 更新Token有效期
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        private bool ExpireToken(string token,int hours)
        {
            //更新Token的有效时间
            tokenBll.Expire(token, hours);
            return true;
        }
      

        #endregion

    }
}
