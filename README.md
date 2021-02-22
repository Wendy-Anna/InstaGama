<p align="center">	
	<h1 align="center"> ✨InstaGama✨ </h1>
</p>

---


Sobre
=========
REST API COM .NET CORE  
Descrição:  
Desafio final solicitado pela Gama Academy como parte do processo para obtenção do certificado.
Era necessário o desenvolvimento de uma API backend em .NET. 
O projeto final era uma redes sociais, onde os usuários poderiam logar, criar postagem, comentar e curtir na mesma.   
Esse projeto foi pensado para permitir a interoperabilidade entre a aplicação e os usuários. Adotado princípios SOLID, que permitem legibilidade e grande manutenibilidade. 
  



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
- [x] Inserção  de comentário nas postagens
- [x] Inserção de curtida nas postagens
- [x] Linha do tempo com reunião das postagens
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
° POST /api/Comentario – Adicionar Comentario a postagem
° GET /api/Comentario/{idPostagem} - Listar Postagens realizadas
° DELETE /api/Comentario/{id} - Excluir comentario
``` -->

Curtida
```
° POST /api/Curtida/ - Adicionar curtida a postagem
° GET /api/Curtida/{id} - Buscar curtida pelo ID 
```

Login
```
° POST /api/Login – Criar Login
```


Tecnologias
==========
Recursos tecnológicos usados na construção do projeto:

- [.NET](https://docs.microsoft.com/pt-br/dotnet/)

- [Autênticação JWT](https://jwt.io/)

- [Arquitetura REST](wikipedia.org/wiki/REST)

- [Insominia](https://insomnia.rest/)

- [Postman](https://www.postman.com/)

- [SQL Server ](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)

- [Visual studio](https://visualstudio.microsoft.com/pt-br/)


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
