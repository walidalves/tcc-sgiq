$(function () {
    $('#btnAdicionarMedida').click(function () {

        $.ajax({
            url: "./AddMedida",
            type: "POST",
            data: $("#frmMetrica").serialize(),
            success: function (data) {
                alert('Sucesso');
                
            },
            error: function () {
                alert('erro');
            }
        });
    })
});