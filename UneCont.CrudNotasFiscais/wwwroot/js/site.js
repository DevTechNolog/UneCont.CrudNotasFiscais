// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    const apiBase = 'http://localhost:5000/api/notas'; // ajuste a porta se necessário
    let notasCache = [];
    let ascending = false;


    // busca todas as notas e popula tabela
    function carregarNotas() {
        $.get(apiBase)
            .done(function (data) {
                notasCache = data; // manter cache para filtragem/ordenacao
                renderTabela(notasCache);
            })
            .fail(function () {
                alert('Erro ao carregar notas do servidor.');
            });
    }


    function renderTabela(notas) {
        const tbody = $('#tabelaNotas tbody');
        tbody.empty();


        notas.forEach(n => {
            const tr = $('<tr>');
            tr.append($('<td>').text(n.numero));
            tr.append($('<td>').text(n.cliente));
            tr.append($('<td>').text(n.valor));
            tr.append($('<td>').text(formatDate(n.dataEmissao)));
            tr.append($('<td>').text(formatDateTime(n.dataCadastro)));
            tbody.append(tr);
        });
    }


    function formatDate(iso) {
        if (!iso) return '';
        const d = new Date(iso);
        return d.toLocaleDateString('pt-BR');
    }


    function formatDateTime(iso) {
        if (!iso) return '';
        const d = new Date(iso);
        return d.toLocaleString('pt-BR');
    }


    // Validação simples do form
    $('#notaForm').on('submit', function (e) {
        e.preventDefault();


        const dto = {
            numero: $('#numero').val().trim(),
            cliente: $('#cliente').val().trim(),
            valor: parseFloat($('#valor').val()),
            dataEmissao: $('#dataEmissao').val()
        };


        // validações
        if (!dto.numero || !dto.cliente || !dto.valor || !dto.dataEmissao) {
            showMessage('Preencha todos os campos obrigatórios.', true);
            return;
        }


        // converter data para ISO (ajuda no backend)
        dto.dataEmissao = new Date(dto.dataEmissao).toISOString();


        $.ajax({
            url: apiBase,
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(dto)
        })
            .done(function () {
                showMessage('Nota cadastrada com sucesso.');
                $('#notaForm')[0].reset();
                carregarNotas(); // atualizar tabela dinamicamente
            })
            .fail(function (xhr) {
                const msg = xhr.responseJSON?.message || 'Erro ao cadastrar';
                showMessage(msg, true);
            });

    })

    function showMessage(text, isError) {
        const el = $('#formMessage');
        el.text(text).css('color', isError ? 'red' : 'green');
        setTimeout(() => el.text(''), 4000);
    }
})