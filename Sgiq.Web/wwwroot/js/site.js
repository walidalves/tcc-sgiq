$(function () {
    //aplica o select2 nos select 
    //$('select').select2({ placeholder: 'Selecione', theme: 'bootstrap' });

    //Impede submit automático do formulário
    $('form').submit(function (e) {
        e.preventDefault();
    });
});