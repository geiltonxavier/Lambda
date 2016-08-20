function excluirEmpresa(id) {
    confirmSmallBox('Exclusão de empresa', 'Deseja realmente excluir a empresa selecionada?', 'fa-building', function () {
        executarExclusaoEmpresa(id);
    });
}

function executarExclusaoEmpresa(id) {
    $.ajax({
        url: "Empresa/Excluir",
        data: { id: id },
        type: "POST",
        async: false,
        complete: function () {
            location.reload();
        }
    });
}

function excluirUsuario(id) {
    confirmSmallBox('Exclusão de usuário', 'Deseja realmente excluir o usuário selecionado?', 'fa-user', function () {
        executarExclusaoUsuario(id);
    });
}

function executarExclusaoUsuario(id) {
    $.ajax({
        url: "Usuario/Excluir",
        data: { id: id },
        type: "POST",
        async: false,
        complete: function (result) {
            location.reload();
        }
    });
}


function confirmSmallBox(titulo, mensagem, icone, callbackYes, callbackNo) {
    var conteudo = mensagem + "<p class='text-align-right'><a href='javascript:void(0);' id='smallBoxYes' class='btn btn-primary btn-sm'>Sim</a> <a href='javascript:void(0);' id='smallBoxNo' class='btn btn-danger btn-sm'>Não</a></p>";
    $.smallBox({
        title: titulo,
        content: conteudo,
        color: "#296191",
        icon: "fa " + icone
    });
    if ($("#smallBoxYes").length > 0) {
        $("#smallBoxYes").click(callbackYes);
    }
    if ($("#smallBoxNo").length > 0) {
        $("#smallBoxNo").click(callbackNo);
    }
}

function msgAlerta(titulo, msg, icone, temSom, timeOutMsg, color) {
    var colorAlert;

    if (color == undefined) {
        colorAlert = "#C79121";
    } else {
        colorAlert = color;
    }

    $.smallBox({
        title: titulo,
        content: msg,
        color: colorAlert,
        icon: "fa " + icone,
        timeout: timeOutMsg,
        sound: temSom
    });
}

function onSucessoEmpresa(result) {
    if (result.Sucesso) {
        window.location.href = result.MsgResposta;
    } else if (result.Sucesso == false && result.MsgResposta != '') {
        msgAlerta("Erro ao salvar Empresa", result.MsgResposta, 'fa-building', false, 6000);
    } else {
        //Renderizando novamente o conteúdo da view
        $('#content').html(result);

        //Limpando as validações para caso o usuário saia do campo com uma nova informação ela não continue sendo informada
        $('form[class="smart-form"]').removeData('validator');
        $('form[class="smart-form"]').removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse('form[class="smart-form"]');
    }
}

function onSucessoUsuario(result) {
    if (result.Sucesso) {
        window.location.href = result.MsgResposta;
    } else if (result.Sucesso == false && result.MsgResposta != '') {
        msgAlerta("Erro ao salvar Usuário", result.MsgResposta, 'fa-user', false, 6000);
    } else {
        //Renderizando novamente o conteúdo da view
        $('#content').html(result);

        //Limpando as validações para caso o usuário saia do campo com uma nova informação ela não continue sendo informada
        $('form[class="smart-form"]').removeData('validator');
        $('form[class="smart-form"]').removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse('form[class="smart-form"]');
    }
}