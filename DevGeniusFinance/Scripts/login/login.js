$(document).ready(function () {

    $('#CPF').mask('000.000.000-00', { clearIfNotMatch: true });

    // Submit Form Login
    $('#form-login').submit(function () {

        // Retirar a mask do campo cpf
        $('#CPF').unmask();

    });

});