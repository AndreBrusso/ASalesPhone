function realizarCompra(modelo) {
    fetch('/Compra/RealizarCompra', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ modelo: modelo })
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            alert('Compra realizada com sucesso!');
            // Opcional: redirecionar para outra página ou atualizar o carrinho
        } else {
            alert(data.message || 'Não foi possível realizar a compra.');
        }
    })
    .catch(error => {
        console.error('Erro ao realizar a compra:', error);
        alert('Ocorreu um erro ao processar sua compra. Por favor, tente novamente.');
    });
} 