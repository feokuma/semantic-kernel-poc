# Microsoft Semantic Kernel PoC
Aplicação para testar as funcionalidades do SDK da Microsoft para IA. Para criar o este projeto, foram utilizadas as seguintes referências:
- [Microsoft Learn - Semantic Kernel](https://learn.microsoft.com/en-us/semantic-kernel/overview/)
- [Johnny Hooyberghs - Building your own AI Agent using Semantic Kernel](https://www.youtube.com/live/hG8GTOWi0Q0?si=JF-Gh24f3qlXmVdR)
- [Microsoft Semantic Kernel Playlist](https://youtube.com/playlist?list=PL-PgMmMmma8AJdJyjmywUGDR-IB7BI6Ks&si=6QG664vwOpegW78_)

## Tecnologias
- [.NET 9](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0)
- [Semantic Kernel](https://github.com/microsoft/semantic-kernel)
- [Spectre.Console](https://spectreconsole.net/)

## Pré requisitos
Para conseguir executar esta aplicação é necessário ter um conta da [OpenAI API](https://openai.com/index/openai-api/) para obter a `key` necessária para utilização dos serviços de **Chat Completion**

Primeiro, [crie uma conta na OpenAI](https://platform.openai.com/signup) ou faça [login](https://platform.openai.com/login). Depois, vá até a página de **API Key Page** e clique em **"Create new secret key"**. Se quiser, você pode dar um nome para a chave. Lembre-se de guardar isso em um lugar seguro e não compartilhar com ninguém. Infelizmente este serviço é pago, mas é possível fazer um plano pré pago com o valor minimo de $5 doletas. 

Uma vez com o **Secret Key** "em mãos", crie uma variável de ambiente chamada **OPENAI_KEY** que será utilizada pela aplicação para se autenticar no serviço. Abaixo estão exemplos de como exportar essa variável

**Sistemas Unix Like (Linux/MacOS)**
```shell
export OPENAI_KEY=sk-*************1234*************abcd
```

**Windows Command Prompt**
```cmd
set OPENAI_KEY=sk-*************1234*************abcd
```

Agora a aplicação será capaz de se autenticar no serviço da **OpenAI** para consumir os serviços.


## Executando a aplicação
Para executar a aplicação utilize o seguinte comando na raiz do diretório do projeto

```shell
dotnet run
```

## Navegando entre as partes da PoC
Foram feitos diversos testes e validação utilizando este mesmo código com base. Para cada fase dos testes foram criadas **tags** na árvore de commits deste repositório. Para cada parte há uma descrição na tag do que foi implementado. Para navegar entre essas partes basta fazer o checkout para cada uma das tags.

### #parte1
Exemplos de implementação de diversos prompts para refinar a interação com a OpenAI API

### #parte2
Implementa o comportamento de chat mas não guarda contexto de uma mensagem para outra. 

### #parte3
Adiciona o ChatHistory para manter no contexto da conversa do chat

### #parte4
Adiciona SystemMessage para configurar o GPT para responder com uma pessoa engraçada

### #parte5
Cria um plugin dar a capacidade do GPT responder a data e hora