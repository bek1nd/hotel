using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Train;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Train.Search;

namespace Mzl.Mojory.WebApi.Controllers.Train.Order
{
    /// <summary>
    /// 查询火车行程信息
    /// </summary>
    public class SearchTrainController : ApiController
    {
        private readonly ISearchTrainApplication _searchTrainApplication;

        public SearchTrainController(ISearchTrainApplication searchTrainApplication)
        {
            _searchTrainApplication = searchTrainApplication;
        }

        /// <summary>
        /// 查询航班
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<SearchTrainResponseViewModel>> SearchTrain(
            [FromBody] SearchTrainRequestViewModel request)
        {
            request.Cid = this.GetCid();
            SearchTrainResponseViewModel viewModel = new SearchTrainResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _searchTrainApplication.SearchTrain(request);
            });

            ResponseBaseViewModel<SearchTrainResponseViewModel> v = new ResponseBaseViewModel
                <SearchTrainResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
