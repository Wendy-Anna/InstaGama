﻿using InstaGama.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaGama.Domain.Entities
{
    public class Usuario
    {
        public Usuario(string nome, string email, string senha,
                        DateTime dataNascimento, Genero genero, string foto)
        {
            Nome = nome;
            Email = email;
            CriptografaSenha(senha);
            DataNascimento = dataNascimento;
            Genero = genero;
            Foto = foto;
        }

        public Usuario(string nome,
                    DateTime dataNascimento,
                    Genero genero,
                    string photo)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Genero = genero;
            Foto = photo;
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public Genero Genero { get; private set; }

        public string Foto { get; private set; }

        public bool SeValido()
        {
            bool valido = true;

            //Se alguns desses campos não for preenchido, o usuário não é válido
            if(string.IsNullOrEmpty(Nome) || DataNascimento.ToShortDateString() == "01/01/01" || Genero.Id <= 0 || string.IsNullOrEmpty(Foto))
            {
                valido = false;
            }

            return valido;
        }

        private void CriptografaSenha (string senha)
        {
            Senha = PasswordHasher.Hash(senha);
        }

        //verifica se as senhas são iguais
        public bool ComparaSenha(string senha)
        {
            return PasswordHasher.Verify(senha, Senha);
        }

        public void InformacaoLoginUsuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
