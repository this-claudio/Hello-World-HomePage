Aqui está um exemplo de um README.md para a sua aplicação ASP.NET Core, incluindo a descrição das rotas disponíveis.

```markdown
# Nome da Aplicação

Uma breve descrição da sua aplicação. Descreva o propósito e as funcionalidades principais que ela oferece.

## Tecnologias Utilizadas

- ASP.NET Core
- C#
- Swagger (para documentação da API)
- Docker (opcional, se você estiver usando contêineres)

## Instalação

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão recomendada)
- [Docker](https://www.docker.com/get-started) (opcional)

### Clonando o Repositório

```bash
git clone https://seu-repositorio-url.git
cd seu-repositorio
```

### Executando a Aplicação

#### Via CLI

1. Restaure as dependências:

   ```bash
   dotnet restore
   ```

2. Execute a aplicação:

   ```bash
   dotnet run
   ```

3. Acesse a aplicação no seu navegador em `http://localhost:80`.

#### Via Docker

Se você estiver utilizando Docker, você pode construir e executar a imagem:

1. Construa a imagem:

   ```bash
   docker build -t nome-da-imagem .
   ```

2. Execute o contêiner:

   ```bash
   docker run -d -p 80:80 nome-da-imagem
   ```

## Rotas

### `GET /`

- **Descrição**: Retorna a página inicial (HTML).
- **Resposta**: HTML com uma mensagem de boas-vindas.

![image](https://github.com/user-attachments/assets/2ec717c6-caef-455f-9156-22f7c0f52577)


### `GET /status`

- **Descrição**: Retorna o status da aplicação e informações do ambiente.
- **Resposta**: JSON contendo as seguintes informações:
  - `MachineName`: Nome da máquina.
  - `OperationSystem`: Sistema operacional.
  - `IsRunning`: Estado da aplicação (booleano).
  - `ProcessCode`: Código do processo em execução.

#### Exemplo de Resposta:

```json
{
  "MachineName": "NomeDaMaquina",
  "OperationSystem": "Windows",
  "IsRunning": true,
  "ProcessCode": "1234"
}
```

## Documentação da API

A documentação da API está disponível através do Swagger. Após executar a aplicação, você pode acessá-la em:

```
http://localhost:80/swagger
```

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir um issue ou enviar um pull request.
