using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Lambda.Web.Infraetrutura.Helpers.Enum;

namespace Lambda.Web.Infraetrutura.Helpers
{
    public class LambdaHelpers
    {
        private HtmlHelper htmlHelper;
        public LambdaHelpers(HtmlHelper helperParam)
        {
            htmlHelper = helperParam;
        }

        public IHtmlString Textbox(string id, TextBoxType type = TextBoxType.Texto, bool exibirMensagemDeValidacao = true, object htmlAttribures = null)
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
    }
}