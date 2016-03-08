using System.Web.Mvc.Ajax;

namespace Sample.Web.Views.Helpers{
    //TODO
    public class DefaultAjaxModalOptions : AjaxOptions{
        public DefaultAjaxModalOptions(){
            InsertionMode = InsertionMode.Replace;
            UpdateTargetId = "modal-content";
            HttpMethod = "Post";
            OnFailure = "handleAjaxModalError";
            OnSuccess = "handleAjaxModalSuccess";
        }
    }
}