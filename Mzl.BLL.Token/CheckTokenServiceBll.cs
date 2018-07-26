using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Token;
using Mzl.IBLL.Token;
using Mzl.Framework.Base;
using Mzl.Common.ConfigHelper;
using Mzl.DomainModel.Enum;
using Mzl.EntityModel.Customer.AppClient;
using System.Text.RegularExpressions;

namespace Mzl.BLL.Token
{
    public class CheckTokenServiceBll: BaseServiceBll,ICheckTokenServiceBll
    {
        private readonly ITokenBll _tokenBll;
        public CheckTokenServiceBll(ITokenBll tokenBll)
        {
            _tokenBll = tokenBll;
        }

        public TokenResultModel CheckToken(HttpRequestMessage request)
        {
            TokenResultModel resultModel = new TokenResultModel();
            string token = "";
            try
            {
                token = request.Headers.GetValues("MojoryToken").First();
            }
            catch
            {
                //如果头部没有token 从参数中获取token
                if (string.IsNullOrEmpty(token))
                {
                    string url = request.RequestUri.ToString();
                    Regex regex = new Regex("token=(?<token>.+?)&");
                    token = regex.Match(url).Groups["token"].Value;
                }
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


            IEnumerable<string> valuesList;
            string fromSource = "O";
            if (request.Headers.TryGetValues("OrderSource", out valuesList))
            {
                fromSource = valuesList.FirstOrDefault();
            }

            TokenModel tokenModel = new TokenModel();
            //1.判断是否存在Token
            if (string.IsNullOrEmpty(token))//1.1 不存在，则生成Token，返回登录首页
            {
                tokenModel.Value = new TokenValueModel {Status = TokenResultEnum.Initial, FromSource = fromSource };
                resultModel.Code = TokenResultEnum.Initial;
                resultModel.Token = _tokenBll.SetToken(tokenModel);
                return resultModel;
            }
            //2.根据传入的Token获取Redis中对应的信息
            tokenModel = _tokenBll.GetToken(token);
            if (tokenModel == null)//2.1 如果不存在Redis中，则生成初始Token
            {
                tokenModel = new TokenModel { Value = new TokenValueModel { Status = TokenResultEnum.Initial, FromSource = fromSource } };
                resultModel.Code = TokenResultEnum.Initial;
                resultModel.Token = _tokenBll.SetToken(tokenModel);
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
            //2.2.3 判断当前传入的设备号是和保存的设备Id一致
            //TODO:如果新增个性化后，这个功能就需要根据个性化修改了
            string appClientId = string.Empty;
            if (request.Headers.TryGetValues("AppClientId", out valuesList))
            {
                appClientId = valuesList.FirstOrDefault();
            }
            if (!string.IsNullOrEmpty(appClientId)&& tokenModel.Value.Cid.HasValue)
            {
                CustomerAppClientIdEntity customerAppClientIdEntity =
                    base.Context.Set<CustomerAppClientIdEntity>()
                        .FirstOrDefault(
                            n => n.Cid == tokenModel.Value.Cid.Value && n.ClientId.ToUpper() == appClientId.ToUpper());
                if (customerAppClientIdEntity == null)
                {
                    _tokenBll.DeleteToken(token);
                    resultModel.Code = TokenResultEnum.MobileChanged;
                    resultModel.Token = token;
                    return resultModel;
                }
            }

            //2.2.4 允许访问Api
            resultModel.Code = TokenResultEnum.Allow;
            resultModel.Token = token;
            resultModel.Cid = tokenModel.Value.Cid;

            //2.2.5 更新Token有效时间
            _tokenBll.ExpireToken(token, 24);
            return resultModel;
        }
    }
}
