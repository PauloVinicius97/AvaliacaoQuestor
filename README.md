# Avaliação da Questor

Implementação de API com AutoMapper, autenticação com JWT token, Entity Framework, camadas, injeção de dependência e PostgreSQL.

## Rodando no Visual Studio:

1 - Tenha um banco em PostgreSQL para conectar;

2 - No appsettings.json da API, configure a connection string “AvaliacaoQuestorDB” para conectar no banco:
![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/1f2f5eab-c11b-4346-9f69-69980bc18e2c)

3 - Dê update no banco de dados executando os seguintes comandos no Console do Gerenciador de Pacotes:

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/4a85aa5f-aeb3-46d4-b2ab-5377da2cf6b3)

```
dotnet ef database update --context AvaliacaoQuestorContext --startup-project ./AvaliacaoQuestor.API
```

```
dotnet ef database update --context ApplicationDbContext --startup-project ./AvaliacaoQuestor.API
```

Um contexto para as entidades e outro único para o Identity.

4 - Execute a API:

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/94f91308-4ecf-41b7-8744-280a11c02b97)

## Utilizando via Swagger:

1 - Cadastre um admin com a rota /register-admin. A senha deve ter pelo menos um caractere maiúsculo, mais de 8 dígitos e caracteres especiais:

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/6aada332-5fd9-4ac9-9ea8-864cd3c2b8c7)

2 - Faça login via rota /login com usuário e senha criados e copie o token:

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/66b33523-4591-4f3e-b622-04cb433a9dcf)

3 - Em “Authorize”, no topo da página, digite “Bearer”, dê espaço, cole o token e clique em “Authorize”. Exemplo:

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/977b59be-bd45-48c5-8a0f-d8ee697eff36)

4 - As demais rotas devem estar liberadas para uso. Prints de seu funcionamento:

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/1805f0eb-2b3d-4387-a57d-ae519b1402f6)

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/8792feab-9894-4c50-802d-08bb2b797cd6)

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/8c59ee15-d490-46aa-898d-a1c4145d742a)

OBS.: na hora de cadastrar um Boleto, use a dueDate conforme formato exibido, caso contrário não irá funcionar.

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/f8d69d5d-08a4-42a5-9c78-b207abcf0601)

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/6dd78ae0-78d5-4f62-b5c1-ac603cd85073)

![image](https://github.com/PauloVinicius97/AvaliacaoQuestor/assets/29510126/b647b879-8875-4363-9103-49c43c5853f5)

O funcionamento das rotas deve estar de acordo com o enunciado da avaliação.



