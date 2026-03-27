
async function baixarImagemComDadosAPI() {
    try {
        // Buscar dados da API
        const resposta = await fetch('https://sua-api.com/dados');
        const dados = await resposta.json();
        
        // Criar canvas
        const canvas = document.createElement('canvas');
        canvas.width = 600;
        canvas.height = 400;
        const ctx = canvas.getContext('2d');
        
        // Desenhar conteúdo
        ctx.fillStyle = '#ffffff';
        ctx.fillRect(0, 0, canvas.width, canvas.height);
        
        ctx.fillStyle = '#000000';
        ctx.font = 'bold 20px Arial';
        ctx.fillText(dados.titulo, 20, 50);
        
        ctx.font = '16px Arial';
        ctx.fillText(`Usuário: ${dados.nome}`, 20, 100);
        ctx.fillText(`Data: ${dados.data}`, 20, 140);
        
        // Quebrar descrição em linhas
        ctx.font = '14px Arial';
        const palavras = dados.descricao.split(' ');
        let linha = '';
        let y = 180;
        
        for (const palavra of palavras) {
            const linhaTeste = linha ? `${linha} ${palavra}` : palavra;
            if (ctx.measureText(linhaTeste).width > canvas.width - 40) {
                ctx.fillText(linha, 20, y);
                linha = palavra;
                y += 20;
            } else {
                linha = linhaTeste;
            }
        }
        if (linha) ctx.fillText(linha, 20, y);
        
        // Baixar como PNG
        canvas.toBlob((blob) => {
            const anchor = document.createElement('a');
            const url = URL.createObjectURL(blob);
            anchor.href = url;
            anchor.download = 'minha_imagem.png';
            anchor.click();
            URL.revokeObjectURL(url);
        }, 'image/png');
        
    } catch (erro) {
        console.error('Erro:', erro);
    }
}