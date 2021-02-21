Sobre
=========
REST API COM .NET CORE  
Descrição: API backend, para redes sociais.   Permite a interoperabilidade entre aplicações e entre os usuários.  
Adotado princípios SOLID, que permitem legibilidade e grande manutenibilidade. 



Índice
=================


   * [Status](#Status)
   * [Funcionalidades](#funcionalidades)
   * [Endpoints](#Endpoints)
   * [Tecnologias](#tecnologias)
   * [Agradecimentos](#agradecimentos)
   * [Desenvolvedoras](#desenvolvedoras)
   


Status
============
```
O Projeto está concluído.
```


Funcionalidades
=====
```
- [x] Cadastro de usuário
- [x] Inserção de Postagem com texto/foto e/ou vídeo
- [ ] Inserção  de comentário nas postagens
- [ ] Inserção de curtida nas postagens
- [ ] Algum com as Fotos do usuário
- [ ] Linha do tempo com reunião das postagens
```

Endpoints
==========
Usuário
```
° POST /api/Usuario – Criar  usuário
° GET /api/Usuario/{id} – Buscar usuário pelo ID
° PUT /api/Usuario/{id}/alterar – Editar usuário
° DELETE /api/Usuario/{id} – Excluir usuário
```

Postagem
```
° POST /api/Postagem – Criar postagem
° GET /api/Postagem {id}– Buscar Postagem pelo ID
° PUT
° DELETE
```

Amigo
```
° POST /api/Amigo – Criar amigo
° GET /api/Amigo – Listar os amigos
° GET /api/Amigos/{id} – Busca amigo pelo ID
° DELETE /api/Amigo/{idUsuario}/{idVinculo} – Excluir um amigo
```

<!-- Comentário
```
° POST xxxxxxxxxxxxx – Criar Comentario
° GET xxxxxxxxxxxxxxx 
° PUT
° DELETE
``` -->

Curtida
```
° GET /api/Curtida/{id} - Buscar curtida pelo ID 
```

Login
```
° POST /api/Login – Criar Login

```

Tecnologias
==========
Recursos tecnológicos usados na construção do projeto:

- [.net](https://docs.microsoft.com/pt-br/dotnet/)

- [Autênticação JWT](https://jwt.io/)

- [Arquitetura REST](wikipedia.org/wiki/REST)

- [Insominia](https://insomnia.rest/)

- [Postman](https://www.postman.com/)

- [SQL-Server ](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)

- [Visual-studio](https://visualstudio.microsoft.com/pt-br/)


Agradecimentos
==========
- [Gama Academy](https://www.gama.academy/)

- [Fernando Mendes](https://github.com/marraia)

Desenvolvedoras
==========
<table>
  <tr>
    <td align="center"><a href="https://https://github.com/karolrobertax3"><sub><b>Karol Roberta Souza Batista</b></sub><br />
    </td>
    <td align="center"><a href="https://github.com/MarciaMartins"><sub><b>Márcia Pompeu Martins</b></sub><br />
    </td>
    <td align="center"><a href="https://github.com/Wendy-Annahttps://github.com/RRRAMOS"><sub><b>Raquel Rodrigues Ramos</b></sub><br />
    </td>  
    <td align="center"><a href="https://github.com/Wendy-Anna"><sub><b>Wendy-Anna Albuquerque Lopes</b></sub><br />
    </td>
   </tr>
</table>
