using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Lambda.Web.Infraestrutura.Helpers.Enum;

namespace Lambda.Web.Infraestrutura.Helpers
{
    public class LambdaHelpers
    {
        private HtmlHelper htmlHelper;
        public LambdaHelpers(HtmlHelper helperParam)
        {
            htmlHelper = helperParam;
        }

        public IHtmlString TextBox(string id, TextBoxType type = TextBoxType.Texto, bool exibirMensagemDeValidacao = true, object htmlAttribures = null)
        {
            var attributes = new RouteValueDictionary(htmlAttribures);

            var labelBuilder = new TagBuilder("label");
            labelBuilder.AddCssClass("input");

            switch (type)
            {
                case TextBoxType.Nome:
                    var icoBuilderNome = new TagBuilder("i");
                    icoBuilderNome.MergeAttribute("class", "ico-prepend fa fa-user");
                    labelBuilder.InnerHtml += icoBuilderNome;
                    break;
                case TextBoxType.Email:
                    var icoBuilderEmail = new TagBuilder("i");
                    icoBuilderEmail.MergeAttribute("class", "ico-prepend fa fa-envelope-o");
                    labelBuilder.InnerHtml += icoBuilderEmail;
                    break;
                case TextBoxType.Senha:
                    var icoBuilderSenha = new TagBuilder("i");
                    icoBuilderSenha.MergeAttribute("class", "ico-prepend fa fa-lock");
                    labelBuilder.InnerHtml += icoBuilderSenha;
                    break;
                case TextBoxType.Telefone:
                    var icoBuilderTelefone = new TagBuilder("i");
                    icoBuilderTelefone.MergeAttribute("class", "ico-prepend fa fa-phone-o");
                    attributes.Add("data-mask", "(99)9999-9999");
                    labelBuilder.InnerHtml += icoBuilderTelefone;
                    break;
                case TextBoxType.CEP:
                    attributes.Add("data-mask", "99.999-999");
                    break;
                case TextBoxType.CNPJ:
                    attributes.Add("data-mask", "99.999.999/9999-99");
                    break;
                case TextBoxType.Data:
                    var iconBuilderData = new TagBuilder("i");
                    iconBuilderData.MergeAttribute("class", "icon-append fa fa-calendar");
                    labelBuilder.InnerHtml += iconBuilderData;
                    attributes.Add("class", "datepicker");
                    attributes.Add("data-dateformat", "dd/mm/yy");
                    attributes.Add("data-mask", "99/99/9999");
                    break;
            }
            var textBoxHelper = htmlHelper.TextBox(id, htmlHelper.Value(id).ToHtmlString(), attributes);
            labelBuilder.InnerHtml += textBoxHelper;

            var tagMsgValidation = string.Empty;

            if (!htmlHelper.ViewData.ModelState.IsValidField(id))
            {
                labelBuilder.AddCssClass("state-error");

                if (exibirMensagemDeValidacao)
                {
                    var validationBuilder = htmlHelper.ValidationMessage(id).ToString().Replace("span", "em");
                    tagMsgValidation += validationBuilder.ToString();
                }
            }


            var htmlRetorno = labelBuilder + tagMsgValidation;

            return MvcHtmlString.Create(htmlRetorno);
        }
        public IHtmlString ImageActionLink(string sIcon, string linkName, string actionName, string controllerName,
            object routeValues, object htmlAttributes = null)
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            var iconBuilder = new TagBuilder("i");
            iconBuilder.MergeAttribute("class", sIcon);
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext, htmlHelper.RouteCollection);
            var linkBuilder = new TagBuilder("a");
            var href = "#" + urlHelper.Action(actionName, controllerName, routeValues);

            if (attributes.ContainsKey("onclick"))
                href = "javascript:void(0)";

            linkBuilder.MergeAttribute("href", href);
            linkBuilder.InnerHtml += iconBuilder;
            linkBuilder.InnerHtml += linkName;
            linkBuilder.MergeAttributes(attributes, true);
            return MvcHtmlString.Create(linkBuilder.ToString());

        }

        public IHtmlString DropDownList(string id, IEnumerable<SelectListItem> selectList,
            bool exibirMsgValidation = true,
            string optionLabel = null, object htmlAttributes = null)
        {
            var labelBuilder = new TagBuilder("label");
            labelBuilder.MergeAttribute("class", "select");

            var dropDownListHelper = htmlHelper.DropDownList(id, selectList, optionLabel, htmlAttributes);
            var iconArrow = new TagBuilder("i");
            labelBuilder.InnerHtml += dropDownListHelper + iconArrow.ToString();

            var tagMsgValidation = string.Empty;

            if (!htmlHelper.ViewData.ModelState.IsValidField(id))
            {
                labelBuilder.AddCssClass("state-error");

                if (exibirMsgValidation)
                {
                    var validationBuilder = htmlHelper.ValidationMessage(id).ToString().Replace("span", "em");
                    tagMsgValidation += validationBuilder.ToString();
                }
            }

            var htmlRetorno = labelBuilder + tagMsgValidation;

            return MvcHtmlString.Create(htmlRetorno);
        }
    }
}